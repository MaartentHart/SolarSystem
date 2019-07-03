//Copyright Maarten 't Hart 2019
//This is the native linkage point between the C++ native code and the C# interface code. 

#pragma once
#include "color.h"
#include "SolarSystem.h"
#include "Geodesic.h"
#include "Simulation.h"
#include "Impact.h"
#include <string>

#define DLL __declspec(dllexport) 
extern "C"
{
	//Tests and Examples
	DLL void __cdecl ExampleSetString(const char*theString);
	DLL int __cdecl ExampleGetInt();
	DLL double* __cdecl TestVertices(int generation);
	DLL int __cdecl TestVerticesCount(int generation);
	DLL const int* __cdecl TestIndices(int generation);
	DLL int __cdecl TestIndicesCount(int generation);
	//End of Tests and Examples. 

	//Geodesic grid
	DLL const double* __cdecl GeodesicGridVertices(int generation);
	DLL int __cdecl GeodesicGridVerticesCount(int generation); 
	DLL const int* __cdecl GeodesicGridIndices(int generation);
	DLL int __cdecl GeodesicGridIndicesCount(int generation);
	DLL const int* __cdecl GeodesicGridMipMapIndices(int generation, int mipmapGeneration);

	//Planet properties
	DLL int __cdecl AddPlanet(const char* name, double equatorialRadius, double polarRadius, 
		double surfaceGravity, double apoapsis, double periapsis, double orbitalInclination, double siderealOrbitPeriod, double siderealRotationPeriod,
		double longitudeOfAscendingNode, double longitudeOfPeriapsis, double rightAscension, double declination, 
		double timeOfPeriapsis, float r, float g, float b);
	DLL int __cdecl SetActivePlanet(const char*name);
	DLL void __cdecl SetActivePlanetID(int id);
	DLL double __cdecl PlanetScaleX(); 
	DLL double __cdecl PlanetScaleY();
	DLL double __cdecl PlanetScaleZ();
	DLL void __cdecl PlanetColor(Color&color);
	DLL double __cdecl EarthAxisTilt();
	DLL double __cdecl PlanetRightAscension(); 
	DLL double __cdecl PlanetDeclination(); 

	//Planet update
	DLL void __cdecl SetDaysSinceJ2000(double days); 
	DLL double __cdecl PlanetPositionX();
	DLL double __cdecl PlanetPositionY();
	DLL double __cdecl PlanetPositionZ();
	DLL double __cdecl PlanetRotation();
	DLL void __cdecl SetPlanetBaseRotation(int planetId, double x, double y, double z, double w); 
	DLL void __cdecl SetPlanetRotationCalibration(int planetId, double calibration);

	//EquatorialCoordinateSystem
	DLL void __cdecl EarthPositionAt(double daysSinceJ2000, Point3D& position);
	DLL void __cdecl PlanetPositionAt(int planetId, double daysSinceJ2000, Point3D&position);

	//Simulation
	//initialize simulation
	DLL void __cdecl ClearFallingObjects(); 
	DLL int __cdecl AddFallingObject(Point3D*positions, Point3D*velocities, int pointCount);
	DLL void __cdecl RemoveFallingObject(int id);
	DLL void __cdecl Run(bool run);
	DLL void __cdecl SetPauseTime(double pauseTime); 
	DLL double __cdecl SetTimeStep(double timeStep);
	//add a single time step. 
	DLL void __cdecl AddTimeStep(double timeStep);
	//run the simulation until run is set false. 
	DLL void __cdecl Simulate(); 
	//get information from simulation. 
	DLL double __cdecl GetTime(); 
	DLL double __cdecl PausingAt(); 

	//Impacts
	DLL int GetImpactCount();
	DLL void GetImpact(int id, int& planetID, double& speed, double& time, Point3D& vector); 
	//Draw an impact on the given layer. Scaled radius is the radius of the crater divided by the radius of the planet.  
	DLL void DrawImpactOn(int impactId, int generation, double scaledRadius, double maxValue, double* layer); 

	DLL void SetGravityThreshold(double threshold); 
}