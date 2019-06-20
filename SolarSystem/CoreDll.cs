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
    #region TestsAndExamples; 
    [DllImport("Core.dll", EntryPoint = "ExampleGetInt", CallingConvention = CallingConvention.Cdecl)]
    static public extern int ExampleGetInt();

    [DllImport("Core.dll", EntryPoint = "ExampleSetString", CallingConvention = CallingConvention.Cdecl)]
    static public extern int ExampleSetString(string theString);

    [DllImport("Core.dll", EntryPoint = "TestVertices", CallingConvention = CallingConvention.Cdecl)]
    //return value is an IntPtr to a type double.
    static public extern IntPtr TestVertices();

    [DllImport("Core.dll", EntryPoint = "TestVerticesCount", CallingConvention = CallingConvention.Cdecl)]
    static public extern int TestVerticesCount();

    [DllImport("Core.dll", EntryPoint = "TestIndices", CallingConvention = CallingConvention.Cdecl)]
    //return value is an IntPtr to a type ulong.
    static public extern IntPtr TestIndices();

    [DllImport("Core.dll", EntryPoint = "TestIndicesCount", CallingConvention = CallingConvention.Cdecl)]
    static public extern int TestIndicesCount();
    #endregion

    #region GeodesicGrid
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

    [DllImport("Core.dll", EntryPoint = "GeodesicGridMipMapIndices", CallingConvention = CallingConvention.Cdecl)]
    //return value is an IntPtr to a type ulong.
    static public extern IntPtr GeodesicGridMipMapIndices(int generation, int mipmapGeneration);
    #endregion

    #region PlanetProperties
    [DllImport("Core.dll", EntryPoint = "SetActivePlanet", CallingConvention = CallingConvention.Cdecl)]
    static public extern int SetActivePlanet(string name);

    [DllImport("Core.dll", EntryPoint = "SetActivePlanetID", CallingConvention = CallingConvention.Cdecl)]
    static public extern void SetActivePlanetID(int id);

    [DllImport("Core.dll", EntryPoint = "PlanetScaleX", CallingConvention = CallingConvention.Cdecl)]
    static public extern double PlanetScaleX();

    [DllImport("Core.dll", EntryPoint = "PlanetScaleY", CallingConvention = CallingConvention.Cdecl)]
    static public extern double PlanetScaleY();

    [DllImport("Core.dll", EntryPoint = "PlanetScaleZ", CallingConvention = CallingConvention.Cdecl)]
    static public extern double PlanetScaleZ();

    [DllImport("Core.dll", EntryPoint = "PlanetColor", CallingConvention = CallingConvention.Cdecl)]
    static public extern void PlanetColor(ref ColorFloat color);

    [DllImport("Core.dll", EntryPoint = "EarthAxisTilt", CallingConvention = CallingConvention.Cdecl)]
    static public extern double EarthAxisTilt();

    [DllImport("Core.dll", EntryPoint = "PlanetRightAscension", CallingConvention = CallingConvention.Cdecl)]
    static public extern double PlanetRightAscension();

    [DllImport("Core.dll", EntryPoint = "PlanetDeclination", CallingConvention = CallingConvention.Cdecl)]
    static public extern double PlanetDeclination();
    #endregion

    #region PlanetUpdate
    [DllImport("Core.dll", EntryPoint = "SetDaysSinceJ2000", CallingConvention = CallingConvention.Cdecl)]
    static public extern void SetDaysSinceJ2000(double days);

    [DllImport("Core.dll", EntryPoint = "PlanetPositionX", CallingConvention = CallingConvention.Cdecl)]
    static public extern double PlanetPositionX();

    [DllImport("Core.dll", EntryPoint = "PlanetPositionY", CallingConvention = CallingConvention.Cdecl)]
    static public extern double PlanetPositionY();

    [DllImport("Core.dll", EntryPoint = "PlanetPositionZ", CallingConvention = CallingConvention.Cdecl)]
    static public extern double PlanetPositionZ();

    [DllImport("Core.dll", EntryPoint = "PlanetRotation", CallingConvention = CallingConvention.Cdecl)]
    static public extern double PlanetRotation();

    [DllImport("Core.dll", EntryPoint = "SetPlanetBaseRotation", CallingConvention = CallingConvention.Cdecl)]
    static public extern void SetPlanetBaseRotation(int planetId, double x, double y, double z, double w);

    [DllImport("Core.dll", EntryPoint = "SetPlanetRotationCalibration", CallingConvention = CallingConvention.Cdecl)]
    static public extern void SetPlanetRotationCalibration(int planetId, double calibration);
    #endregion

    #region Simulation    
    [DllImport("Core.dll", EntryPoint = "ClearFallingObjects", CallingConvention = CallingConvention.Cdecl)]
    static public extern void ClearFallingObjects();

    /// <summary>
    /// Adds an array of points that will be affected by gravity. 
    /// </summary>
    /// <param name="points">A c++ pointer to a Point3D array</param>
    /// <param name="velocities">A c++ pointer to a Point3D vector</param>
    /// <param name="pointCount">The amount of points.</param>
    /// <returns>The ID of the object, which can be used to remove the falling object later.</returns>
    [DllImport("Core.dll", EntryPoint = "AddFallingObject", CallingConvention = CallingConvention.Cdecl)]
    static public extern int AddFallingObject(IntPtr positions, IntPtr velocities, int pointCount);

    [DllImport("Core.dll", EntryPoint = "RemoveFallingObject", CallingConvention = CallingConvention.Cdecl)]
    static public extern void RemoveFallingObject(int id);
    
    [DllImport("Core.dll", EntryPoint = "Run", CallingConvention = CallingConvention.Cdecl)]
    static public extern void Run(bool run);

    [DllImport("Core.dll", EntryPoint = "SetTimeStep", CallingConvention = CallingConvention.Cdecl)]
    static public extern double SetTimeStep(double timeStep);

    [DllImport("Core.dll", EntryPoint = "AddTimeStep", CallingConvention = CallingConvention.Cdecl)]
    static public extern void AddTimeStep(double timeStep);

    //run the simulation until run is set false. 
    [DllImport("Core.dll", EntryPoint = "Simulate", CallingConvention = CallingConvention.Cdecl)]
    static public extern void Simulate();

    //get information from simulation. 
    [DllImport("Core.dll", EntryPoint = "GetTime", CallingConvention = CallingConvention.Cdecl)]
    static public extern double GetTime();
    #endregion

    #region EquatorialCoordinateSystemInformation
    [DllImport("Core.dll", EntryPoint = "EarthPositionAt", CallingConvention = CallingConvention.Cdecl)]
    static public extern void EarthPositionAt(double daysSinceJ2000, ref Point3D position);
    #endregion

    #region Impact
    [DllImport("Core.dll", EntryPoint = "GetImpactCount", CallingConvention = CallingConvention.Cdecl)]
    static public extern int GetImpactCount();

    [DllImport("Core.dll", EntryPoint = "GetImpact", CallingConvention = CallingConvention.Cdecl)]
    static public extern void GetImpact(int id, ref int planetID, ref double speed, ref double time, ref Point3D vector);

    [DllImport("Core.dll", EntryPoint = "DrawImpactOn", CallingConvention = CallingConvention.Cdecl)]
    static public extern void DrawImpactOn(int impactId, int generation, double scaledRadius, double maxValue, double[] layer);
    #endregion

  }
}
