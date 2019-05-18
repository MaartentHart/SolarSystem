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

//Quick check if an object may cause an impact. 
bool InImpactRange(const Point3D& previousObjectPosition, Point3D& objectPosition, const Point3D& previousPlanetPosition, const Planet& planet)
{
	BoundingBox objectBox(previousObjectPosition, objectPosition);
	BoundingBox planetBox(previousPlanetPosition, planet.position);

	planetBox.Grow(planet.radius);

	return objectBox.Overlaps(planetBox);
}

//more accurate check if an object causes an impact and trigger an impact if it does. 
void Impact(const Point3D& previousObjectPosition, Point3D& objectPosition, const Point3D& previousPlanetPosition, const Planet& planet, double startTime, double endTime)
{
	Point3D start = previousObjectPosition - previousPlanetPosition;
	Point3D end = objectPosition - planet.position; 

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
			if (InImpactRange(previousObjectPosition, objectPosition, previousPlanetPosition, *planets[i]))
			{
				Impact(previousObjectPosition, objectPosition, previousPlanetPosition, *planets[i], previousTime, time);
			}
		}
	}
}