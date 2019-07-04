//Copyright Maarten 't Hart 2019
#include "stdafx.h"
#include "DllLinkage.h"

Planet* activePlanet; 
bool run = false; 
double pauseTime = 10E99; 
double pausingAtTime = -10E99;

//Tests and Examples. 
void ExampleSetString(const char*theString)
{
	std::string example(theString);
}

int ExampleGetInt()
{
	int a = 40;
	int b = 2;
	int c = a + b;
	return c;
}

std::vector<double> testVertices{
	-1, 0.5, 0,
		1, 0.5, 0,
		0, -1, 0,
		0, 0, 1 
};

std::vector<int> testIndices
{
	2, 1, 0,
		3, 0, 1,
		3, 1, 2,
		3, 2, 0
};

double* TestVertices(int generation)
{
	return &testVertices[0];
}

int TestVerticesCount(int generation)
{
	return testVertices.size(); 
}

const int* TestIndices(int generation)
{
	return &testIndices[0];
}

int TestIndicesCount(int generation)
{
	return testIndices.size(); 
}
//End of Tests and Examples. 


const double* GeodesicGridVertices(int generation)
{
	const GeodesicGrid*grid = GetGeodesicGrid((unsigned int)generation);
	return grid->points[0].XYZ;
}

int GeodesicGridVerticesCount(int generation)
{
	const GeodesicGrid*grid = GetGeodesicGrid((unsigned int)generation);
	return grid->points.size(); 
}

const int* GeodesicGridIndices(int generation)
{
	const GeodesicGrid*grid = GetGeodesicGrid((unsigned int)generation);
	return grid->GetTriangleIndices()[0].i;
}

int GeodesicGridIndicesCount(int generation)
{
  return (1 << (generation * 2)) * 60;
}

const int* GeodesicGridMipMapIndices(int generation, int mipmapGeneration)
{
	const GeodesicGrid*grid = GetGeodesicGrid((unsigned int)generation);
	return grid->GetMipMapIndices(mipmapGeneration).indices[0].i; 
}

int GeodesicGridMipMapIndicesCount(int generation, int mipmapGeneration)
{
	const GeodesicGrid*grid = GetGeodesicGrid((unsigned int)generation);
	return grid->GetMipMapIndices(mipmapGeneration).indices.size()*3;
}

int AddPlanet(const char* name, double equatorialRadius, double polarRadius,
	double surfaceGravity, double apoapsis, double periapsis, double orbitalInclination, double siderealOrbitPeriod, double siderealRotationPeriod,
	double longitudeOfAscendingNode, double longitudeOfPeriapsis, double rightAscension, double declination,
	double timeOfPeriapsis, float r, float g, float b)
{
	int i = 0; 
	for (Planet* planet : GetSolarSystem().Planets())
	{
		if (planet->name == name)
		{
			activePlanet = planet;
			return i;
		}
		i++;
	}

	Planet* planet = new Planet(equatorialRadius, polarRadius, surfaceGravity, name); 

	planet->inclination = orbitalInclination;
	planet->longitudeAscendingNode = longitudeOfAscendingNode;
		 
	planet->EquatorialRadius = equatorialRadius;//km
	planet->PolarRadius = polarRadius;//km
	planet->SemiMajorAxis = (periapsis + apoapsis)/2;//km
	planet->SiderealOrbitPeriod = siderealOrbitPeriod;//days
	planet->TropicalOrbitPeriod = siderealOrbitPeriod;//days
	planet->periapsis = planet->Periapsis = periapsis;//km
	planet->apoapsis = planet->Apoapsis = apoapsis;//km

	planet->period = siderealOrbitPeriod; 

	planet->SiderealRotationPeriod = siderealRotationPeriod;

	planet->OrbitalInclination = orbitalInclination;//deg
	planet->LongitudeOfAscendingNode = longitudeOfAscendingNode;//deg
	planet->LongitudeOfPeriapsis = longitudeOfPeriapsis;//deg

	planet->RightAscension = rightAscension;// - Undefined
	planet->Declination = declination;// - Undefined

	planet->color = Color(r, g, b, 1.0f);

	planet->semimajorAxis = planet->SemiMajorAxis;
	planet->focusDistance = planet->semimajorAxis - planet->periapsis;

	planet->semiminorAxis = sqrt(planet->semimajorAxis * planet->semimajorAxis - planet->focusDistance * planet->focusDistance);
	planet->relativeFocusDistance = planet->focusDistance / planet->semimajorAxis;
	planet->flatFactor = planet->semiminorAxis / planet->semimajorAxis;

	planet->timeOfPeriapsis = timeOfPeriapsis;


	planet->SetCalculationValues();


	GetSolarSystem().AddPlanet(planet); 
	
	return i; 
}

int SetActivePlanet(const char*name)
{
	int i = 0; 
	for (Planet*planet : GetSolarSystem().Planets())
	{
		if (planet->name == name)
		{
			activePlanet = planet;
			return i;
		}
		i++;
	}
	activePlanet = NULL; 
	return -1; 
}

void SetActivePlanetID(int id)
{
	activePlanet = GetSolarSystem().GetPlanet(id);
}

double PlanetScaleX()
{
	if (activePlanet == NULL)
		return 0; 
	return activePlanet->radius;
}

double PlanetScaleY()
{
	if (activePlanet == NULL)
		return 0;
	return activePlanet->radius;
}

double PlanetScaleZ()
{
	if (activePlanet == NULL)
		return 0;
	return activePlanet->secondaryRadius;
}

void PlanetColor(Color&color)
{
	if (activePlanet == NULL)
		return;
	color.r = activePlanet->color.r;
	color.g = activePlanet->color.g;
	color.b = activePlanet->color.b;
	color.a = activePlanet->color.a; 
}

double EarthAxisTilt()
{
	Planet*earth = GetSolarSystem().Earth();
	if (earth == NULL)
		return 0;
	return earth->ObliquityToOrbit;
}

double PlanetRightAscension()
{
	if (activePlanet == NULL)
		return 0;
	return activePlanet->RightAscension; 
}

double PlanetDeclination()
{
	if (activePlanet == NULL)
		return 0;
	return activePlanet->Declination; 
}

void SetDaysSinceJ2000(double days)
{
	GetSolarSystem().SetTimeSinceJ2000(days);
}

double PlanetPositionX()
{
	if (activePlanet == NULL)
		return 0;
	return activePlanet->position.X;
}

double PlanetPositionY()
{
	if (activePlanet == NULL)
		return 0;
	return activePlanet->position.Y;
}

double PlanetPositionZ()
{
	if (activePlanet == NULL)
		return 0;
	return activePlanet->position.Z;
}

double PlanetRotation()
{
	if (activePlanet == NULL)
		return 0;
	return activePlanet->RotationAngleAt(GetSolarSystem().time);
}

void SetPlanetBaseRotation(int planetId, double x, double y, double z, double w)
{
	Planet* planet = GetSolarSystem().GetPlanet(planetId);
	if (planet->SynchronousRotation)
		return; 
	planet->rotationAxis = Quaternion(x, y, z, w); 
}

void SetPlanetRotationCalibration(int planetId, double calibration)
{
	GetSolarSystem().GetPlanet(planetId)->rotationCalibration = calibration;
}

void ClearFallingObjects()
{
	std::vector<GravityAffectedObject>*gravityObjects = &GetGravityObjectsIncludingDisposed();
	for (int i = 0; i<gravityObjects->size();i++)
		(*gravityObjects)[i].disposed = true;

	ReleaseGravityObjectsIncludingDisposed(); 
}

int AddFallingObject(Point3D*positions, Point3D*velocities, int pointCount)
{
	std::vector<GravityAffectedObject>* gravityObjects = &GetGravityObjectsIncludingDisposed(); 
	int id = gravityObjects->size();
	gravityObjects->push_back(GravityAffectedObject(positions, velocities, pointCount));
	ReleaseGravityObjectsIncludingDisposed(); 
	return id; 
}

void RemoveFallingObject(int id)
{
	GetGravityObjectsIncludingDisposed()[id].disposed = true;
	ReleaseGravityObjectsIncludingDisposed(); 
}

void Run(bool run)
{
	::run = run; 
}

void SetPauseTime(double pauseTime)
{
	::pauseTime = pauseTime; 
}

//run the simulation until run is set false. 
void Simulate()
{
	while (run)
	{
		if (GetSolarSystem().time >= pauseTime)
		{
			pausingAtTime = GetSolarSystem().time;
			Sleep(1); 
		}
		else
			AddTimeStep(GetTimeStep()); 
	}
}

//get information from simulation. 
double GetTime()
{
	return GetSolarSystem().time;
}

double PausingAt()
{
	if (!run)
		return GetSolarSystem().time; 

	return pausingAtTime; 
}

void EarthPositionAt(double daysSinceJ2000, Point3D&value)
{
	value = GetSolarSystem().Earth()->PositionByTime(daysSinceJ2000);
}

void PlanetPositionAt(int planetId, double daysSinceJ2000, Point3D& position)
{
	Point3D result;
	for (Planet* planet : GetSolarSystem().Planets())
	{
		if (planet == NULL)
			continue;
		if (planet->id == planetId)
		{
			result = planet->PositionByTime(daysSinceJ2000); 
			Planet*parent = planet; 
			while (parent->isMoonOf != NULL)
			{
				parent = parent->isMoonOf;
				result += planet->PositionByTime(daysSinceJ2000); 
			}
			break; 
		}
	}
	position = result; 
}
//Impacts
int GetImpactCount()
{
	return ImpactCount();
}

void GetImpact(int id, int& planetID, double& speed, double& time, Point3D& vector)
{
	struct Impact impact = GetImpact(id);
	planetID = impact.planetID;
	speed = impact.speed;
	time = impact.time;
	vector = impact.vector; 
}
	
void DrawImpactOn(int impactId, int generation, double scaledRadius, double maxValue, double* layer)
{
	struct Impact impact = GetImpact(impactId);
	GridCellEnumerator gridCellEnumerator(impact.vector, (unsigned short) generation);
	
	double part = scaledRadius / Pi() / 2;

	if (scaledRadius > Pi())
		scaledRadius = Pi();

	double boundarySquared = scaledRadius * scaledRadius; 


	int debugCount = GetGeodesicGrid(generation)->points.size(); 
	std::vector<int> debug(debugCount);

	while (gridCellEnumerator.MoveNext())
	{
		Point3D current = gridCellEnumerator.Point3D(); 
		double distanceSquared = (current - impact.vector).DistSquared(); 
		if (distanceSquared>boundarySquared)
		{
			gridCellEnumerator.SetFalse();
			continue; 
		}

		double ratio = distanceSquared / boundarySquared; 
		double value = (1 - ratio) * maxValue; 
		int index = gridCellEnumerator.Index(); 

		layer[index] += value; 

		debug[index]++;
		if (debug[index] > 1)
			int hold = 1; 
		
	}
}

void SetGravityThreshold(double threshold)
{
	GetSolarSystem().gravityThreshold = threshold; 
}