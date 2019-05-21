#include "stdafx.h"
#include "Simulation.h"

SolarSystem solarSystem;
std::vector<GravityAffectedObject> gravityObjects;
double timeStep;

SolarSystem& GetSolarSystem()
{
	return solarSystem;
}

std::vector<GravityAffectedObject>& GetGravityObjects()
{
	return gravityObjects;
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
	std::vector<Planet*> planets = solarSystem.Planets();
	int planetCount = planets.size();
	std::vector<Point3D> previousPlanetPositions(planets.size());
	for (int i = 0; i < planetCount; i++)
		previousPlanetPositions[i] = planets[i]->position;

	double previousTime = solarSystem.time; 
	double time = previousTime + days;
	solarSystem.SetTimeSinceJ2000(time);
	double seconds = days * 86400;

	int objectCount = gravityObjects.size();
	std::vector<Point3D> previousObjectPositions(objectCount);

	for (int i = 0; i < objectCount; i++)
		previousObjectPositions[i] = *gravityObjects[i].position;

	for (GravityAffectedObject& gravityObject : gravityObjects)
		gravityObject.MoveByGravity(planets, seconds);

	for (int i = 0; i < objectCount; i++)
	{
		Point3D previousObjectPosition = previousObjectPositions[i];
		Point3D objectPosition = *gravityObjects[i].position;

		for (int p = 0; p < planetCount; p++)
		{
			Point3D previousPlanetPosition = previousPlanetPositions[i];
			Planet* planet = planets[i];
			if (planet->InImpactRange(previousObjectPosition, objectPosition, previousPlanetPosition))
				planet->Impact(previousObjectPosition, objectPosition, previousPlanetPosition, previousTime, time);
		}
	}
}