#pragma once
#include "SolarSystem.h"
#include <mutex>

struct Impact
{
	int planetID;
	double speed; 
	double time; 
	Point3D vector;

	Impact(); 
	Impact(int planetID, double speed, double time, const Point3D& vector);
};

void Register(const struct Impact& impact); 
int ImpactCount(); 
struct Impact GetImpact(int index); 