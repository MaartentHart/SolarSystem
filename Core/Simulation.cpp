//Copyright (C) Maarten 't Hart 2019
#include "stdafx.h"
#include "Simulation.h"

SolarSystem solarSystem;
std::vector<GravityAffectedObject> gravityObjects;
double timeStep;
std::mutex mtx; 

SolarSystem& GetSolarSystem()
{
	return solarSystem;
}

std::vector<GravityAffectedObject*> GetGravityObjects()
{
	mtx.lock(); 
	std::vector<GravityAffectedObject*> result;
	for (GravityAffectedObject& gravityObject : gravityObjects)
		if (!gravityObject.disposed)
			result.push_back(&gravityObject);
	mtx.unlock(); 
	return result;
}

std::vector<GravityAffectedObject>& GetGravityObjectsIncludingDisposed()
{
	mtx.lock(); 
	return gravityObjects; 
}

void ReleaseGravityObjectsIncludingDisposed()
{
	mtx.unlock(); 
}

double SetTimeStep(double timeStep)
{
	return ::timeStep = timeStep; 
}

double GetTimeStep()
{
	return timeStep; 
}

void AddTimeStep(double days)
{
	std::vector<GravityAffectedObject*> gravityObjects = GetGravityObjects(); 

	std::vector<Planet*> planets = solarSystem.Planets(); 

	for (Planet* planet : planets)
		if (planet->SurfaceGravity == 0)
			//make sure the SurfaceGravity is set. 
		  planet->SurfaceAccelleration = planet->SurfaceGravity = planet->surfaceGravity;

	int planetCount = planets.size();

	std::vector<Point3D> previousPlanetPositions(planetCount);
	for (int i = 0; i < planetCount; i++)
		previousPlanetPositions[i] = planets[i]->position;

	double previousTime = solarSystem.time; 
	double time = previousTime + days;
	solarSystem.SetTimeSinceJ2000(time);
	double seconds = days * 86400;

	int meteorCount = 0;
	int objectCount = gravityObjects.size(); 
	
	for (const GravityAffectedObject*gravityObject : gravityObjects)
		meteorCount += gravityObject->count;
	
	std::vector<Point3D> previousObjectPositions(meteorCount);

	int m = 0; 
	for (int i = 0; i < objectCount; i++)
		for (int j =0; j<gravityObjects[i]->count;j++)
			previousObjectPositions[m++] = gravityObjects[i]->position[j];

	std::vector<Planet*> gravitySources = GetSolarSystem().GravitySources(); 
	for (GravityAffectedObject* gravityObject : gravityObjects)
		gravityObject->MoveByGravity(gravitySources, seconds);
	 
	m = 0; 
	for (int i = 0; i < objectCount; i++)
	{
		int count = gravityObjects[i]->count;
		for (int j = 0; j < count; j++)
		{
			Point3D previousObjectPosition = previousObjectPositions[m++];
			Point3D*objectPosition = gravityObjects[i]->position+j;

			for (int p = 0; p < planetCount; p++)
			{
				if (isnan(objectPosition->X))
					//already impacted
					break;

				Point3D previousPlanetPosition = previousPlanetPositions[p];
				Planet* planet = planets[p];
				if (planet->position.HasNaN())
					continue; 

				if (planet->InImpactRange(previousObjectPosition, *objectPosition, previousPlanetPosition))
					planet->Impact(previousObjectPosition, *objectPosition, previousPlanetPosition, previousTime, time);
			}
		}
	}
}