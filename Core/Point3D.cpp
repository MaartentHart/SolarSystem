//Copyright Maarten 't Hart 2013
#include "stdafx.h"
#include "Point3D.h"

const double pi = 4 * atan(1.0);
const double deg2rad = pi / 180;
const double rad2deg = 180 / pi;
const double verysmall = 1.0e-15;

Point3D::Point3D() : X(1), Y(0), Z(0) {}
Point3D::Point3D(double x, double y, double z) : X(x), Y(y), Z(z) {}
Point3D::Point3D(double that) : X(that), Y(that), Z(that) {}
Point3D::Point3D(const LatLon&that)
{
	double N = that.N*(pi / ((double)180));
	double E = that.E*(pi / ((double)180));
	double xy = cos(N);
	X = xy * cos(E);
	Y = xy * sin(E);
	Z = sin(N);
}

Point3D Point3D::Vector() const
{
	if (X == 0 && Y == 0 && Z == 0)
	{
		return Point3D();
	}
	return *this / Distance();
}

bool Point3D::IsBetween(const Point3D&A, const Point3D&B)const
{
	if (::IsBetween(X, A.X, B.X))
		if (::IsBetween(Y, A.Y, B.Y))
			return ::IsBetween(Z, A.Z, B.Z);
	return false;
}

Point3D& Point3D::VectorMe() { (*this) /= Distance(); return *this; }

std::string Point3D::ToString() const
{
	std::ostringstream strs;
	strs << X << ",\t" << Y << ",\t" << Z;
	return strs.str();
}

Point3D Point3D::RotateX(double angle) const
{
	double cosA = cos(angle);
	double sinA = sin(angle);
	return Point3D(X, Y *cosA + Z * sinA, Z*cosA - Y * sinA);
}

Point3D Point3D::RotateY(double angle) const
{
	double cosA = cos(angle);
	double sinA = sin(angle);
	return Point3D(X*cosA - Z * sinA, Y, Z*cosA + X * sinA);
}

Point3D Point3D::RotateZ(double angle) const
{
	double cosA = cos(angle);
	double sinA = sin(angle);
	return Point3D(X*cosA + Y * sinA, Y*cosA - X * sinA, Z);
}

Point3D Point3D::CleanUp() const
{
	Point3D out = *this;
	if (abs(X) < verysmall)
		if (X != 0.0)
			out.X = 0.0;
	if (abs(Y) < verysmall)
		if (Y != 0)
			out.Y = 0.0;
	if (abs(Z) < verysmall)
		if (Z != 0)
			out.Z = 0.0;
	return out;
}

bool Point3D::IsOrigin()const
{
	return X == 0 && Y == 0 && Z == 0;
}

double Point3D::Vector2VectorCircularDistance(const Point3D&that) const
{
	return pi / asin(1 - Vector().DistTo(that.Vector()));//test please
}

double Pi() { return pi; }

Point3D CrossMultiply(const Point3D&A, const Point3D&B)
{
	return Point3D(
		A.Y * B.Z - A.Z * B.Y,
		A.Z * B.X - A.X * B.Z,
		A.X * B.Y - A.Y * B.X
	);
}

Point3D NormalVector(const Point3D&A, const Point3D&B)
{
	return Point3D(
		A.Y * B.Z - A.Z * B.Y,
		A.Z * B.X - A.X * B.Z,
		A.X * B.Y - A.Y * B.X
	).Vector();
}

double Determinant(const Point3D&A, const Point3D&B, const Point3D&C)
{
	//http://mathworld.wolfram.com/Determinant.html
	return A.X*B.Y*C.Z
		- A.X*B.Z*C.Y
		- A.Y*B.X*C.Z
		+ A.Y*B.Z*C.X
		+ A.Z*B.X*C.Y
		- A.Z*B.Y*C.X;
}

double VerySmall() { return verysmall; }
double Deg2Rad(double degrees){ return deg2rad * degrees;}
double Rad2Deg(double radian) { return rad2deg * radian; }

LatLon::LatLon() : E(0), N(0)
{}

LatLon::LatLon(const Point3D&that)
{
	Point3D Vector = that.Vector();
	N = asin(Vector.Z) / pi * (double)180;
	double xy = acos(Vector.Z);
	E = atan2(Vector.Y, Vector.X) / pi * (double)180;
}

Rotation::Rotation(double tilt, double direction, double aroundAxis)
	:axisTilt(tilt), axisDirection(direction), rotationAroundAxis(aroundAxis)
{}

void Rotation::TiltDegree(double tilt)
{
	axisTilt = tilt * deg2rad;
}

void Rotation::DirectionDegree(double dir)
{
	axisDirection = dir * deg2rad;
}

void Rotation::AroundAxisDegree(double ar)
{
	rotationAroundAxis = ar * deg2rad;
}

BoundingBox::BoundingBox()
{
	double positiveInfinity = std::numeric_limits<double>::infinity();
	double negativeInfinity = -positiveInfinity; 
	minimum = Point3D(positiveInfinity, positiveInfinity, positiveInfinity);
	maximum = Point3D(negativeInfinity, negativeInfinity, negativeInfinity);
}

BoundingBox::BoundingBox(const Point3D& a, const Point3D& b)
{
	minimum = Point3D(
		a.X < b.X ? a.X : b.X,
		a.Y < b.Y ? a.Y : b.Y,
		a.Z < b.Z ? a.Z : b.Z
	);
	maximum = Point3D(
		a.X > b.X ? a.X : b.X,
		a.Y > b.Y ? a.Y : b.Y,
		a.Z > b.Z ? a.Z : b.Z
	);
}

void BoundingBox::Grow(double value)
{
	minimum -= value; 
	maximum += value; 
}

bool BoundingBox::Overlaps(const BoundingBox& other)const
{
	if (other.maximum.X < minimum.X || other.maximum.Y < minimum.Y || other.maximum.Z < minimum.Z)
		return false;

	if (maximum.X < other.minimum.X || maximum.Y < other.minimum.Y || maximum.Z < other.minimum.Z)
		return false;

	return true; 
}