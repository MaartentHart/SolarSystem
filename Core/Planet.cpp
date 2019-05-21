//Copyright Maarten 't Hart 2019
#include "stdafx.h"
#include "Planet.h"

//maximum iterations for ellipse calculation.
int maxIterations = sizeof(double) * 8 + 1;
time_t J2000 = mktime(&Time(2000, 1, 1, 12, 0, 0));

CTime Time(double year, double month, double day, double hour, double minute, double second)
{
	CTime time;
	time.tm_year = year - 1900;
	time.tm_mon = month;
	time.tm_mday = day;
	time.tm_hour = hour;
	time.tm_min = minute;
	time.tm_sec = second;
	return time;
}

double TimeSinceJ2000(CTime time)
{
	return difftime(mktime(&time), J2000);
}

double TimeSinceJ2000(double year, double month, double day, double hour, double minute, double second)
{
	return TimeSinceJ2000(Time(year, month, day, hour, minute, second));
}

double DaysSinceJ2000(double year, double month, double day, double hour, double minute, double second)
{
	return TimeSinceJ2000(Time(year, month, day, hour, minute, second)) / 86400;// / 24 / 3600;
}

Orbit::Orbit()//default: earth
{
	epoch = 0;
	apoapsis = 152100000;
	periapsis = 147100000;
	semimajorAxis = (apoapsis + periapsis) / 2;//(apofocus+perifocus)/2
	eccentricity = 0.01671123;//(apofocus-perifocus)/(apofocus+perifocus)
	inclination = 1.578690;
	longitudeAscendingNode = 348.73936;
	argumentPeriapsis = 114.20783;
	period = 365.256363004;
	averageSpeed = 29.78;
	
	SetCalculationValues();
}

Point3D Orbit::Position(const Point3D&ellipsePosition) const
{
	return ellipsePosition.RotateZ(argumentPeriapsisRad).RotateX(inclinationRad).RotateZ(longitudeAscendingNodeRad);
}

Point3D Orbit::Position(double t) const
{
	return Position(Point3D(cos(t) + relativeFocusDistance, sin(t)*flatFactor, 0)*semimajorAxis);
}

Point3D Orbit::PositionByTime(double days) const
{
	return Position(Position(EllipsePosition(days - timeOfPeriapsis)));
}

//returns a value between 0 and 2*pi. 
double Orbit::EllipsePosition(double days) const
{
	//calculate how many times the cycletime has passed.
	double rounds = days / period;

	//create a value between 0 and 1, as we don't care how many rounds have passed. 
	//we just need the position on the ellipse. 
	double timePosition = (rounds - floor(rounds));

	//we interpret a complet round as having a
	//surface area of 2 pi. 
	double cover = timePosition * 2 * Pi();

	//now itterate until we have found the answer. 
	int countIterations = 0;
	double prevAns = 0;
	double ans = cover;
	while (abs(ans - prevAns) > 0.0)
	{
		prevAns = ans;
		countIterations++;
		ans = (cover - relativeFocusDistance * sin(ans) + prevAns) / 2;
		if (countIterations > maxIterations)
		{
			//precise enough...
			//this break is necessary to avoid the iteration to keep flipping the least significant digits back and forth. 
			break;
		}
	}
	return ans;
}

void Orbit::SetCalculationValues()
{
	inclinationRad = Deg2Rad(inclination);
	longitudeAscendingNodeRad = Deg2Rad(longitudeAscendingNode);
	argumentPeriapsisRad = Deg2Rad(argumentPeriapsis);

	focusDistance = semimajorAxis - periapsis;
	relativeFocusDistance = focusDistance / semimajorAxis;
	semiminorAxis = sqrt(semimajorAxis*semimajorAxis - focusDistance * focusDistance);
	flatFactor = semiminorAxis / semimajorAxis;
}

Planet::Planet(double radius, double secondaryRadius, double surfaceGravity, std::string name)
{
	this->name = name;
	isSun = false;
	isMoonOf = NULL;
	this->radius = radius;
	this->secondaryRadius = secondaryRadius;
	this->surfaceGravity = surfaceGravity;
	position = Point3D(0, 0, 0);
}

void Planet::LoadCelestialBodyOrbit()
{
	//copies the relevant values from the CelestialBody to the Orbit. 
	apoapsis = Apoapsis;
	periapsis = Periapsis;
	semimajorAxis = (apoapsis + periapsis) / 2;//(apofocus+perifocus)/2
	eccentricity = (apoapsis - periapsis) / (apoapsis + periapsis);//(apofocus-perifocus)/(apofocus+perifocus)
	inclination = OrbitalInclination;
	longitudeAscendingNode = LongitudeOfAscendingNode;
	argumentPeriapsis = LongitudeOfPeriapsis - longitudeAscendingNode;
	period = SiderealOrbitPeriod;
	averageSpeed = MeanOrbitalVelocity;
	timeOfPeriapsis = TimeOfPeriapsis;
	SetCalculationValues(); 
}

double Planet::RotationAngleAt(double days) const
{
	return days / (SiderealRotationPeriod / 24) * 360;
}

Quaternion Planet::RotationAt(double days) const
{
	double aroundAxisRotation = RotationAngleAt(days);
	Quaternion localRotation = Quaternion(Point3D(0, 0, 1), aroundAxisRotation + rotationCalibration);
	return Quaternion(rotationAxis, localRotation); 
}

//Quick check if an object may cause an impact. 
bool Planet::InImpactRange(const Point3D& previousObjectPosition, Point3D& objectPosition, const Point3D& previousPlanetPosition) const
{
	BoundingBox objectBox(previousObjectPosition, objectPosition);
	BoundingBox planetBox(previousPlanetPosition, position);

	planetBox.Grow(radius);

	return objectBox.Overlaps(planetBox);
}


void Planet::Impact(const Point3D& previousObjectPosition, Point3D& objectPosition, const Point3D& previousPlanetPosition, double startTime, double endTime) const
{
	Point3D start = previousObjectPosition - previousPlanetPosition;
	Point3D end = objectPosition - position;

	//prerotate: Check when is there an impact?
	Ray ray(RotatedScaledPosition(start), RotatedScaledPosition(end)); 

	Point3D intersection;
	double position; 
	if (!ray.IntersectSingleUnitSphere(intersection, position))
		return; 

	double impactTime = (endTime - startTime) * position + startTime; 
	Point3D impactPosition = (end - start) * position + start; 
	Point3D impactVector = RotatedScaledPosition(impactPosition, impactTime); 
	objectPosition = Point3D(std::nan(""), std::nan(""), std::nan(""));
}

Point3D Planet::RotatedScaledPosition(const Point3D& relativePosition) const
{
	Point3D unrotated = rotationAxis.RotateReverse(relativePosition);
	return UnScale(unrotated);
}

Point3D Planet::RotatedScaledPosition(const Point3D& relativePosition, double days) const
{
	Point3D unrotated = RotationAt(days).RotateReverse(relativePosition);
	return UnScale(unrotated);
}

Point3D Planet::UnScale(const Point3D& point) const
{
	return Point3D(point.X / radius, point.Y / radius, point.Z / secondaryRadius);
}
