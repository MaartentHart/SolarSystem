#pragma once
#include "Physics.h"
#include "SolarSystem.h"
#include "DllLinkage.h"

SolarSystem& GetSolarSystem();
std::vector<GravityAffectedObject>& GetGravityObjects();

////SetTimeStep and AddTimeStep are declared in DllLinkage.h
//double SetTimeStep(double timeStep);
double GetTimeStep();
//void AddTimeStep(double days);

bool InImpactRange(const Point3D& previousObjectPosition, Point3D& objectPosition, const Point3D& previousPlanetPosition, const Planet& planet);
void Impact(const Point3D& previousObjectPosition, Point3D& objectPosition, const Point3D& previousPlanetPosition, const Planet& planet, double startTime, double endTime);
