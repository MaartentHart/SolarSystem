//Copyright Maarten 't Hart 2019
//This is the native linkage point between the C++ native code and the C# interface code. 

#pragma once
#define DLL __declspec(dllexport) 
extern "C"
{
	//Tests and Examples
	DLL void __cdecl ExampleSetString(const char*theString);
	DLL int __cdecl ExampleGetInt();
	DLL double* __cdecl TestVertices(int generation);
	DLL int __cdecl TestVerticesCount(int generation);
	DLL const int* __cdecl TestIndices(int generation);
	DLL int __cdecl TestIndicesCount(int generation);
	//End of Tests and Examples. 

	DLL const double* __cdecl GeodesicGridVertices(int generation);
	DLL int __cdecl GeodesicGridVerticesCount(int generation); 
	DLL const int* __cdecl GeodesicGridIndices(int generation);
	DLL int __cdecl GeodesicGridIndicesCount(int generation);

}