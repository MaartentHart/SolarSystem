//Copyright Maarten 't Hart 2019
//This is the native linkage point between the C++ native code and the C# interface code. 

#pragma once
#define DLL __declspec(dllexport) 
extern "C"
{
	DLL void __cdecl ExampleSetString(const char*theString);
	DLL int __cdecl ExampleGetInt();

	DLL double* __cdecl GeodesicGridVertices(int generation);
	DLL int __cdecl GeodesicGridVerticesCount(int generation); 
	DLL const int* __cdecl GeodesicGridIndices(int generation);
	DLL int __cdecl GeodesicGridIndicesCount(int generation);

}