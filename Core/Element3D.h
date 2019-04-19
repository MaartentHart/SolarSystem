//Copyright Maarten 't Hart 2013
#pragma once
#include "Point3D.h"

struct InfiniteLine
{
private:
	Point3D vector;
	Point3D position;

public:
	InfiniteLine();
	InfiniteLine(const Point3D&Vector, const Point3D&Position);
	~InfiniteLine();

	Point3D ReachDistance(double that) const;//Point at a distance from the world origin
	Point3D ReachDistanceInOtherDirection(double that) const;
	Point3D Vector() const;
	Point3D Position() const;
	Point3D NearestToOrigin() const;
	Point3D operator+=(double that);
	Point3D operator-=(double that);
	Point3D SetPosition(Point3D&that);
	Point3D SetVector(Point3D&that);
	void ResetToZero();
};

struct TriangleIndices
{
	union
	{
		struct
		{
			int a, b, c;
		};
		int i[3];
	};
	void Set(int A, int B, int C);
};

struct Triangle : public TriangleIndices
{
	const Point3D*points;
	Point3D Normal;//normal of triangle, which is correct after usage of "ResetNormal"

	Triangle();
	Triangle(const Point3D*points, long A, long B, long C);
	Triangle(const Point3D*points, const TriangleIndices&that);
	~Triangle();

	Point3D A() const;
	Point3D B() const;
	Point3D C() const;
	void ResetNormal();
	Point3D NormalVectorofTriangle()const;//normal vector calculation
	Point3D NearestToOrigin()const;//point on plane that is nearest to origin. 
	double DistToOrigin()const;//distance of plane to origin
	double DistTo(const Point3D&that)const;//distance of plane to point. 
};

struct Plane
{
	Point3D Normal;
	double DistToOrigin;

	Plane();
	Plane(const Point3D&A, const Point3D&B, const Point3D&C);
	Plane(const Point3D&A, const Point3D&B); //point C is considered to be the origin
	Plane(const Triangle&that);
	Plane(const Point3D&normal, double disttoorigin);
	~Plane();

	InfiniteLine Intersection(const Plane&that) const;//de lijn die de vlakken snijdt. 
	Point3D NearestPointToOrigin() const;//de richting van de snijlijn
	double DistToPoint(const Point3D&that) const;
};
