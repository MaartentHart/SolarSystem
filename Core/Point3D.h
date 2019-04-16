#pragma once
#include <math.h>
#include <string>

struct Point3D;
struct LatLon;

double abs(double that);

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
	Point3D() : X(1), Y(0), Z(0) {}
	//	Point3D(const Point3D&that)							{ X = that.X; Y = that.Y; Z = that.Z; }
	Point3D(double x, double y, double z) : X(x), Y(y), Z(z) {}
	Point3D(double that) : X(that), Y(that), Z(that) {}
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

	Point3D rotateX(double angle) const;//angle in radian
	Point3D rotateY(double angle) const;//angle in radian
	Point3D rotateZ(double angle) const;//angle in radian

	inline double DistTo(const Point3D&that) const { return X * that.X + Y * that.Y + Z * that.Z; }
	inline double DistSquared() const { return X * X + Y * Y + Z * Z; }
	inline double Distance() const { return sqrt(DistSquared()); }
	inline Point3D YZX() const { return Point3D(Y, Z, X); }
	inline Point3D ZXY() const { return Point3D(Z, X, Y); }
	inline Point3D Abs() const { return Point3D(abs(X), abs(Y), abs(Z)); }

	/*
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


	Point3D CleanUp() const;

	Point3D& Point3D::VectorMe() { (*this) /= Distance(); return *this; }
	double Vector2VectorCircularDistance(const Point3D&that) const;//circular distance of two points on a sphere with a radius of 1. 
	*/
};