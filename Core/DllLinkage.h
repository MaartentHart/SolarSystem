//Copyright Maarten 't Hart 2019
//This is the native linkage point between the C++ native code and the C# interface code. 

#pragma once
#include "color.h"
#include "SolarSystem.h"
#include "Geodesic.h"
#include "Physics.h"

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

	//Planet properties
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

	//EquatorialCoordinateSystem
	DLL void __cdecl EarthPositionAt(double daysSinceJ2000, Point3D& position);

	//Simulation
	//initialize simulation
	DLL void __cdecl ClearFallingObjects(); 
	DLL void __cdecl AddFallingObject(Point3D*points, Point3D*velocities, int pointCount);
	DLL void __cdecl Run(bool run);
	DLL void __cdecl SetTimeStep(double timeStep);
	//run the simulation until run is set false. 
	DLL void __cdecl Simulate(); 
	//get information from simulation. 
	DLL double __cdecl GetTime(); 

}