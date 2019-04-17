//Copyright Maarten 't Hart 2019
#include "stdafx.h"
#include "Physics.h"

GravityAffectedObject::GravityAffectedObject(Point3D * position, Point3D * velocity, double * speed)
{
	this->position = position;
	this->velocity = velocity;
	this->speed = speed; 
}

Point3D & GravityAffectedObject::Position()
{
	return *position; 
}

Point3D & GravityAffectedObject::Velocity()
{
	return *velocity;
}

double & GravityAffectedObject::Speed()
{
	return *speed; 
}

void GravityAffectedObject::MoveByGravity(std::vector<Planet*>& gravitySoruces, double seconds)
{
	for (std::vector<Planet*>::iterator planet = gravitySoruces.begin(); planet < gravitySoruces.end(); ++planet)
		PullGravity(*planet, seconds);
	Move(seconds);
}

void GravityAffectedObject::PullGravity(Planet * planet, double seconds)
{
	PullGravity(planet->position, planet->SurfaceGravity, planet->radius, seconds);
}

Point3D GravityAffectedObject::PullGravity(const Point3D & gravityPosition, double surfaceGravity, double gravityRadius, double seconds)
{
	Point3D pullDirection = gravityPosition - Position();
	return pullDirection.Vector()*GravityAcceleration(pullDirection.DistSquared(), surfaceGravity, gravityRadius, seconds);
}

void GravityAffectedObject::Move(double seconds)
{
	*position += *velocity * seconds;
}

double LocalGravity(double gravityDistanceSquared, double surfaceGravity, double gravityRadius)
{
	return Squared(gravityRadius) / gravityDistanceSquared * surfaceGravity;
}

double GravityAcceleration(double gravityDistanceSquared, double gravityAtSurface, double gravityRadius, double seconds)
{
	return LocalGravity(gravityDistanceSquared, gravityAtSurface, gravityRadius)*Squared(seconds);
}

