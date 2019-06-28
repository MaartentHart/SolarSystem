//Copyright (C) Maarten 't Hart 2019
#include "stdafx.h"
#include "Ray.h"

Ray::Ray(const Point3D& start, const Point3D& end)
{
	this->start = start;
	this->end = end;
}

bool Ray::IntersectSingleUnitSphere(Point3D&intersection, double & position) const
{
	//https://stackoverflow.com/questions/6533856/ray-sphere-intersection
	Point3D dif = end - start; 

	double a = dif.DistSquared(); 
	double b = 2 * dif.Dot(start);
	double c = start.DistSquared() - 1; 

	double delta = b * b - 4 * a * c; 

	if (delta < 0)
		return false;

	double a2 = 2 * a;

	if (delta == 0)
	{		
		double d = -b / a2; 

		if (d < 0 || d>1)
			return false; 
		intersection = start + dif * d;
		return true; 
	}

	double sqrtDelta = sqrt(delta); 

	double d1 = (-b - sqrtDelta)/a2;
	double d2 = (-b + sqrtDelta)/a2;

	if (d1 < 0 || d1 > 1)
		if (d2 < 0 || d2 > 1)
			return false;
		else
			position = d2;
	else if (d2 < 0 || d2 > d1)
		position = d1; 
	else
	  position = d2; 
	
	intersection = start + dif * position;

	return true; 
}
