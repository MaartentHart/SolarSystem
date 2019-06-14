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

	int meteorCount = 0;
	int objectCount = gravityObjects.size(); 
	
	for (const GravityAffectedObject&gravityObject : gravityObjects)
		meteorCount += gravityObject.count;
	
	std::vector<Point3D> previousObjectPositions(meteorCount);

	int m = 0; 
	for (int i = 0; i < objectCount; i++)
		for (int j =0; j<gravityObjects[i].count;j++)
			previousObjectPositions[m++] = gravityObjects[i].position[j];

	for (GravityAffectedObject& gravityObject : gravityObjects)
		gravityObject.MoveByGravity(planets, seconds);

	m = 0; 
	for (int i = 0; i < objectCount; i++)
	{
		int count = gravityObjects[i].count;
		for (int j = 0; j < count; j++)
		{
			Point3D previousObjectPosition = previousObjectPositions[m++];
			Point3D*objectPosition = gravityObjects[i].position+j;
			
			if (isnan(objectPosition->X))
				//already impacted
				continue; 

			for (int p = 0; p < planetCount; p++)
			{
				Point3D previousPlanetPosition = previousPlanetPositions[p];
				Planet* planet = planets[p];
				if (planet->InImpactRange(previousObjectPosition, *objectPosition, previousPlanetPosition))
					planet->Impact(previousObjectPosition, *objectPosition, previousPlanetPosition, previousTime, time);
			}
		}
	}
}