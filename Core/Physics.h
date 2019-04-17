//Copyright Maarten 't Hart 2019
#pragma once
#include "Planet.h"

struct GravityAffectedObject
{
private:
	Point3D* position;
	Point3D* velocity;
	double* speed;
public:
	GravityAffectedObject(Point3D*position, Point3D*velocity, double*speed);
	
	Point3D& Position();
	Point3D& Velocity();
	double& Speed(); 
	//first calculate the velocity change by each gravity source, then move once. 
	void MoveByGravity(std::vector<Planet*>&gravitySoruces, double seconds = 1.);
	//affecting the velocity. Does not move anything
	void PullGravity(Planet*planet, double seconds = 1.);
	//affecting the velocity. Does not move anything
	Point3D PullGravity(const Point3D&gravityPosition, double surfaceGravity, double gravityRadius = 1., double seconds = 1.);
	void Move(double seconds);
};

double LocalGravity(double gravityDistanceSquared, double surfaceGravity, double gravityRadius = 1.);
double GravityAcceleration(double gravityDistanceSquared, double gravityAtSurface, double gravityRadius = 1., double seconds = 1.);