//Copyright Maarten 't Hart 2019
#include "stdafx.h"
#include "SolarSystem.h"

double undefined = 9999999;

Planet earth(6378.137, 6356.752315, 0.00981, "Earth");
Planet moon(1737.10, 1735.97, 0.00162, "Moon");
Planet mercury(2439.7, 2439.7, 0.0037, "Mercury");
Planet mars(3396.2, 3376.2, 0.00374, "Mars");
Planet venus(6051.8, 6051.8, 0.0087, "Venus");
Planet sun(696342, 696342, 0.247, "Sun");
Planet jupiter(71492, 66854, 0.02481, "Jupiter");
Planet saturn(60268, 54364,  0.01045, "Saturn");
Planet uranus(25559, 24973, 0.008683, "Uranus");
Planet neptune(24764, 24341, 0.00111, "Neptune");
Planet pluto(1195, 1195, 0.00058, "Pluto");

void CelestialBody::SetMercury()
{
	Mass = 0.3301*1.0e24;//kg
	Volume = 6.083*1.0e10;//km3
	EquatorialRadius = 2439.7;//km
	PolarRadius = 2439.7;//km
	VolumetricMeanRadius = 2439.7;//km
	Ellipticity = 0;//flattening
	MeanDensity = 5427;//kg/m3
	SurfaceGravity = 3.7;//m/s2
	SurfaceAccelleration = 3.7;//m/s2
	EscapeVelocity = 4.3;//km/s
	GM = 0.02203*1.0e6;//km3/s2

	SemiMajorAxis = 57.91*1.0e6;//km
	SiderealOrbitPeriod = 87.969;//days
	TropicalOrbitPeriod = 87.968;//days
	Periapsis = 46 * 1.0e6;//km
	Apoapsis = 69.82*1.0e6;//km
	SynodicPeriod = 115.88;//days
	MeanOrbitalVelocity = 47.36;//km/s
	MaxOrbitalVelocity = 58.98;//km/s
	MinOrbitalVelocity = 38.86;//km/s
	SiderealRotationPeriod = 1407.6;//hrs
	LenghtOfDay = 4222.6;//hrs
	ObliquityToOrbit = 0.034;//deg

	OrbitalEccentricity = 0.20563069;
	OrbitalInclination = 7.00487;//deg
	LongitudeOfAscendingNode = 48.33167;//deg
	LongitudeOfPeriapsis = 77.45645;//deg
	MeanLongitude = 252.25084;//deg

	RightAscension = 281.01;
	Declination = 61.416;
	TimeOfPeriapsis = DaysSinceJ2000(2015, 1, 21, 20, 33, 0);

	color = Color(158.f / 255, 136.f / 255, 99.f / 255, 1.0f);
}

void CelestialBody::SetVenus()
{
	Mass = 4.8676*1.0e24;//kg
	Volume = 92.843*1.0e10;//km3
	EquatorialRadius = 6051.8;//km
	PolarRadius = 6051.8;//km
	VolumetricMeanRadius = 6051.8;//km
	Ellipticity = 0;//flattening
	MeanDensity = 5243;//kg/m3
	SurfaceGravity = 8.87;//m/s2
	SurfaceAccelleration = 8.87;//m/s2
	EscapeVelocity = 10.36;//km/s
	GM = 0.3249*1.0e6;//km3/s2

	SemiMajorAxis = 108.21*1.0e6;//km
	SiderealOrbitPeriod = 224.701;//days
	TropicalOrbitPeriod = 224.695;//days
	Periapsis = 107.48*1.0e6;//km
	Apoapsis = 108.94*1.0e6;//km
	SynodicPeriod = 583.92;//days
	MeanOrbitalVelocity = 35.02;//km/s
	MaxOrbitalVelocity = 35.26;//km/s
	MinOrbitalVelocity = 34.79;//km/s
	SiderealRotationPeriod = -5832.6;//hrs
	LenghtOfDay = 2802;//hrs
	ObliquityToOrbit = 177.36;//deg

	OrbitalEccentricity = 0.00677323;
	OrbitalInclination = 3.39471;//deg
	LongitudeOfAscendingNode = 76.68069;//deg
	LongitudeOfPeriapsis = 131.53298;//deg
	MeanLongitude = 181.97973;//deg

	RightAscension = 272.76;
	Declination = 67.16;
	TimeOfPeriapsis = DaysSinceJ2000(2015, 4, 18, 9, 15, 0);
	color = Color(250.f / 255, 221.f / 255, 124.f / 255, 1.0f);
}

void CelestialBody::SetEarth()
{
	Mass = 5.9726*1.0e24;//kg
	Volume = 108.321*1.0e10;//km3
	EquatorialRadius = 6378.1;//km
	PolarRadius = 6356.8;//km
	VolumetricMeanRadius = 6371;//km
	Ellipticity = 0.00335;//flattening
	MeanDensity = 5514;//kg/m3
	SurfaceGravity = 9.798;//m/s2
	SurfaceAccelleration = 9.78;//m/s2
	EscapeVelocity = 11.186;//km/s
	GM = 0.3986*1.0e6;//km3/s2

	SemiMajorAxis = 149.6*1.0e6;//km
	SiderealOrbitPeriod = 365.256;//days
	TropicalOrbitPeriod = 365.242;//days
	Periapsis = 147.09*1.0e6;//km
	Apoapsis = 152.1*1.0e6;//km
	SynodicPeriod = 0;//days
	MeanOrbitalVelocity = 29.78;//km/s
	MaxOrbitalVelocity = 30.29;//km/s
	MinOrbitalVelocity = 29.29;//km/s
	SiderealRotationPeriod = 23.9345;//hrs
	LenghtOfDay = 24;//hrs
	ObliquityToOrbit = 23.44;//deg

	OrbitalEccentricity = 0.01671022;
	OrbitalInclination = 0.00005;//deg
	LongitudeOfAscendingNode = -11.26064;//deg
	LongitudeOfPeriapsis = 102.94719;//deg
	MeanLongitude = 100.46435;//deg

	RightAscension = 0;
	Declination = 90;
	TimeOfPeriapsis = DaysSinceJ2000(2016, 1, 2, 22, 49, 0);
	color = Color(133.f / 255, 137.f / 255, 168.f / 255, 1.0f);
}

void CelestialBody::SetMoon()
{
	Mass = 0.07342*1.0e24;//kg
	Volume = 2.1958*1.0e10;//km3
	EquatorialRadius = 1738.1;//km
	PolarRadius = 1736;//km
	VolumetricMeanRadius = 1737.1;//km
	Ellipticity = 0.0012;//flattening
	MeanDensity = 3344;//kg/m3
	SurfaceGravity = 1.62;//m/s2
	SurfaceAccelleration = 1.62;//m/s2
	EscapeVelocity = 2.38;//km/s
	GM = 0.0049*1.0e6;//km3/s2

	SemiMajorAxis = 0.3844*1.0e6;//km
	SiderealOrbitPeriod = 27.3217;//days
	//TropicalOrbitPeriod=0.4055;//days
	Periapsis = 0.3633*1.0e6;//km
	Apoapsis = 0.4055*1.0e6;//km
	SynodicPeriod = 29.53;//days
	MeanOrbitalVelocity = 1.022;//km/s
	MaxOrbitalVelocity = 1.076;//km/s
	MinOrbitalVelocity = 0.964;//km/s
	OrbitalInclination = 5.145;//deg
	OrbitalEccentricity = 0.0549;
	SiderealRotationPeriod = 655.728;//hrs
	LenghtOfDay = undefined;//hrs
	ObliquityToOrbit = 6.68;//deg

	LongitudeOfAscendingNode = undefined;//deg
	LongitudeOfPeriapsis = undefined;//deg
	MeanLongitude = undefined;//deg

	RightAscension = undefined;
	Declination = undefined;
	TimeOfPeriapsis = DaysSinceJ2000(2015, 8, 2, 10, 4, 0);
	color = Color(189.f / 255, 182.f / 255, 180.f / 255, 1.0f);
}

void CelestialBody::SetMars()
{
	Mass = 0.64174*1.0e24;//kg
	Volume = 16.318*1.0e10;//km3
	EquatorialRadius = 3396.2;//km
	PolarRadius = 3376.2;//km
	VolumetricMeanRadius = 3389.5;//km
	Ellipticity = 0.00589;//flattening
	MeanDensity = 3933;//kg/m3
	SurfaceGravity = 3.71;//m/s2
	SurfaceAccelleration = 3.69;//m/s2
	EscapeVelocity = 5.03;//km/s
	GM = 0.04283*1.0e6;//km3/s2

	SemiMajorAxis = 227.92*1.0e6;//km
	SiderealOrbitPeriod = 686.98;//days
	TropicalOrbitPeriod = 686.973;//days
	Periapsis = 206.62*1.0e6;//km
	Apoapsis = 249.23*1.0e6;//km
	SynodicPeriod = 779.94;//days
	MeanOrbitalVelocity = 24.07;//km/s
	MaxOrbitalVelocity = 26.5;//km/s
	MinOrbitalVelocity = 21.97;//km/s
	OrbitalInclination = 1.85;//deg
	OrbitalEccentricity = 0.0935;
	SiderealRotationPeriod = 24.6229;//hrs
	LenghtOfDay = 24.6597;//hrs
	ObliquityToOrbit = 25.19;//deg

	OrbitalEccentricity = 0.09341233;
	OrbitalInclination = 1.85061;//deg
	LongitudeOfAscendingNode = 49.57854;//deg
	LongitudeOfPeriapsis = 336.04084;//deg
	MeanLongitude = 355.45332;//deg

	RightAscension = 317.681;
	Declination = 52.887;
	TimeOfPeriapsis = DaysSinceJ2000(2016, 10, 29, 13, 13, 0);
	color = Color(212.f / 255, 145.f / 255, 118.f / 255, 1.0f);
}

void CelestialBody::SetJupiter()
{
	Mass = 1898.3*1.0e24;//kg
	Volume = 143128 * 1.0e10;//km3
	EquatorialRadius = 71492;//km
	PolarRadius = 66854;//km
	VolumetricMeanRadius = 69911;//km
	Ellipticity = 0.06487;//flattening
	MeanDensity = 1326;//kg/m3
	SurfaceGravity = 24.79;//m/s2
	SurfaceAccelleration = 23.12;//m/s2
	EscapeVelocity = 59.5;//km/s
	GM = 126.687*1.0e6;//km3/s2

	SemiMajorAxis = 778.57*1.0e6;//km
	SiderealOrbitPeriod = 4332.589;//days
	TropicalOrbitPeriod = 4330.595;//days
	Periapsis = 740.52*1.0e6;//km
	Apoapsis = 816.62*1.0e6;//km
	SynodicPeriod = 398.88;//days
	MeanOrbitalVelocity = 13.06;//km/s
	MaxOrbitalVelocity = 13.72;//km/s
	MinOrbitalVelocity = 12.44;//km/s
	SiderealRotationPeriod = 9.925;//hrs
	LenghtOfDay = 9.9259;//hrs
	ObliquityToOrbit = 3.13;//deg

	OrbitalEccentricity = 0.04839266;
	OrbitalInclination = 1.3053;//deg
	LongitudeOfAscendingNode = 100.55615;//deg
	LongitudeOfPeriapsis = 14.75385;//deg
	MeanLongitude = 34.40438;//deg

	RightAscension = 268.05;
	Declination = 64.49;
	TimeOfPeriapsis = DaysSinceJ2000(2023, 1, 20, 11, 42, 0);
	color = Color(197.f / 255, 183.f / 255, 154.f / 255, 1.0f);
}

void CelestialBody::SetSaturn()
{
	Mass = 568.36*1.0e24;//kg
	Volume = 82713 * 1.0e10;//km3
	EquatorialRadius = 60268;//km
	PolarRadius = 54364;//km
	VolumetricMeanRadius = 58232;//km
	Ellipticity = 0.09796;//flattening
	MeanDensity = 687;//kg/m3
	SurfaceGravity = 10.44;//m/s2
	SurfaceAccelleration = 8.96;//m/s2
	EscapeVelocity = 35.5;//km/s
	GM = 37.931*1.0e6;//km3/s2

	SemiMajorAxis = 1433.53*1.0e6;//km
	SiderealOrbitPeriod = 10759.22;//days
	TropicalOrbitPeriod = 10746.94;//days
	Periapsis = 1352.55*1.0e6;//km
	Apoapsis = 1514.5*1.0e6;//km
	SynodicPeriod = 378.09;//days
	MeanOrbitalVelocity = 9.68;//km/s
	MaxOrbitalVelocity = 10.18;//km/s
	MinOrbitalVelocity = 9.09;//km/s
	SiderealRotationPeriod = 10.656;//hrs
	LenghtOfDay = 10.656;//hrs
	ObliquityToOrbit = 26.73;//deg

	OrbitalEccentricity = 0.0541506;
	OrbitalInclination = 2.48446;//deg
	LongitudeOfAscendingNode = 113.71504;//deg
	LongitudeOfPeriapsis = 92.43194;//deg
	MeanLongitude = 49.94432;//deg

	RightAscension = 40.5954;
	Declination = 83.538;
	TimeOfPeriapsis = DaysSinceJ2000(2018, 4, 17, 11, 32, 0);
	color = Color(248.f / 255, 191.f / 255, 77.f / 255, 1.0f);
}

void CelestialBody::SetUranus()
{
	Mass = 86.816*1.0e24;//kg
	Volume = 6833 * 1.0e10;//km3
	EquatorialRadius = 25559;//km
	PolarRadius = 24973;//km
	VolumetricMeanRadius = 25362;//km
	Ellipticity = 0.02293;//flattening
	MeanDensity = 1271;//kg/m3
	SurfaceGravity = 8.87;//m/s2
	SurfaceAccelleration = 8.69;//m/s2
	EscapeVelocity = 21.3;//km/s
	GM = 5.794*1.0e6;//km3/s2

	SemiMajorAxis = 2872.46*1.0e6;//km
	SiderealOrbitPeriod = 30685.4;//days
	TropicalOrbitPeriod = 30588.74;//days
	Periapsis = 2741.3*1.0e6;//km
	Apoapsis = 3003.62*1.0e6;//km
	SynodicPeriod = 369.66;//days
	MeanOrbitalVelocity = 6.8;//km/s
	MaxOrbitalVelocity = 7.11;//km/s
	MinOrbitalVelocity = 6.49;//km/s
	SiderealRotationPeriod = -17.24;//hrs
	LenghtOfDay = 17.24;//hrs
	ObliquityToOrbit = 97.77;//deg

	OrbitalEccentricity = 0.04716771;
	OrbitalInclination = 0.76986;//deg
	LongitudeOfAscendingNode = 74.22988;//deg
	LongitudeOfPeriapsis = 170.96424;//deg
	MeanLongitude = 313.23218;//deg

	RightAscension = 257.43;
	Declination = -15.1;
	TimeOfPeriapsis = DaysSinceJ2000(2009, 2, 27, 0, 23, 0);
	color = Color(67.f / 255, 170.f / 255, 216.f / 255, 1.0f);
}

void CelestialBody::SetNeptune()
{
	Mass = 102.42*1.0e24;//kg
	Volume = 6254 * 1.0e10;//km3
	EquatorialRadius = 24764;//km
	PolarRadius = 24341;//km
	VolumetricMeanRadius = 24622;//km
	Ellipticity = 0.01708;//flattening
	MeanDensity = 1638;//kg/m3
	SurfaceGravity = 11.15;//m/s2
	SurfaceAccelleration = 11;//m/s2
	EscapeVelocity = 23.5;//km/s
	GM = 6.8351*1.0e6;//km3/s2

	SemiMajorAxis = 4495.06*1.0e6;//km
	SiderealOrbitPeriod = 60189;//days
	TropicalOrbitPeriod = 59799.9;//days
	Periapsis = 4444.45*1.0e6;//km
	Apoapsis = 4545.67*1.0e6;//km
	SynodicPeriod = 367.49;//days
	MeanOrbitalVelocity = 5.43;//km/s
	MaxOrbitalVelocity = 5.5;//km/s
	MinOrbitalVelocity = 5.37;//km/s
	SiderealRotationPeriod = 16.11;//hrs
	LenghtOfDay = 16.11;//hrs
	ObliquityToOrbit = 28.32;//deg

	OrbitalEccentricity = 0.00858587;
	OrbitalInclination = 1.76917;//deg
	LongitudeOfAscendingNode = 131.72169;//deg
	LongitudeOfPeriapsis = 44.97135;//deg
	MeanLongitude = 304.88003;//deg

	RightAscension = 299.36;
	Declination = 43.46;
	TimeOfPeriapsis = DaysSinceJ2000(2030, 3, 1, 0, 0, 0);//not very precise...
	color = Color(69.f / 255, 117.f / 255, 251.f / 255, 1.0f);
}

void CelestialBody::SetPluto()
{
	Mass = 0.0131*1.0e24;//kg
	Volume = 0.715*1.0e10;//km3
	EquatorialRadius = 1195;//km
	PolarRadius = 1195;//km
	VolumetricMeanRadius = 1195;//km
	Ellipticity = 0;//flattening
	MeanDensity = 1830;//kg/m3
	SurfaceGravity = 0.58;//m/s2
	SurfaceAccelleration = 0.58;//m/s2
	EscapeVelocity = 1.2;//km/s
	GM = 0.00087*1.0e6;//km3/s2

	SemiMajorAxis = 5906.38*1.0e6;//km
	SiderealOrbitPeriod = 90465;//days
	TropicalOrbitPeriod = 90588;//days
	Periapsis = 4436.82*1.0e6;//km
	Apoapsis = 7375.93*1.0e6;//km
	SynodicPeriod = 366.73;//days
	MeanOrbitalVelocity = 4.67;//km/s
	MaxOrbitalVelocity = 6.1;//km/s
	MinOrbitalVelocity = 3.71;//km/s
	SiderealRotationPeriod = -153.2928;//hrs
	LenghtOfDay = 153.282;//hrs
	ObliquityToOrbit = 122.53;//deg

	OrbitalEccentricity = 0.24880766;
	OrbitalInclination = 17.14175;//deg
	LongitudeOfAscendingNode = 110.30347;//deg
	LongitudeOfPeriapsis = 224.06676;//deg
	MeanLongitude = 238.92881;//deg

	RightAscension = 132.99;
	Declination = -6.16;
	TimeOfPeriapsis = DaysSinceJ2000(2098, 4, 1, 0, 0, 0); //not very precise. 
	color = Color(247.f / 255, 202.f / 255, 161.f / 255, 1.0f);
}

void CelestialBody::SetSun()
{
	Mass = 1.98855*1.0e30;//kg
	Volume = 1.409*1.0e18;//km3
	EquatorialRadius = 696342;//km
	PolarRadius = 696332;//km
	VolumetricMeanRadius = 696338;//km
	Ellipticity = 0;//flattening
	MeanDensity = 1408;//kg/m3
	SurfaceGravity = 274.0;//m/s2
	SurfaceAccelleration = 274.0;//m/s2
	EscapeVelocity = 617.6;//km/s
	GM = 132712 * 1.0e6;//km3/s2

	SemiMajorAxis = 0;//km
	SiderealOrbitPeriod = 0;//days
	TropicalOrbitPeriod = 0;//days
	Periapsis = 0;//km
	Apoapsis = 0;//km
	SynodicPeriod = 1;//days
	MeanOrbitalVelocity = 0;//km/s
	MaxOrbitalVelocity = 0;//km/s
	MinOrbitalVelocity = 0;//km/s
	SiderealRotationPeriod = 609.12;//hrs
	LenghtOfDay = 0;//hrs
	ObliquityToOrbit = 7.25;//deg

	OrbitalEccentricity = 0;
	OrbitalInclination = 0;//deg
	LongitudeOfAscendingNode = 0;//deg
	LongitudeOfPeriapsis = 0;//deg
	MeanLongitude = 0;//deg

	RightAscension = 0;
	Declination = 0;
	TimeOfPeriapsis = DaysSinceJ2000(2000, 1, 1, 0, 0, 0); //not very precise. 
	color = Color(255.f / 255, 255.f / 255, 155.f / 255, 1.0f);
}

SolarSystem::SolarSystem()
{
	earth.SetEarth();
	moon.SetMoon();
	mercury.SetMercury();
	mars.SetMars();
	venus.SetVenus();
	jupiter.SetJupiter();
	saturn.SetSaturn();
	uranus.SetUranus();
	neptune.SetNeptune();
	pluto.SetPluto();
	sun.SetSun();
	sun.isSun = true;
	moon.isMoon = true;
	for (Planet*planet : Planets())
	{
		planet->LoadCelestialBodyOrbit();
	}
}

Planet & SolarSystem::Earth()
{
	return earth; 
}

Planet & SolarSystem::Venus()
{
	return venus; 
}

Planet & SolarSystem::Mercury()
{
	return mercury; 
}

Planet & SolarSystem::Mars()
{
	return mars;
}

Planet & SolarSystem::Moon()
{
	return moon; 
}

Planet & SolarSystem::Jupiter()
{
	return jupiter; 
}

Planet & SolarSystem::Saturn()
{
	return saturn; 
}

Planet & SolarSystem::Neptune()
{
	return neptune; 
}

Planet & SolarSystem::Uranus()
{
	return uranus; 
}

Planet & SolarSystem::Pluto()
{
	return pluto;
}

Planet & SolarSystem::Sun()
{
	return sun; 
}

std::vector<Planet*> SolarSystem::Planets() 
{
	return std::vector<Planet*>
	{
		&Earth(),
		&Venus(),
		&Mercury(),
		&Mars(),
		&Moon(),
		&Jupiter(),
		&Saturn(),
		&Neptune(),
		&Uranus(),
		&Pluto(),
		&Sun()
	};
}

void SolarSystem::SetTimeSinceJ2000(double days)
{
	Point3D moonPos;
	for (Planet*planet : Planets())
	{
		if (planet->isMoon)
			moonPos = planet->PositionByTime(days);
		else if (planet->isSun)
			planet->position = Point3D(0, 0, 0);
		else
			planet->position = planet->PositionByTime(days);
	}
	//sun is always at 0. 
	Sun().position = 0;
	Moon().position = moonPos + Earth().position;
}