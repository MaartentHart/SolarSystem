//Copyright Maarten 't Hart 2019
#include "stdafx.h"
#include "DllLinkage.h"
#include <string>

void ExampleSetString(const char*theString)
{
	std::string example(theString);
}

int ExampleGetInt()
{
	int a = 40;
	int b = 2;
	int c = a + b;
	return c;
}

void SetRenderTarget(HWND hwnd, int width, int height)
{
	HWND test = hwnd; 
}