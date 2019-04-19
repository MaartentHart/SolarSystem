//Copyright Maarten 't Hart 2019
#include "stdafx.h"
#include "DllLinkage.h"
#include <string>
#include "SolarSystem.h"
#include "Geodesic.h"

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

double* GeodesicGridVertices(int generation)
{
	GeodesicGrid grid = GetGeodesicGrid((unsigned int)generation);
	return grid.points[0].XYZ;
}

int GeodesicGridVerticesCount(int generation)
{
	GeodesicGrid grid = GetGeodesicGrid((unsigned int)generation);
	return grid.points.size(); 
}

const int* GeodesicGridIndices(int generation)
{
	GeodesicGrid grid = GetGeodesicGrid((unsigned int)generation);
	return &(grid.GetTriangleIndices()[0]).a;
}

int GeodesicGridIndicesCount(int generation)
{
	GeodesicGrid grid = GetGeodesicGrid((unsigned int)generation);
	return grid.GetTriangleIndices().size() * 3; 
}