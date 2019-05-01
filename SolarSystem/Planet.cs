using OpenGL;
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
    public static float pointSize = 3;
    public static double maxRenderRatio = 1000;

    private int id = -1;
    private bool on = true;
    private double previousExxageration = 0;
    private double exxageration = 0;
    private readonly object locker = new object();
    private bool unmanagedVerticesNormals = false;
    private bool unmanagedColors = false;
    private IntPtr normals;
    private IntPtr vertices;
    private IntPtr colors;
    private ColorFloat color;
    private bool exxagerationChanged = true;
    private bool paintChanged = true;
    private bool changed = true; 

    public int Generation { get; }
    public SolarSystemPlanet PlanetID { get; }
    public CRenderableObject RenderableObject { get; } = new CRenderableObject();
    public HeightMap HeightMap { get; set; }
    //public Shader Shader { get; }
    //public ColorFloat[] Color { get; set; }
    public Point3D Scale { get; }
    public double[] ColorableValues { get; set; }
    public ColorMap ColorMap { get; set; }
    public double AroundAxisRotation { get; set; }
    public double MaximumRadius { get; set; }
    public BoundingBox BoundingBox => new BoundingBox(Position, MaximumRadius);

    public int ID => id; 

    public bool ExxagerationChanged
    {
      get
      {
        bool ret = exxagerationChanged; 
        exxagerationChanged = false;
        return ret;
      }
    }

    public bool PaintChanged
    {
      get
      {
        bool ret = paintChanged;
        paintChanged = false;
        return ret; 
      }
    }

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
        exxagerationChanged = true;
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

    public Point3D Position
    {
      get => RenderableObject.Position;
      set => RenderableObject.Position = value; 
    }
    
    public Quaternion RotationAxis { get; set; }

    public Planet(SolarSystemPlanet planet, int generation = 9)
    {
      Generation = generation;
      PlanetID = planet;
      RenderableObject.RenderGeometry.SetGeodesicGrid(generation);
      HeightMap = new HeightMap(planet, generation);
      //Shader = new Shader("PlanetHeightMapVertex", "TestFrag", PlanetUniforms, PlanetAttributes); 
      //Color = new ColorFloat[CoreDll.GeodesicGridVerticesCount(9)];
      Name = planet.ToString();
      CoreDll.SetActivePlanet(planet.ToString());
      
      Scale = new Point3D(CoreDll.PlanetScaleX(), CoreDll.PlanetScaleY(), CoreDll.PlanetScaleZ());
      MaximumRadius = Scale.x> Scale.y? Scale.x > Scale.z? Scale.x : Scale.z : Scale.y > Scale.z ? Scale.y: Scale.z; 
      CoreDll.PlanetColor(ref color);

      if (HeightMap.Valid)
        ColorableValues = HeightMap.Heights;
      else
        SetColorMap(new ColorMap(color));

      SetExxageration(1.0);
    }

    public void SetExxageration(double scale)
    {
      if (exxageration == scale)
        return;
      exxageration = scale;
      exxagerationChanged = true;
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

      //tell the scene backgroundworker to repaint. 
      paintChanged = true;
    }

    //should be called by the backgroundworker. 
    internal void ApplyExxageration()
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
          double newMagnitude = magnitude;
          if (HeightMap.Valid)
            newMagnitude += HeightMap.Heights[i] * 0.001 * exxageration;

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
    internal void Paint()
    {
      int verticesCount = CoreDll.GeodesicGridVerticesCount(Generation);

      if (ColorMap == null)
        return;

      bool singleColor = false;
      if (ColorableValues == null || ColorableValues.Length != verticesCount)
        singleColor = true;

      double[] colorable = ColorableValues;
      ColorMap colorMap = ColorMap;

      IntPtr newColors = Marshal.AllocHGlobal(verticesCount * 16);
      unsafe
      {
        ColorFloat* color = (ColorFloat*)newColors.ToPointer();
        for (int i = 0; i < verticesCount; i++, color++)
        {
          if (singleColor)
            *color = colorMap.StartColor;
          else
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

    public void Render(Camera camera)
    {
      if (!On)
        return;

      lock (locker)
      {
        RenderPoint();

        //don't render if it's too far away. 
        if ((Position - camera.Eye.Position).Magnitude / MaximumRadius < maxRenderRatio)
        {
          using (GlPushPop rotationPushPop = new GlPushPop())
          {
            if (RotationAxis!=null)
              RotationAxis.GlRotate();
            RenderableObject.Render(camera);
          }
        }
      }
    }

    private void RenderPoint()
    {
      Point3D[] vertices = new Point3D[] { Position };
      ColorFloat[] colors = new ColorFloat[] { color };
      int[] indices = new int[] { 0 };

      Gl.Disable(EnableCap.NormalArray);
      Gl.EnableClientState(EnableCap.VertexArray);
      Gl.VertexPointer(3, VertexPointerType.Double, 0, vertices);
      Gl.Disable(EnableCap.Lighting);
      Gl.EnableClientState(EnableCap.ColorArray);
      Gl.ColorPointer(4, ColorPointerType.Float, 0, colors);
      Gl.PointSize(pointSize);
      Gl.DrawElements(PrimitiveType.Points, 1, DrawElementsType.UnsignedInt, indices);
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

    public void TimeUpdate()
    {
      SetActive();
      RenderableObject.Transform.Position = new Point3D(
        CoreDll.PlanetPositionX(), 
        CoreDll.PlanetPositionY(), 
        CoreDll.PlanetPositionZ());
      AroundAxisRotation = CoreDll.PlanetRotation(); 
    }

    private void SetActive()
    {
      if (id != -1)
        CoreDll.SetActivePlanetID(id);
      else
        id = CoreDll.SetActivePlanet(Name);
    }

    #endregion
  }
}
