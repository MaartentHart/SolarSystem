//Copyright Maarten 't Hart 2019
#pragma once
#include "stdafx.h"
#include "Planet.h"

//Places all the planets in the right position at a given time. Days relative to 01-01-2000. 

struct SolarSystem
{
	double time; 

	SolarSystem(); 

	Planet*Earth();
	Planet*Venus();
	Planet*Mercury();
	Planet*Mars();
	Planet*Moon();
	Planet*Jupiter();
	Planet*Saturn();
	Planet*Neptune();
	Planet*Uranus();
	Planet*Pluto();
	Planet*Sun();
	std::vector<Planet*> Planets(); 
	void SetTimeSinceJ2000(double days);
};