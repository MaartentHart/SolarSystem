//Copyright Maarten 't Hart 2019
#include "stdafx.h"
#include "Physics.h"

GravityAffectedObject::GravityAffectedObject(Point3D * position, Point3D * velocity, int count)
{
	this->position = position;
	this->velocity = velocity;
	this->count = count; 
	disposed = false; 
}

Point3D & GravityAffectedObject::Position(int index)
{
	return position[index]; 
}

Point3D & GravityAffectedObject::Velocity(int index)
{
	return velocity[index];
}

double GravityAffectedObject::Speed()
{
	return velocity->Distance(); 
}

void GravityAffectedObject::MoveByGravity(std::vector<Planet*>& gravitySources, double seconds)
{
	if (disposed)
		return; 
	for (std::vector<Planet*>::iterator planet = gravitySources.begin(); planet < gravitySources.end(); ++planet)
		PullGravity(*planet, seconds);
	Move(seconds);
}

void GravityAffectedObject::PullGravity(Planet * planet, double seconds)
{
	if (disposed)
		return;
	Point3D *position = this->position;
	Point3D *velocity = this->velocity;
	for (int i = 0; i<count ; i++, velocity++, position++)
		*velocity += PullGravity(planet->position, planet->SurfaceGravity/1000, planet->radius, seconds, *position);
}

Point3D GravityAffectedObject::PullGravity(const Point3D & gravityPosition, double surfaceGravity, double gravityRadius, double seconds, const Point3D&position)
{
	Point3D pullDirection = gravityPosition - position;
	return pullDirection.Vector()*GravityAcceleration(pullDirection.DistSquared(), surfaceGravity, gravityRadius, seconds);
}

void GravityAffectedObject::Move(double seconds)
{
	if (disposed)
		return; 
	for (int i =0; i<count; i++)
		position[i] += velocity[i] * seconds;
}

double LocalGravity(double gravityDistanceSquared, double surfaceGravity, double gravityRadius)
{
	return Squared(gravityRadius) / gravityDistanceSquared * surfaceGravity;
}

double GravityAcceleration(double gravityDistanceSquared, double gravityAtSurface, double gravityRadius, double seconds)
{
	return LocalGravity(gravityDistanceSquared, gravityAtSurface, gravityRadius)*seconds;
}

