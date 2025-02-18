//Copyright Maarten 't Hart 2013
#pragma once
#include <math.h>
#include <string>
#include <sstream>
#include "CException.h"

struct Point3D;
struct LatLon;

inline double Squared(double that)
{
	return that * that;
}

inline bool IsBetween(double poi, double A, double B)
{
	return (poi <= A && poi >= B) || (poi >= A && poi <= B);
}

struct Point3D
{
	union
	{
		struct
		{
			double X;
			double Y;
			double Z;
		};
		double XYZ[3];
	};

	Point3D();
	Point3D(double x, double y, double z);
	Point3D(double that);
	Point3D(const LatLon&that);

	inline Point3D operator+(double that)const { return Point3D(*this) += that; }
	inline Point3D operator+(const Point3D&that)const { return Point3D(*this) += that; }
	inline Point3D operator-(double that)const { return Point3D(*this) -= that; }
	inline Point3D operator-(const Point3D&that)const { return Point3D(*this) -= that; }
	inline Point3D operator*(double that)const { return Point3D(*this) *= that; }
	inline Point3D operator*(const Point3D&that)const { return Point3D(*this) *= that; }
	inline Point3D operator/(double that)const { return Point3D(*this) /= that; }
	inline Point3D operator/(const Point3D&that)const { return Point3D(*this) /= that; }

	inline Point3D& operator+=(double that) { X += that;   Y += that;   Z += that; return *this; }
	inline Point3D& operator+=(const Point3D&that) { X += that.X; Y += that.Y; Z += that.Z; return *this; }

	inline Point3D& operator-=(double that) { X -= that;   Y -= that;   Z -= that; return *this; }
	inline Point3D& operator-=(const Point3D&that) { X -= that.X; Y -= that.Y; Z -= that.Z; return *this; }

	inline Point3D& operator*=(double that) { X *= that;   Y *= that;   Z *= that; return *this; }
	inline Point3D& operator*=(const Point3D&that) { X *= that.X; Y *= that.Y; Z *= that.Z; return *this; }

	inline Point3D& operator/=(double that) { X /= that;   Y /= that;   Z /= that; return *this; }
	inline Point3D& operator/=(const Point3D&that) { X /= that.X; Y /= that.Y; Z /= that.Z; return *this; }

	inline Point3D operator-() { return Point3D(-X, -Y, -Z); }
	inline bool operator==(const Point3D&that) const { return (X == that.X && Y == that.Y && Z == that.Z); }

	inline double Dot(const Point3D& p)const { return X * p.X + Y * p.Y + Z * p.Z; }
	inline Point3D Cross(const Point3D&p) const { 
		return  Point3D(Y * p.Z - Z * p.Y, Z * p.X - X * p.Z, X * p.Y - Y * p.X);
	}
	Point3D RotateX(double angle) const;//angle in radian
	Point3D RotateY(double angle) const;//angle in radian
	Point3D RotateZ(double angle) const;//angle in radian

	inline double DistTo(const Point3D&that) const { return X * that.X + Y * that.Y + Z * that.Z; }
	inline double DistSquared() const { return X * X + Y * Y + Z * Z; }
	inline double Distance() const { return sqrt(DistSquared()); }

	inline Point3D YZX() const { return Point3D(Y, Z, X); }
	inline Point3D ZXY() const { return Point3D(Z, X, Y); }
	inline Point3D Abs() const { return Point3D(abs(X), abs(Y), abs(Z)); }

	inline bool HasNaN() const { return isnan(X) || isnan(Y) || isnan(Z); }

	Point3D Vector() const;

	bool IsBetween(const Point3D&A, const Point3D&B)const;
	Point3D CleanUp() const;
	bool IsOrigin() const; 
	Point3D& VectorMe();
	double Vector2VectorCircularDistance(const Point3D&that) const;//circular distance of two points on a sphere with a radius of 1. 
	std::string ToString() const; 
};

inline const Point3D NoPoint()
{
	return Point3D(-1E99, -1E99, -1E99);
}

double Pi();
Point3D CrossMultiply(const Point3D& A, const Point3D& B);
Point3D NormalVector(const Point3D&A, const Point3D&B);
double Determinant(const Point3D&A, const Point3D&B, const Point3D&C);
double VerySmall(); 
double Deg2Rad(double degrees);
double Rad2Deg(double degrees);

struct LatLon
{
	double E;
	double N;

	LatLon();
	LatLon(const Point3D&that);
};

struct Rotation
{
	double axisTilt; //radian
	double axisDirection; //radian
	double rotationAroundAxis; //radian

	Rotation(double tilt = 0, double direction = 0, double aroundAxis = 0);
	
	void TiltDegree(double tilt);
	void DirectionDegree(double dir);
	void AroundAxisDegree(double ar);
};

struct BoundingBox
{
	Point3D minimum;
	Point3D maximum;
	BoundingBox();
	BoundingBox(const Point3D&a, const Point3D&b);
	void Grow(double value);
	bool Overlaps(const BoundingBox& other) const; 
};