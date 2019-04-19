//Copyright Maarten 't Hart 2013
#include "stdafx.h"
#include "Element3D.h"

InfiniteLine::InfiniteLine() :vector(0, 0, 1), position(0, 0, 0)
{}

InfiniteLine::InfiniteLine(const Point3D&Vector, const Point3D&Position)
{
	if (Vector == NoPoint() || Position == NoPoint())
	{
		vector = NoPoint();
		position = NoPoint();
		return;
	}
	vector = Vector.Vector();

	position = -CrossMultiply(vector, CrossMultiply(vector, Position));
}

InfiniteLine::~InfiniteLine()
{}

Point3D InfiniteLine::Position() const
{
	return position;
}

Point3D InfiniteLine::Vector() const
{
	return vector;
}

Point3D InfiniteLine::ReachDistance(double that) const
{
	double add = that * that - position.DistSquared();

	if (add <= 0)
		return position;
	return position + vector * sqrt(add);
}

Point3D InfiniteLine::ReachDistanceInOtherDirection(double that) const
{

	double add = that * that - position.DistSquared();

	if (add <= 0)
		return position;
	return position - vector * sqrt(add);
}

Point3D InfiniteLine::NearestToOrigin() const
{
	return position + vector * (position.X*vector.X + position.Y*vector.Y + position.Z*vector.Z);
}

Point3D InfiniteLine::operator+=(double that)
{
	return	position += vector * that;
}
Point3D InfiniteLine::operator-=(double that)
{
	return	position -= vector * that;
}

Point3D InfiniteLine::SetPosition(Point3D&that)
{
	return position = that;
}

Point3D InfiniteLine::SetVector(Point3D&that)
{
	return vector = that.Vector();
}

void InfiniteLine::ResetToZero()
{
	position = NearestToOrigin();
}

void TriangleIndices::Set(int A, int B, int C)
{
	a = A; b = B; c = C;
}


Triangle::Triangle()
{
	points = 0;
}

Triangle::Triangle(const Point3D*Points, long A, long B, long C)
{
	points = Points;
	a = A;
	b = B;
	c = C;
	ResetNormal();
}

Triangle::Triangle(const Point3D*Points, const TriangleIndices&ti)
{
	points = Points;
	a = ti.a;
	b = ti.b;
	c = ti.c;
	ResetNormal();
}

void Triangle::ResetNormal()
{
	Normal = NormalVectorofTriangle();
}

Triangle::~Triangle()
{

}

Point3D Triangle::A() const
{
	return points[a];
}

Point3D Triangle::B() const
{
	return points[b];
}

Point3D Triangle::C() const
{
	return points[c];
}

Point3D Triangle::NormalVectorofTriangle() const
{
	return NormalVector(C() - A(), C() - B());
}

double Triangle::DistToOrigin() const
{
	Point3D Normal = NormalVectorofTriangle();
	return A().X*Normal.X + A().Y*Normal.Y + A().Z*Normal.Z;
	//niet gecontroleerd. 
	//http://mathworld.wolfram.com/Point-PlaneDistance.html
}

double Triangle::DistTo(const Point3D&that) const
{
	Point3D Normal = NormalVectorofTriangle();
	return that.X*Normal.X + that.Y*Normal.Y + that.Z*Normal.Z - DistToOrigin();
	//niet gecontroleerd.
	//http://mathworld.wolfram.com/Point-PlaneDistance.html
}

Point3D Triangle::NearestToOrigin() const
{
	Point3D Normal = NormalVectorofTriangle();
	return Normal * (A().X*Normal.X + A().Y*Normal.Y + A().Z*Normal.Z);
}

Plane::Plane() :DistToOrigin(0)
{}

Plane::Plane(const Point3D&A, const Point3D&B, const Point3D&C)
{
	Normal = NormalVector(C - A, C - B);
	DistToOrigin = -A.X*Normal.X - A.Y*Normal.Y - A.Z*Normal.Z;
	//http://keisan.casio.com/has10/SpecExec.cgi?id=system/2006/1223596129
	//niet gecontroleerd.
	//http://mathworld.wolfram.com/Point-PlaneDistance.html
}

Plane::Plane(const Point3D&A, const Point3D&B)
{
	Normal = NormalVector(A, B);
	DistToOrigin = 0;
}

Plane::Plane(const Triangle&that)
{
	Normal = NormalVector(that.C() - that.A(), that.C() - that.B());
	DistToOrigin = that.A().X*Normal.X + that.A().Y*Normal.Y + that.A().Z*Normal.Z;
	//niet gecontroleerd.
	//http://mathworld.wolfram.com/Point-PlaneDistance.html
}

Plane::Plane(const Point3D&normal, double disttoorigin) :Normal(normal.Vector()), DistToOrigin(disttoorigin)
{}

Plane::~Plane()
{}

InfiniteLine Plane::Intersection(const Plane&that)const
{
	Point3D ILineNormal = NormalVector(that.Normal, Normal);//vector of intersecting line

	Point3D P1 = NearestPointToOrigin();
	Point3D P2 = that.NearestPointToOrigin();
	Point3D V1 = NormalVector(ILineNormal, Normal);
	Point3D V2 = NormalVector(ILineNormal, that.Normal);

	//	http://mathforum.org/library/drmath/view/62814.html
	
	Point3D Left = CrossMultiply(V1, V2).CleanUp();
	Point3D Right = CrossMultiply(P2 - P1, V2).CleanUp();
	double a;

	if (abs(Left.X) < VerySmall())
		if (abs(Left.Y) < VerySmall())
			a = Right.Z / Left.Z;
		else
			a = Right.Y / Left.Y;
	else
		a = Right.X / Left.X;

	Point3D ILinePoint = P1 + V1 * a;

	return InfiniteLine(ILineNormal, -ILinePoint);
}

Point3D Plane::NearestPointToOrigin() const
{
	return Normal * DistToOrigin;
}

double Plane::DistToPoint(const Point3D&that) const
{
	return that.X*Normal.X + that.Y*Normal.Y + that.Z*Normal.Z + DistToOrigin;

	//not checked.
	//http://mathworld.wolfram.com/Point-PlaneDistance.html
}

