using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public enum SolarSystemPlanet
  {
    [StringValue("Sun")] Sun,
    [StringValue("Mercury")] Mercury,
    [StringValue("Venus")] Venus,
    [StringValue("Earth")] Earth,
    [StringValue("Mars")] Mars,
    [StringValue("Jupiter")] Jupiter,
    [StringValue("Saturn")] Saturn,
    [StringValue("Uranus")] Uranus,
    [StringValue("Neptune")] Neptune,
    [StringValue("Pluto")] Pluto,
    [StringValue("Moon")] Moon,
  }

  /// <summary>
  /// The renderable class of the planet. 
  /// </summary>
  public class Planet : IRenderable, IDisposable, IPositionObject
  {
    private bool on = true;
    private double previousExxageration = 0; 
    private double exxageration = 0; 
    private readonly object locker = new object();
    private bool unmanagedVerticesNormals = false;
    private bool unmanagedColors = false; 
    private IntPtr normals;
    private IntPtr vertices;
    private IntPtr colors; 
    private BackgroundWorker backgroundWorker = new BackgroundWorker(); 
    private bool changed = true;
    private bool paint = false; 

    public int Generation { get; }
    public SolarSystemPlanet PlanetID { get; }
    public CRenderableObject RenderableObject { get; } = new CRenderableObject();
    public HeightMap HeightMap { get; set; }
    //public Shader Shader { get; }
    //public ColorFloat[] Color { get; set; }
    public Point3D Scale { get; }
    public double[] ColorableValues { get; set; }
    public ColorMap ColorMap { get; set; }
    
    public List<string> PlanetUniforms { get; } = new List<string>
    {
      "uRadius",
      "uExxageration"
    };
    public List<string> PlanetAttributes { get; } = new List<string>
    {
      "aVertex",
      "aHeight",
      "aColor"
    };
    public bool On
    {
      get => on;
      set 
      {
        changed = true;
        on = value;  
      }
    }
    public string Name { get; set; }
    public bool Changed
    {
      get
      {
        bool ret = changed | RenderableObject.Changed;
        changed = false;
        return ret;
      }
      set => changed = value;
    }

    public Point3D Position => RenderableObject.Position; 

    public Planet(SolarSystemPlanet planet, int generation = 9)
    {
      Generation = generation;
      PlanetID = planet;
      RenderableObject.RenderGeometry.SetGeodesicGrid(generation);
      HeightMap = new HeightMap(planet, generation);
      ColorableValues = HeightMap.Heights; 
      //Shader = new Shader("PlanetHeightMapVertex", "TestFrag", PlanetUniforms, PlanetAttributes); 
      //Color = new ColorFloat[CoreDll.GeodesicGridVerticesCount(9)];
      Name = planet.ToString();
      CoreDll.SetActivePlanet(planet.ToString());
      Scale = new Point3D(CoreDll.PlanetScaleX(), CoreDll.PlanetScaleY(), CoreDll.PlanetScaleZ());
      SetExxageration(1.0);
    }

    public void SetExxageration(double scale)
    {
      if (exxageration == scale)
        return;
      exxageration = scale;
      StartBackgroundWorker(); 
    }

    public void StartBackgroundWorker()
    {
      if (backgroundWorker.IsBusy)
      {
        return;
      }
      backgroundWorker.Dispose(); 
      backgroundWorker = new BackgroundWorker(); 
      backgroundWorker.DoWork += ApplyChanges;
      backgroundWorker.RunWorkerAsync();
    }


    public void SetColorMap(ColorMap colorMap, double[] values)
    {
      if (values != null)
      {
        ColorableValues = values;
      }
      SetColorMap(colorMap); 
    }

    public void SetColorMap(ColorMap colorMap)
    {
      ColorMap = colorMap;

      if (ColorableValues!=null)
      { 
        paint = true;
        StartBackgroundWorker();
      }
    }

    /// <summary>
    /// Modifying the vertical scale exxageration using a backgroundworker
    /// Memory management is c-style based. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ApplyChanges(object sender, DoWorkEventArgs e)
    {
      bool changed = true;
      while (changed)
      {
        changed = false;
        //applying vertices and normals. 
        while (exxageration != previousExxageration)
        {
          changed = true;
          ApplyExxageration();
        }
        while (paint)
        {
          changed = true;
          Paint(); 
        }
      }
    }

    private void ApplyExxageration()
    {
      previousExxageration = exxageration;
      IntPtr geodesicGridVerticesPointer = CoreDll.GeodesicGridVertices(Generation);
      IntPtr geodesicGridIndicesPointer = CoreDll.GeodesicGridIndices(Generation);
      int verticesCount = CoreDll.GeodesicGridVerticesCount(Generation);
      int indicesCount = CoreDll.GeodesicGridIndicesCount(Generation);

      IntPtr newVerticesPointer = Marshal.AllocHGlobal(verticesCount * 24);
      IntPtr newNormalsPointer = Marshal.AllocHGlobal(verticesCount * 24);
      unsafe
      {
        Point3D* vertices = (Point3D*)geodesicGridVerticesPointer.ToPointer();
        Point3D* newVertices = (Point3D*)newVerticesPointer.ToPointer();
        //moving the vertices. 
        for (int i = 0; i < verticesCount; i++)
        {
          Point3D vertex = vertices[i] * Scale;
          double magnitude = vertex.Magnitude;
          double newMagnitude = magnitude + HeightMap.Heights[i] * 0.001 * exxageration;

          newVertices[i] = vertex * (newMagnitude / magnitude);
        }

        //recalculating the normals. 
        int* indices = (int*)geodesicGridIndicesPointer.ToPointer();
        Point3D* newNormals = (Point3D*)newNormalsPointer.ToPointer();
        for (int i = 0; i < indicesCount; i += 3)
        {
          int* index = indices + i;

          Point3D* a = newVertices + *index;
          Point3D* b = newVertices + *(index + 1);
          Point3D* c = newVertices + *(index + 2);
          Point3D ab = *b - *a;
          Point3D ca = *a - *c;
          Point3D triangleNormal = ab.Cross(ca).Normal;

          *(newNormals + *index) += triangleNormal;
          *(newNormals + *(index + 1)) += triangleNormal;
          *(newNormals + *(index + 2)) += triangleNormal;
        }

        Point3D* normal = newNormals;
        //normalizing all the normals.
        for (int i = 0; i < verticesCount; i++, normal++)
        {
          (*normal).Normalize();
        }
      }

      DisposeVerticesNormals();

      lock (locker)
      {
        unmanagedVerticesNormals = true;
        vertices = newVerticesPointer;
        normals = newNormalsPointer;
        RenderableObject.RenderGeometry.vertices = vertices;
        RenderableObject.RenderGeometry.normals = normals;
        changed = true;
      }
    }

    /// <summary>
    /// Paint should be called by the background worker. 
    /// </summary>
    private void Paint()
    {
      paint = false; 
      int verticesCount = CoreDll.GeodesicGridVerticesCount(Generation);
      
      if (ColorMap == null || ColorableValues == null || ColorableValues.Length != verticesCount)
        return;

      double[] colorable = ColorableValues;
      ColorMap colorMap = ColorMap; 
      
      IntPtr newColors = Marshal.AllocHGlobal(verticesCount * 16);
      unsafe
      {
        ColorFloat* color = (ColorFloat*)newColors.ToPointer();
        for (int i = 0; i < verticesCount; i++, color++)
        {
          *color = colorMap.GetColor(colorable[i]);
        }
      }

      DisposeColors(); 

      lock (locker)
      {
        unmanagedColors = true;
        colors = newColors;
        RenderableObject.RenderGeometry.colors = colors; 
        RenderableObject.RenderGeometry.enableColors = true;
        changed = true; 
      }
    }

    private void DisposeVerticesNormals()
    {
      lock (locker)
      {
        //locking the process to make sure opengl is not currently rendering this object. 
        if (unmanagedVerticesNormals)
        {
          //if the exxageraion is not initialized, 
          //the normal and vertices pointers are pointing to the original geodesic grid. 
          //deleting the old vertices explicitly. 
          Marshal.FreeHGlobal(vertices);
          Marshal.FreeHGlobal(normals);
          unmanagedVerticesNormals = false;
        }
      }
    }
    
    private void DisposeColors()
    {
      lock (locker)
      {
        if (unmanagedColors)
        {
          RenderableObject.RenderGeometry.enableColors = false;
          Marshal.FreeHGlobal(colors);
          unmanagedColors = false;
        }
      }
    }

    private void DisposeUnmanaged()
    {
      DisposeVerticesNormals();
      DisposeColors(); 
    }

    public void Render()
    {
      if (!On)
        return; 
      lock (locker)
      {
        RenderableObject.Render();
      }
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          //dispose managed state (managed objects).
        }

        // free unmanaged resources (unmanaged objects) and override a finalizer below.
        // set large fields to null.
        DisposeUnmanaged(); 

        disposedValue = true;
      }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    ~Planet() {
       // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(false);
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      // GC.SuppressFinalize(this);
    }

    #endregion
  }
}
