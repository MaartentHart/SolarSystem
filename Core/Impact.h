#pragma once
#include "SolarSystem.h"
#include <mutex>

struct Impact
{
	const Planet* planet;
	double speed; 
	double time; 
	Point3D vector;

	Impact(); 
	Impact(const Planet* planet, double speed, double time, const Point3D& vector);
};

void Register(const Impact& impact); 
int ImpactCount(); 
Impact GetImpact(int index); 