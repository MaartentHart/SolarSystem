//Copyright Maarten 't Hart 2019
//This is the .NET linkage point between the C++ native code and the C# interface code. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public static class CoreDll
  {
    [DllImport("Core.dll", EntryPoint = "ExampleGetInt", CallingConvention = CallingConvention.Cdecl)]
    static public extern int ExampleGetInt();

    [DllImport("Core.dll", EntryPoint = "ExampleSetString", CallingConvention = CallingConvention.Cdecl)]
    static public extern int ExampleSetString(string theString);

    [DllImport("Core.dll", EntryPoint = "GeodesicGridVertices", CallingConvention = CallingConvention.Cdecl)]
    //return value is an IntPtr to a type double.
    static public extern IntPtr GeodesicGridVertices(int generation);

    [DllImport("Core.dll", EntryPoint = "GeodesicGridVerticesCount", CallingConvention = CallingConvention.Cdecl)]
    static public extern int GeodesicGridVerticesCount(int generation);

    [DllImport("Core.dll", EntryPoint = "GeodesicGridIndices", CallingConvention = CallingConvention.Cdecl)]
    //return value is an IntPtr to a type ulong.
    static public extern IntPtr GeodesicGridIndices(int generation);

    [DllImport("Core.dll", EntryPoint = "GeodesicGridIndicesCount", CallingConvention = CallingConvention.Cdecl)]
    static public extern int GeodesicGridIndicesCount(int generation);

  }
}
