//Copyright Maarten 't Hart 2019
#pragma once
#include "stdafx.h"
#include "Planet.h"
#include <mutex>

//Places all the planets in the right position at a given time. Days relative to 01-01-2000. 

struct SolarSystem
{
	double gravityThreshold; 
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

	//Jupiters moons
	Planet* Io();
	Planet* Europa();
	Planet* Ganymede();
	Planet* Callisto();
	
	//Saturns moons
	Planet* Titan();
	Planet* Mimas();
	Planet* Enceladus();
	Planet* Tethys();
	Planet* Dione();
	Planet* Rhea(); 
	Planet* Hyperion();
	Planet* Iapetus();

	//Uranus moons
	Planet* Miranda();
	Planet* Ariel();
	Planet* Umbriel();
	Planet* Titania();
	Planet* Oberon(); 

	//Neptunes moons
	Planet* Triton();

	//Plutos moon
	Planet* Charon(); 

	//Other
	Planet* Ceres();
	Planet* Pallas();
	Planet* Vesta(); 

	std::vector<Planet*> Planets(); 
	std::vector<Planet*> GravitySources(); 
	void SetTimeSinceJ2000(double days);

	Planet* GetPlanet(std::string name);
	Planet* GetPlanet(int id); 
	void AddPlanet(Planet* planet);
};