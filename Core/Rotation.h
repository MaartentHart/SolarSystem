#pragma once
#include <math.h>
#include "Point3D.h"
struct Quaternion
{
	double x, y, z, w;

	Quaternion(double x = 0, double y = 0, double z = 1, double w = 0);
	Quaternion(Point3D vector, double rotation);
	Quaternion(Quaternion systemRotation, Quaternion localRotation);

	Quaternion Reverse() const; 

	Point3D Rotate(const Point3D& point)const; 
	Point3D RotateReverse(const Point3D& point)const;
};