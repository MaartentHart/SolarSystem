#include "stdafx.h"
#include "Rotation.h"

double constrainAngle(double x) {
	//https://stackoverflow.com/questions/11498169/dealing-with-angle-wrap-in-c-code
	x = fmod(x, 360);
	if (x < 0)
		x += 360;
	return x;
}

Quaternion::Quaternion(): x(0), y(0), z(1), w(0)
{}

Quaternion::Quaternion(double yaw, double pitch, double roll)
{
	// Abbreviations for the various angular functions
	double cy = cos(yaw * 0.5);
	double sy = sin(yaw * 0.5);
	double cp = cos(pitch * 0.5);
	double sp = sin(pitch * 0.5);
	double cr = cos(roll * 0.5);
	double sr = sin(roll * 0.5);

	w = cy * cp * cr + sy * sp * sr;
	x = cy * cp * sr - sy * sp * cr;
	y = sy * cp * sr + cy * sp * cr;
	z = sy * cp * cr - cy * sp * sr;
}

Quaternion::Quaternion(double x, double y, double z, double w) :x(x), y(y), z(z), w(w)
{}

Quaternion::Quaternion(Point3D vector, double rotation)
{
	//https://www.euclideanspace.com/maths/geometry/rotations/conversions/angleToQuaternion/index.htm
	vector/=vector.Distance();
	rotation = constrainAngle(rotation);
	double angle = rotation / 180 * Pi();
	double s = sin(angle / 2);
	x = vector.X * s;
	y = vector.Y * s;
	z = vector.Z * s;
	w = cos(angle / 2);
}

Quaternion::Quaternion(const Point3D& directionVector, const Point3D& upVector)
{
	Point3D z = upVector; 
	Point3D y = z.Cross(Point3D(1, 0, 0)).Vector(); 
	Point3D x = y.Cross(z).Vector(); 
	
	double xDist = x.Dot(directionVector);
	double yDist = y.Dot(directionVector);

	double angle = atan2(yDist, xDist);
	double s = sin(angle / 2);

	x = z.X * s;
	y = z.Y * s;
	z = z.Z * s; 
	w = cos(angle / 2); 
}

Quaternion::Quaternion(Quaternion a, Quaternion q)
{
	//http://www.ncsa.illinois.edu/People/kindr/emtc/quaternions/quaternion.c++
	x = a.w * q.x + a.x * q.w + a.y * q.z - a.z * q.y;
	y = a.w * q.y + a.y * q.w + a.z * q.x - a.x * q.z;
	z = a.w * q.z + a.z * q.w + a.x * q.y - a.y * q.x;
	w = a.w * q.w - a.x * q.x - a.y * q.y - a.z * q.z;
}

Quaternion Quaternion::Reverse() const
{
	return Quaternion(-x, -y, -z, w);
}

Point3D Quaternion::Rotate(const Point3D&point) const
{
	//https://gamedev.stackexchange.com/questions/28395/rotating-vector3-by-a-quaternion
	Point3D vector(x, y, z);
	return vector * 2.0* vector.Dot(point) + point * (w * w - vector.Dot(vector)) + vector.Cross(point) * 2.0 * w;
}

Point3D Quaternion::RotateReverse(const Point3D&point) const
{
	return Reverse().Rotate(point); 
}