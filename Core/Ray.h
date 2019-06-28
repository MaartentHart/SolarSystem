//Copyright (C) Maarten 't Hart 2019
#pragma once
#include "Point3D.h"

struct Ray
{
	Point3D start;
	Point3D end;
	
	Ray(const Point3D& start, const Point3D& end);

	//Calculates the nearest intersection with a sphere of radius 1 located at 0,0,0
	bool IntersectSingleUnitSphere(Point3D& intersection, double & position) const;
};
