//Copyright Maarten 't Hart 2019
#pragma once

//colors with values ranging from 0 to 1. 
struct Color
{
	union
	{
		struct
		{
			float r;
			float g;
			float b;
			float a;
		};
		float rgba[4];
	};
	Color();
	Color(float R, float G, float B, float A);

	void LimitCheck();
	Color operator*(float that) const;
	Color operator+(const Color&that) const;
};