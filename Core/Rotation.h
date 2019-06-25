#pragma once
#include <math.h>
#include "Point3D.h"
struct Quaternion
{
	double x, y, z, w;

	Quaternion(); 
	Quaternion(double yaw, double pitch, double roll);
	Quaternion(double x, double y, double z, double w);
	Quaternion(Point3D vector, double rotation);
	Quaternion(const Point3D& directionVector, const Point3D& upVector); 
	Quaternion(Quaternion systemRotation, Quaternion localRotation);

	Quaternion Reverse() const; 

	Point3D Rotate(const Point3D& point)const; 
	Point3D RotateReverse(const Point3D& point)const;
};