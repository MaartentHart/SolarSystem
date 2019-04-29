//Copyright Maarten 't Hart 2019
#include "stdafx.h"
#include "DllLinkage.h"
#include <string>
#include "SolarSystem.h"
#include "Geodesic.h"

SolarSystem solarSystem;
Planet* activePlanet; 

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
	const GeodesicGrid*grid = GetGeodesicGrid((unsigned int)generation);
	return grid->GetTriangleIndices().size()*3; 
}

int SetActivePlanet(const char*name)
{
	int i = 0; 
	for (Planet*planet : solarSystem.Planets())
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
	if (id < 0 || id >= (int) solarSystem.Planets().size())
		activePlanet = NULL;
	else
		activePlanet = solarSystem.Planets()[id];
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
	solarSystem.SetTimeSinceJ2000(days);
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
	return activePlanet->SiderealRotationPeriod*solarSystem.time;
}

double CopySign(double a, double b)
{
	return copysign(a, b); 
}