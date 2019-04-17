//(c) Maarten 't Hart 2013
#pragma once
#include "Point3D.h"
#include "Color.h"

struct Particle
{
	Point3D position;
	Color color;
	Point3D normal;
	double value[4];//valuestorages. Can be used for any custom calcuation. 
	float u, v;//used for opengl texturing.
};

