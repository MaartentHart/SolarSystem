//Copyright Maarten 't Hart 2019
#include "stdafx.h"
#include "SolarSystem.h"

//sources:
//http://extras.springer.com/2009/978-3-540-88054-7/16_vi4b_422.pdf
//https://nssdc.gsfc.nasa.gov/planetary/factsheet/
//https://nssdc.gsfc.nasa.gov/planetary/factsheet/sunfact.html
//https://nssdc.gsfc.nasa.gov/planetary/factsheet/asteroidfact.html

//notes:
//if apoapsis and periapsis are unknown, they can be calculated using the eccentricity and the semi major axis
//SemiminorAxis = SemiMajorAxis * sqrt(1-Eccentricity*Eccentricity)
//FocalDistance = sqrt(SemiMajorAxis*SemiMajorAxis-SemiMinorAxis*SemiMinorAxis
//Apoapsis = SemiMajorAxis+FocalDistance
//Periapsis = SemiMajorAxis-FocalDistance

//double undefined = std::numeric_limits<double>::quiet_NaN();
std::vector<Planet*> planets; 

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

//Jupiters moons
Planet io(1821.5, 1821.5,0.001796,"Io");
Planet europa(1560.8, 1560.8,0.001315,"Europa");
Planet ganymede(2631.2, 2631.2,0.001428,"Ganymede");
Planet callisto(2410.3, 2410.3,0.001236,"Callisto");

//Saturns moons
Planet titan(2575, 2575, 0.001352,"Titan");
Planet mimas(208,197,0.000064,"Mimas");
Planet enceladus(257,251,0.000113,"Enceladus");
Planet tethys(538,528,0.000145,"Tethys");
Planet dione(563,561,0.000232,"Dione");
Planet rhea(765,763,0.000264,"Rhea");
Planet hyperion(180,133,0.00002,"Hyperion");
Planet iapetus(746,746,0.000223,"Iapetus");

//Uranus moons
Planet miranda(240,243.2,0.000079,"Miranda");
Planet ariel(581.1,557.9,0.000269,"Ariel");
Planet umbriel(584.7,584.7,0.0002,"Umbriel");
Planet titania(788.9,788.9,0.000367,"Titania");
Planet oberon(761.4,761.4,0.000346,"Oberon");

//Neptunes moons
Planet triton(1353.4, 1353.4, 0.000779, "Triton");

//Plutos moon
Planet charon(606,606,0.00029,"Charon");

//Other
Planet ceres(965, 961, 0.00027, "Ceres");
Planet pallas(582, 556, 0.00022, "Pallas");
Planet vesta(569, 555, 0.00022, "Vesta");

CelestialBody::CelestialBody() 
{
	memset(this, 0, sizeof(this)); 
}

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
	LenghtOfDay = 0;// undefined;//hrs
	ObliquityToOrbit = 6.68;//deg

	LongitudeOfAscendingNode = 0;// undefined;//deg
	LongitudeOfPeriapsis = 0;// undefined;//deg
	MeanLongitude = 0;// undefined;//deg

	RightAscension = 0;// undefined;
	Declination = 90;// undefined;
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
	color = Color(255.f / 255, 255.f / 255, 255.f / 255, 1.0f);
}

//Jupiters moons
void CelestialBody::SetIo()
{
	Mass = 893.2;//kg
	Volume = 25314895329.748;//km3
	EquatorialRadius = 1821.5;//km
	PolarRadius = 1821.5;//km
	VolumetricMeanRadius = 1821.5;//km
	Ellipticity = 0;//flattening
	MeanDensity = 3530;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 421.8;//km
	SiderealOrbitPeriod = 1.769138;//days
	TropicalOrbitPeriod = 1.769138;//days
	Periapsis = 420112.799999985;//km
	Apoapsis = 423487.200000015;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.004;// - Undefined
	OrbitalInclination = 0.04;//deg
	LongitudeOfAscendingNode = 43.977;//deg
	LongitudeOfPeriapsis = 128.106;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.62f, 0.62f, 0.62f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetEuropa()
{
	Mass = 480;//kg
	Volume = 15926867918.1251;//km3
	EquatorialRadius = 1560.8;//km
	PolarRadius = 1560.8;//km
	VolumetricMeanRadius = 1560.8;//km
	Ellipticity = 0;//flattening
	MeanDensity = 3010;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 671.1;//km
	SiderealOrbitPeriod = 3.551181;//days
	TropicalOrbitPeriod = 3.551181;//days
	Periapsis = 665060.100000004;//km
	Apoapsis = 677139.899999996;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.009;// - Undefined
	OrbitalInclination = 0.47;//deg
	LongitudeOfAscendingNode = 219.106;//deg - Undefined
	LongitudeOfPeriapsis = 308.076;//deg - Undefined
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.68f, 0.68f, 0.68f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetGanymede()
{
	Mass = 1481.9;//kg
	Volume = 76304506997.7707;//km3
	EquatorialRadius = 2631.2;//km
	PolarRadius = 2631.2;//km
	VolumetricMeanRadius = 2631.2;//km
	Ellipticity = 0;//flattening
	MeanDensity = 1940;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 1070.4;//km
	SiderealOrbitPeriod = 7.154553;//days
	TropicalOrbitPeriod = 7.154553;//days
	Periapsis = 1069329.60000004;//km 
	Apoapsis = 1071470.39999996;//km 
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.001;// - Undefined
	OrbitalInclination = 0.18;//deg
	LongitudeOfAscendingNode = 63.552;//deg
	LongitudeOfPeriapsis = 255.969;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.44f, 0.44f, 0.44f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetCallisto(){
	Mass = 1075.9;//kg
	Volume = 58654577603.0003;//km3
	EquatorialRadius = 2410.3;//km
	PolarRadius = 2410.3;//km
	VolumetricMeanRadius = 2410.3;//km
	Ellipticity = 0;//flattening
	MeanDensity = 1830;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 1882.7;//km
	SiderealOrbitPeriod = 16.689017;//days
	TropicalOrbitPeriod = 16.689017;//days
	Periapsis = 1869521.09999999;//km
	Apoapsis = 1895878.90000001;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.007;// - Undefined
	OrbitalInclination = 0.19;//deg
	LongitudeOfAscendingNode = 298.848;//deg
	LongitudeOfPeriapsis = 351.491;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.19f, 0.19f, 0.19f, 1.0f);
	SynchronousRotation = true;
}

//Saturns moons
void CelestialBody::SetTitan()
{
	Mass = 1345.5;//kg
	Volume = 0;//km3
	EquatorialRadius = 2575;//km
	PolarRadius = 0;//km
	VolumetricMeanRadius = 1716.66666666667;//km
	Ellipticity = 1;//flattening
	MeanDensity = 1880;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 1221.83;//km
	SiderealOrbitPeriod = 15.945421;//days
	TropicalOrbitPeriod = 15.945421;//days
	Periapsis = 1186152.564;//km
	Apoapsis = 1257507.436;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0292;// - Undefined
	OrbitalInclination = 0.33;//deg
	LongitudeOfAscendingNode = 24.502;//deg
	LongitudeOfPeriapsis = 210.173;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.22f, 0.22f, 0.22f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetMimas()
{
	Mass = 0.379;//kg
	Volume = 35701092.425716;//km3
	EquatorialRadius = 208;//km
	PolarRadius = 197;//km
	VolumetricMeanRadius = 204.333333333333;//km
	Ellipticity = 0.0528846153846154;//flattening
	MeanDensity = 1150;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 185.52;//km
	SiderealOrbitPeriod = 0.9424218;//days
	TropicalOrbitPeriod = 0.9424218;//days
	Periapsis = 181772.496000001;//km
	Apoapsis = 189267.503999999;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0202;// - Undefined
	OrbitalInclination = 1.53;//deg
	LongitudeOfAscendingNode = 153.152;//deg
	LongitudeOfPeriapsis = 167.504;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.6f, 0.6f, 0.6f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetEnceladus()
{
	Mass = 1.08;//kg
	Volume = 69443016.46322;//km3
	EquatorialRadius = 257;//km
	PolarRadius = 251;//km
	VolumetricMeanRadius = 255;//km
	Ellipticity = 0.0233463035019456;//flattening
	MeanDensity = 1610;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 238.02;//km
	SiderealOrbitPeriod = 1.370218;//days
	TropicalOrbitPeriod = 1.370218;//days
	Periapsis = 236948.910000001;//km
	Apoapsis = 239091.089999999;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0045;// - Undefined
	OrbitalInclination = 0;//deg
	LongitudeOfAscendingNode = 93.204;//deg
	LongitudeOfPeriapsis = 305.127;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(1.0f, 1.0f, 1.0f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetTethys()
{
	Mass = 6.18;//kg
	Volume = 640157861.394053;//km3
	EquatorialRadius = 538;//km
	PolarRadius = 528;//km
	VolumetricMeanRadius = 534.666666666667;//km
	Ellipticity = 0.0185873605947955;//flattening
	MeanDensity = 985;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 294.66;//km
	SiderealOrbitPeriod = 1.887802;//days
	TropicalOrbitPeriod = 1.887802;//days
	Periapsis = 294660;//km
	Apoapsis = 294660;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0;// - Undefined
	OrbitalInclination = 1.86;//deg
	LongitudeOfAscendingNode = 330.882;//deg
	LongitudeOfPeriapsis = 593.727;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.8f, 0.8f, 0.8f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetDione()
{
	Mass = 11;//kg
	Volume = 744849036.398146;//km3
	EquatorialRadius = 563;//km
	PolarRadius = 561;//km
	VolumetricMeanRadius = 562.333333333333;//km
	Ellipticity = 0.00355239786856132;//flattening
	MeanDensity = 1480;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 377.4;//km
	SiderealOrbitPeriod = 2.736915;//days
	TropicalOrbitPeriod = 2.736915;//days
	Periapsis = 376569.719999998;//km
	Apoapsis = 378230.280000002;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0022;// - Undefined
	OrbitalInclination = 0.02;//deg
	LongitudeOfAscendingNode = 168.909;//deg
	LongitudeOfPeriapsis = 337.729;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.7f, 0.7f, 0.7f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetRhea()
{
	Mass = 23.1;//kg
	Volume = 1870406562.41584;//km3
	EquatorialRadius = 765;//km
	PolarRadius = 763;//km
	VolumetricMeanRadius = 764.333333333333;//km
	Ellipticity = 0.00261437908496731;//flattening
	MeanDensity = 1240;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 527.04;//km
	SiderealOrbitPeriod = 4.5175;//days
	TropicalOrbitPeriod = 4.5175;//days
	Periapsis = 526512.959999966;//km
	Apoapsis = 527567.040000034;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.001;// - Undefined
	OrbitalInclination = 0.35;//deg
	LongitudeOfAscendingNode = 311.531;//deg
	LongitudeOfPeriapsis = 568.14;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.7f, 0.7f, 0.7f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetHyperion()
{
	Mass = 0.056;//kg
	Volume = 18050334.7504655;//km3
	EquatorialRadius = 180;//km
	PolarRadius = 133;//km
	VolumetricMeanRadius = 164.333333333333;//km
	Ellipticity = 0.261111111111111;//flattening
	MeanDensity = 550;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 1481.1;//km
	SiderealOrbitPeriod = 21.276609;//days
	TropicalOrbitPeriod = 21.276609;//days
	Periapsis = 1326769.38;//km
	Apoapsis = 1635430.62;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.1042;// - Undefined
	OrbitalInclination = 0.43;//deg
	LongitudeOfAscendingNode = 264.022;//deg
	LongitudeOfPeriapsis = 588.205;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.3f, 0.3f, 0.3f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetIapetus()
{
	Mass = 18.1;//kg
	Volume = 1739022062.12675;//km3
	EquatorialRadius = 746;//km
	PolarRadius = 746;//km
	VolumetricMeanRadius = 746;//km
	Ellipticity = 0;//flattening
	MeanDensity = 1090;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 3561.3;//km
	SiderealOrbitPeriod = 79.330183;//days
	TropicalOrbitPeriod = 79.330183;//days
	Periapsis = 3460515.21;//km
	Apoapsis = 3662084.79;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0283;// - Undefined
	OrbitalInclination = 14.72;//deg
	LongitudeOfAscendingNode = 75.831;//deg
	LongitudeOfPeriapsis = 351.752;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.05 / 0.5f, 0.05 / 0.5f, 0.05 / 0.5f, 1.0f);
	SynchronousRotation = true;
}

//Uranus moons
void CelestialBody::SetMiranda()
{
	Mass = 0.66;//kg
	Volume = 56506444.759352;//km3
	EquatorialRadius = 240;//km
	PolarRadius = 234.2;//km
	VolumetricMeanRadius = 238.066666666667;//km
	Ellipticity = 0.0241666666666667;//flattening
	MeanDensity = 1200;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 129.9;//km
	SiderealOrbitPeriod = 1.413479;//days
	TropicalOrbitPeriod = 1.413479;//days
	Periapsis = 129731.130000005;//km
	Apoapsis = 130068.869999995;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0013;// - Undefined
	OrbitalInclination = 4.34;//deg
	LongitudeOfAscendingNode = 326.438;//deg
	LongitudeOfPeriapsis = 394.75;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.32f, 0.32f, 0.32f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetAriel()
{
	Mass = 12.9;//kg
	Volume = 817415850.105788;//km3
	EquatorialRadius = 581.1;//km
	PolarRadius = 577.9;//km
	VolumetricMeanRadius = 580.033333333333;//km
	Ellipticity = 0.00550679745310623;//flattening
	MeanDensity = 1590;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 190.9;//km
	SiderealOrbitPeriod = 2.520379;//days
	TropicalOrbitPeriod = 2.520379;//days
	Periapsis = 190670.919999982;//km
	Apoapsis = 191129.080000018;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0012;// - Undefined
	OrbitalInclination = 0.04;//deg
	LongitudeOfAscendingNode = 22.394;//deg
	LongitudeOfPeriapsis = 137.743;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.39f, 0.39f, 0.39f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetUmbriel()
{
	Mass = 12.2;//kg
	Volume = 837313109.433584;//km3
	EquatorialRadius = 584.7;//km
	PolarRadius = 584.7;//km
	VolumetricMeanRadius = 584.7;//km
	Ellipticity = 0;//flattening
	MeanDensity = 1460;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 266;//km
	SiderealOrbitPeriod = 4.144176;//days
	TropicalOrbitPeriod = 4.144176;//days
	Periapsis = 264962.599999987;//km
	Apoapsis = 267037.400000013;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0039;// - Undefined
	OrbitalInclination = 0.13;//deg
	LongitudeOfAscendingNode = 33.485;//deg
	LongitudeOfPeriapsis = 118.194;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.21f, 0.21f, 0.21f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetTitania()
{
	Mass = 34.2;//kg
	Volume = 2056622001.3056;//km3
	EquatorialRadius = 788.9;//km
	PolarRadius = 788.9;//km
	VolumetricMeanRadius = 788.9;//km
	Ellipticity = 0;//flattening
	MeanDensity = 1660;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 436.3;//km
	SiderealOrbitPeriod = 8.705867;//days
	TropicalOrbitPeriod = 8.705867;//days
	Periapsis = 435820.070000028;//km
	Apoapsis = 436779.929999972;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0011;// - Undefined
	OrbitalInclination = 0.08;//deg
	LongitudeOfAscendingNode = 99.771;//deg
	LongitudeOfPeriapsis = 384.171;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.27f, 0.27f, 0.27f, 1.0f);
	SynchronousRotation = true;
}

void CelestialBody::SetOberon()
{
	Mass = 28.8;//kg
	Volume = 1848958769.22961;//km3
	EquatorialRadius = 761.4;//km
	PolarRadius = 761.4;//km
	VolumetricMeanRadius = 761.4;//km
	Ellipticity = 0;//flattening
	MeanDensity = 1560;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 583.5;//km
	SiderealOrbitPeriod = 13.463234;//days
	TropicalOrbitPeriod = 13.463234;//days
	Periapsis = 582683.099999962;//km
	Apoapsis = 584316.900000038;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.0014;// - Undefined
	OrbitalInclination = 0.07;//deg
	LongitudeOfAscendingNode = 279.771;//deg
	LongitudeOfPeriapsis = 384.171;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.23f, 0.23f, 0.23f, 1.0f);
	SynchronousRotation = true;
}

//Neptunes moons
void CelestialBody::SetTriton()
{
	Mass = 214;//kg
	Volume = 10384058491.0292;//km3
	EquatorialRadius = 1353.4;//km
	PolarRadius = 1353.4;//km
	VolumetricMeanRadius = 1353.4;//km
	Ellipticity = 0;//flattening
	MeanDensity = 2050;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 354.76;//km
	SiderealOrbitPeriod = -5.876854;//days
	TropicalOrbitPeriod = -5.876854;//days
	Periapsis = 354754.323838143;//km
	Apoapsis = 354765.676161857;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0.000016;// - Undefined
	OrbitalInclination = 157.345;//deg
	LongitudeOfAscendingNode = 172.431;//deg
	LongitudeOfPeriapsis = 516.477;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.72f, 0.72f, 0.72f, 1.0f);
	SynchronousRotation = true;
}

//Plutos moon
void CelestialBody::SetCharon()
{
	Mass = 1.586;//kg
	Volume = 932194383.144831;//km3
	EquatorialRadius = 606;//km
	PolarRadius = 606;//km
	VolumetricMeanRadius = 606;//km
	Ellipticity = 0;//flattening
	MeanDensity = 1700;//kg/m3
	SurfaceGravity = 0;//m/s2 - Undefined
	SurfaceAccelleration = 0;//m/s2 - Undefined
	EscapeVelocity = 0;//km/s - Undefined
	GM = 0;//km3/s2 - Undefined

	SemiMajorAxis = 19.596;//km
	SiderealOrbitPeriod = 6.3872;//days
	TropicalOrbitPeriod = 6.3872;//days
	Periapsis = 19596;//km
	Apoapsis = 19596;//km
	SynodicPeriod = 0;//days - Undefined
	MeanOrbitalVelocity = 0;//km/s - Undefined
	MaxOrbitalVelocity = 0;//km/s - Undefined
	MinOrbitalVelocity = 0;//km/s - Undefined

	LenghtOfDay = 0;//hrs - Undefined
	ObliquityToOrbit = 0;//deg - Undefined

	OrbitalEccentricity = 0;// - Undefined
	OrbitalInclination = 0.00005;//deg
	LongitudeOfAscendingNode = 85.187;//deg
	LongitudeOfPeriapsis = 156.442;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined
	TimeOfPeriapsis = 0;// - Undefined
	color = Color(0.38f, 0.38f, 0.38f, 1.0f);
	SynchronousRotation = true;
}

//Other
void CelestialBody::SetCeres()
{
	SemiMajorAxis = 414086906.928;//km
	SiderealOrbitPeriod = 1680.15;//days
	TropicalOrbitPeriod = 1680.15;//days
	Periapsis = 382699119382.858;//km
	Apoapsis = 445474694473.142;//km

	OrbitalEccentricity = 0.0758;// - Undefined
	OrbitalInclination = 10.59;//deg
	LongitudeOfAscendingNode = 80.3055315683;//deg
	LongitudeOfPeriapsis = 153.9032256843;//deg

	RightAscension = 291.42744;// - Undefined
	Declination = 66.764;// - Undefined

	color = Color(0.549019608f,		0.521568627f,		0.450980392f, 1.0f);
}

void CelestialBody::SetPallas()
{
	SemiMajorAxis = 414685298.412;//km
	SiderealOrbitPeriod = 1683.8025;//days
	TropicalOrbitPeriod = 1683.8025;//days
	Periapsis = 318892994478.828;//km
	Apoapsis = 510477602345.172;//km

	OrbitalEccentricity = 0.231;// - Undefined
	OrbitalInclination = 34.84;//deg
	LongitudeOfAscendingNode = 173.080062747;//deg
	LongitudeOfPeriapsis = 483.128920174;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 0;// - Undefined
	Declination = 90;// - Undefined

	color = Color(0.643f, 0.643f, 0.643f, 1.0f);
}

void CelestialBody::SetVesta()
{
	SemiMajorAxis = 353350171.302;//km
	SiderealOrbitPeriod = 1325.8575;//days
	TropicalOrbitPeriod = 1325.8575;//days
	Periapsis = 321937341073.253;//km
	Apoapsis = 384763001530.747;//km

	OrbitalEccentricity = 0.0889;// - Undefined
	OrbitalInclination = 7.14;//deg
	LongitudeOfAscendingNode = 103.810804427;//deg
	LongitudeOfPeriapsis = 254.539345714;//deg
	MeanLongitude = 0;//deg - Undefined

	RightAscension = 308;// - Undefined
	Declination = 48;// - Undefined

	color = Color(0.55f, 0.54f, 0.49f, 1.0f);
}


SolarSystem::SolarSystem()
{
	time = 0;
	gravityThreshold = 0.0005; 
}

Planet * SolarSystem::Earth()
{
	return &earth; 
}

Planet * SolarSystem::Venus()
{
	return &venus; 
}

Planet * SolarSystem::Mercury()
{
	return &mercury; 
}

Planet * SolarSystem::Mars()
{
	return &mars;
}

Planet * SolarSystem::Moon()
{
	return &moon; 
}

Planet * SolarSystem::Jupiter()
{
	return &jupiter; 
}

Planet * SolarSystem::Saturn()
{
	return &saturn; 
}

Planet * SolarSystem::Neptune()
{
	return &neptune; 
}

Planet * SolarSystem::Uranus()
{
	return &uranus; 
}

Planet * SolarSystem::Pluto()
{
	return &pluto;
}

Planet * SolarSystem::Sun()
{
	return &sun; 
}


//Jupiters moons
Planet * SolarSystem:: Io() { return &io; }
Planet * SolarSystem:: Europa() { return &europa; }
Planet * SolarSystem:: Ganymede() { return &ganymede; }
Planet * SolarSystem:: Callisto() { return &callisto; }

//Saturns moons
Planet * SolarSystem:: Titan() { return &titan; }
Planet * SolarSystem:: Mimas() { return &mimas; }
Planet * SolarSystem:: Enceladus() { return &enceladus; }
Planet * SolarSystem:: Tethys() { return &tethys; }
Planet * SolarSystem:: Dione() { return &dione; }
Planet * SolarSystem:: Rhea() { return &rhea; }
Planet * SolarSystem:: Hyperion() { return &hyperion; }
Planet * SolarSystem:: Iapetus() { return &iapetus; }

//Uranus moons
Planet * SolarSystem:: Miranda() { return &miranda; }
Planet * SolarSystem:: Ariel() { return &ariel; }
Planet * SolarSystem:: Umbriel() { return &umbriel; }
Planet * SolarSystem:: Titania() { return &titania; }
Planet * SolarSystem:: Oberon() { return &oberon; }

//Neptunes moons
Planet * SolarSystem:: Triton() { return &triton; }

//Plutos moon
Planet * SolarSystem:: Charon() { return &charon; }

//Other
Planet* SolarSystem::Ceres() { return &ceres; }
Planet* SolarSystem::Pallas() { return &pallas; }
Planet* SolarSystem::Vesta() { return &vesta; }


std::vector<Planet*> SolarSystem::Planets() 
{
	if (planets.size() == 0)
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
		moon.isMoonOf = &earth;
	
		//Jupiters moons
		io.SetIo();
		io.isMoonOf = &jupiter;
		europa.SetEuropa();
		europa.isMoonOf = &jupiter;
		ganymede.SetGanymede(); 
		ganymede.isMoonOf = &jupiter;
		callisto.SetCallisto();
		callisto.isMoonOf = &jupiter;
		
		//Saturns moons
		titan.SetTitan(); 
		titan.isMoonOf = &saturn;
		mimas.SetMimas(); 
		mimas.isMoonOf = &saturn;
		enceladus.SetEnceladus(); 
		enceladus.isMoonOf = &saturn;
		tethys.SetTethys(); 
		tethys.isMoonOf = &saturn;
		dione.SetDione(); 
		dione.isMoonOf = &saturn;
		rhea.SetRhea(); 
		rhea.isMoonOf = &saturn;
		hyperion.SetHyperion(); 
		hyperion.isMoonOf = &saturn;
		iapetus.SetIapetus(); 
		iapetus.isMoonOf = &saturn;

		//Uranus moons
		miranda.SetMiranda(); 
		miranda.isMoonOf = &uranus;
		ariel.SetAriel(); 
		ariel.isMoonOf = &uranus;
		umbriel.SetUmbriel(); 
		umbriel.isMoonOf = &uranus;
		titania.SetTitania(); 
		titania.isMoonOf = &uranus;
		oberon.SetOberon(); 
		oberon.isMoonOf = &uranus;

		//Neptunes moons
		triton.SetTriton(); 
		triton.isMoonOf = &neptune;

		//Plutos moon
		charon.SetCharon(); 
		charon.isMoonOf = &pluto;

		//other
		ceres.SetCeres();
		pallas.SetPallas();
		vesta.SetVesta(); 

		planets = std::vector<Planet*>
		{
			Earth(),
			Venus(),
			Mercury(),
			Mars(),
			Moon(),
			Jupiter(),
			Saturn(),
			Neptune(),
			Uranus(),
			Pluto(),
			Sun(),

			//Jupiters moons
			Io(),	
			Europa(),
			Ganymede(),
			Callisto(),

			//Saturns moons
			Titan(),
			Mimas(),
			Enceladus(),
			Tethys(),
			Dione(),
			Rhea(),
			Hyperion(),
			Iapetus(),

			//Uranus moons
			Miranda(),
			Ariel(),
			Umbriel(),
			Titania(),
			Oberon(),

			//Neptunes moons
			Triton(),

			//Plutos moon
			Charon(),

			//Other
			Ceres(),
			Pallas(),
			Vesta(),
		};

		int i = 0; 
		for (Planet*planet:planets)
		{
			planet->LoadCelestialBodyOrbit(); 
			planet->id = i++; 
		}
	}
	return planets; 
}

std::vector<Planet*> SolarSystem::GravitySources()
{
	std::vector<Planet*> planets = Planets(); 
	std::vector<Planet*> gravitySources;

	for (Planet*planet:planets)
	{
		if (planet->position.HasNaN())
			continue; 

		if (planet->surfaceGravity < gravityThreshold)
			continue; 

		gravitySources.push_back(planet);
	}
	return gravitySources; 
}

void SolarSystem::SetTimeSinceJ2000(double days)
{
	time = days; 
	Point3D moonPos;
	for (Planet*planet : Planets())
	{
		if (planet->isMoonOf != NULL)
			planet->moonLocalPosition = planet->PositionByTime(days); 
		else if (planet->isSun)
			planet->position = Point3D(0, 0, 0);
		else
			planet->position = planet->PositionByTime(days);
	}

	for (Planet*planet : Planets())
	{
		if (planet->isMoonOf != NULL)
			planet->position = planet->moonLocalPosition + planet->isMoonOf->position;
	}
	//sun is always at 0. 
	Sun()->position = 0;
}
