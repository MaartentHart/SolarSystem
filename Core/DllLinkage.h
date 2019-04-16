#pragma once

#define DLL __declspec(dllexport) 
extern "C"
{
	DLL void __cdecl ExampleSetString(const char*theString);
	DLL int __cdecl ExampleGetInt();
}