//Copyright (C) Maarten 't Hart 2019
#pragma once
#include "Physics.h"
#include "SolarSystem.h"
#include "DllLinkage.h"

SolarSystem& GetSolarSystem();
std::vector<GravityAffectedObject*> GetGravityObjects();

//note: always call ReleaseGravityObjectsIncludingDisposed when done. 
std::vector<GravityAffectedObject>& GetGravityObjectsIncludingDisposed(); 
void ReleaseGravityObjectsIncludingDisposed();

////SetTimeStep and AddTimeStep are declared in DllLinkage.h
double GetTimeStep();