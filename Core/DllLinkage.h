//Copyright Maarten 't Hart 2019
//This is the native linkage point between the C++ native code and the C# interface code. 

#pragma once
#define DLL __declspec(dllexport) 
extern "C"
{
	DLL void __cdecl ExampleSetString(const char*theString);
	DLL int __cdecl ExampleGetInt();
	DLL void __cdecl SetRenderTarget(HWND hwnd, int width, int height);
}