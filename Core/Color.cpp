//(c) Maarten 't Hart 2013
#include "stdafx.h"
#include "Color.h"

Color::Color()
{
	r = g = b = a = 1.0f;
}

Color::Color(float R, float G, float B, float A)
{
	r = R; g = G; b = B; a = A;
	LimitCheck();
}

void Color::LimitCheck()
{
	if (r > 1.0)
		r = 1.0;
	if (r < 0.0)
		r = 0.0;
	if (g > 1.0)
		g = 1.0;
	if (g < 0.0)
		g = 0.0;
	if (b > 1.0)
		b = 1.0;
	if (b < 0.0)
		b = 0.0;
	if (a > 1.0)
		a = 1.0;
	if (a < 0.0)
		a = 0.0;
}

Color Color::operator*(float that) const
{
	Color out;
	out.r = r * that;
	out.g = g * that;
	out.b = b * that;
	out.LimitCheck();
	return out;
}

Color Color::operator+(const Color& that) const
{
	Color out;
	out.r = r + that.r;
	out.g = g + that.g;
	out.b = b + that.b;
	out.LimitCheck();
	return out;
}