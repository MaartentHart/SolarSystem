#include "stdafx.h"	
#include "Impact.h"
std::mutex mutex;
std::vector<Impact> impacts; 

Impact::Impact()
{
}

Impact::Impact(const Planet* planet, double speed, double time, const Point3D& vector)
{
	this->planet = planet;
	this->speed = speed;
	this->time = time;
	this->vector = vector;
}

void Register(const Impact& impact)
{
	mutex.lock();
	impacts.push_back(impact);
	mutex.unlock(); 
}

int ImpactCount()
{
	int count = 0; 
	mutex.lock();
	count = (int) impacts.size();
	mutex.unlock();
	return count; 
}

Impact GetImpact(int index)
{
	Impact impact; 
	mutex.lock();
	impact = impacts[index];
	mutex.unlock();
	return impact; 
}
