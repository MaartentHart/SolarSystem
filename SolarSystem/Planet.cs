//Copyright Maarten 't Hart 2019
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
  
  /// <summary>
  /// Depricated hard coded planets. 
  /// </summary>
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

    //Jupiters moons
    [StringValue("Io")] Io,
    [StringValue("Europa")] Europa,
    [StringValue("Ganymede")] Ganymede,
    [StringValue("Callisto")] Callisto,

    //Saturns moons
    [StringValue("Titan")] Titan,
    [StringValue("Mimas")] Mimas,
    [StringValue("Enceladus")] Enceladus,
    [StringValue("Tethys")] Tethys,
    [StringValue("Dione")] Dione,
    [StringValue("Rhea")] Rhea,
    [StringValue("Hyperion")] Hyperion,
    [StringValue("Iapetus")] Iapetus,

    //Uranus moons
    [StringValue("Miranda")] Miranda,
    [StringValue("Ariel")] Ariel,
    [StringValue("Umbriel")] Umbriel,
    [StringValue("Titania")] Titania,
    [StringValue("Oberon")] Oberon,

	  //Neptunes moons
    [StringValue("Triton")] Triton,

    //Plutos moons
    [StringValue("Charon")] Charon,

    //Other
    [StringValue("Ceres")] Ceres,
    [StringValue("Pallas")] Pallas,
    [StringValue("Vesta")] Vesta,

  }

  /// <summary>
  /// The renderable class of the planet. 
  /// </summary>
  public class Planet : IRenderable, IDisposable, IPositionObject
  {
    private Layer activeLayer; 
    private double rotationCalibration; 
    private Quaternion rotationAxis = new Quaternion(); 
    private static float pointSize = 3;
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
    private bool changed = true;

    public static double MaxRenderRatio { get; set; } = 1000;
    public static int MaximumDisplayGeneration { get; set; } = 9;

    public float PointSize { get => pointSize; set => pointSize = value; }
    public int Generation { get; }
    public SolarSystemPlanet PlanetID { get; }
    public CRenderableObject RenderableObject { get; } = new CRenderableObject();
    public HeightMap HeightMap { get; set; }
    public Layer ValueLayer { get; }
    public Layer TextureLayer { get; set; }
    public Point3D Scale { get; }
    public double[] ColorableValues => ActiveLayer.Values; 

    public ColorMap ColorMap { get => ActiveLayer.ColorMap;
      set => ActiveLayer.ColorMap = value; }
    public List<Layer> Layers { get; } = new List<Layer>();

    public Layer ActiveLayer
    {
      get
      {
        if (activeLayer == null)
        {
          if (Layers.Count == 0 || Layers[0] == null)
          {
            activeLayer = new Layer("Default");
            if (Layers.Count == 0)
              Layers.Add(activeLayer);
            else
              Layers[0] = activeLayer;
          }
          else
            activeLayer = Layers[0];
        }
        return activeLayer;
      }
      set
      {
        if (value == null)
          return;
        activeLayer = value; 
        foreach (Layer layer in Layers)
          if (layer == value)
            return;
        Layers.Add(value);
      }
    }

    internal void InitializeColors()
    {
      if (colors != IntPtr.Zero)
        return;

      lock(locker)
        colors = CMemoryBlock.Allocate(CoreDll.GeodesicGridVerticesCount(Generation) * 16);

      ActiveLayer.Repaint = true; 
    }

    //rotation
    public double AroundAxisRotation { get; set; }
    public Quaternion RotationAxis
    {
      get => rotationAxis;
      set
      {
        rotationAxis = value; 
        if (ID!=-1)
          CoreDll.SetPlanetBaseRotation(ID, rotationAxis.x, rotationAxis.y, rotationAxis.z, rotationAxis.w);
      }
    }

    public double RotationCalibration
    {
      get => rotationCalibration;
      set
      {
        rotationCalibration = value;
        if (ID!= -1)
          CoreDll.SetPlanetRotationCalibration(ID, rotationCalibration);
      }
    }
    public Quaternion LocalRotation { get; set; } = new Quaternion(); 
    public DoubleRotation Rotation => new DoubleRotation(RotationAxis, LocalRotation); 

    public double MaximumRadius { get; set; }
    public BoundingBox BoundingBox => new BoundingBox(Position, MaximumRadius);

    public int ID
    {
      get => id;
      set
      {
        id = value;
        RotationCalibration = RotationCalibration;
        RotationAxis = RotationAxis; 
      }
    }
    public double Declination { get; private set; }
    public double RightAscension { get; private set; }

    public Point3D GetVelocity()
    {
      double time = CoreDll.GetTime();
      Point3D positionAtTime = new Point3D();
      Point3D positionNextSecond = new Point3D();

      CoreDll.PlanetPositionAt(ID, time, ref positionAtTime);
      time += 1.0 / 86400;
      CoreDll.PlanetPositionAt(ID, time, ref positionNextSecond);

      return positionNextSecond - positionAtTime; 
    }

    public IntPtr GetColors()
    {
      if (colors == IntPtr.Zero)
        throw new Exception("Colors are not initialized."); 
      return colors; 
    }
    public bool ExxagerationChanged
    {
      get
      {
        bool ret = exxagerationChanged; 
        exxagerationChanged = false;
        return ret;
      }
      set
      {
        if (value == true)
          exxagerationChanged = true; 
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
        changed = true; 
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
    public PlanetaryRingSystem RingSystem { get; internal set; }

    /// <summary>
    /// Old method, using hard coded values in stead of CSV. 
    /// </summary>
    /// <param name="planet"></param>
    /// <param name="generation"></param>
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
      Declination = CoreDll.PlanetDeclination();
      RightAscension = CoreDll.PlanetRightAscension(); 
      MaximumRadius = Scale.x> Scale.y? Scale.x > Scale.z? Scale.x : Scale.z : Scale.y > Scale.z ? Scale.y: Scale.z; 
      CoreDll.PlanetColor(ref color);

      if (HeightMap.Valid)
        AddLayer("HeightMap", HeightMap.Heights);

      Layer defaultLayer = AddLayer("Default", null);
      defaultLayer.ColorMap = new ColorMap(color);

      int verticesCount = CoreDll.GeodesicGridVerticesCount(Generation);
      ValueLayer = AddLayer("Value", new double[verticesCount]);
      ValueLayer.ColorMap = new ColorMap("White0ToBlack1000"); 
      
      RotationCalibration = RotationCalibrationOf(planet);
      SetExxageration(1.0);
    }

    public Planet(int id, string name, double calibaration, int generation = 9)
    {
      Generation = generation;
      this.id = id;
      RenderableObject.RenderGeometry.SetGeodesicGrid(generation);
      string heightMapFileName = @"Resource\" + name + ".map";
      HeightMap = new HeightMap(heightMapFileName, this, false);
      //Shader = new Shader("PlanetHeightMapVertex", "TestFrag", PlanetUniforms, PlanetAttributes); 
      //Color = new ColorFloat[CoreDll.GeodesicGridVerticesCount(9)];
      Name = name;
      CoreDll.SetActivePlanet(name);

      Scale = new Point3D(CoreDll.PlanetScaleX(), CoreDll.PlanetScaleY(), CoreDll.PlanetScaleZ());
      Declination = CoreDll.PlanetDeclination();
      RightAscension = CoreDll.PlanetRightAscension();
      MaximumRadius = Scale.x > Scale.y ? Scale.x > Scale.z ? Scale.x : Scale.z : Scale.y > Scale.z ? Scale.y : Scale.z;
      CoreDll.PlanetColor(ref color);

      if (HeightMap.Valid)
        AddLayer("HeightMap", HeightMap.Heights);

      Layer defaultLayer = AddLayer("Default", null);
      defaultLayer.ColorMap = new ColorMap(color);

      int verticesCount = CoreDll.GeodesicGridVerticesCount(Generation);
      ValueLayer = AddLayer("Value", new double[verticesCount]);
      ValueLayer.ColorMap = new ColorMap("White0ToBlack1000");

      RotationCalibration = calibaration;
      SetExxageration(1.0);
    }

    public void ActivateLayer(string layerName)
    {
      if (ActiveLayer.Name == layerName)
        return;

      foreach (Layer layer in Layers)
        if (layer.Name == layerName)
        {
          ActiveLayer = layer;
          ActiveLayer.Repaint = true;
        }
    }

    private Layer AddLayer(string name, double[] values)
    {
      Layer layer = new Layer(name, values);
      Layers.Add(layer);
      return layer; 
    }

    public void SetExxageration(double scale)
    {
      if (exxageration == scale)
        return;
      exxageration = scale;
      exxagerationChanged = true;
    }
      
    public void SetColorMap(ColorMap colorMap)
    {
      ColorMap = colorMap;

      //tell the scene backgroundworker to repaint. 
    }

    //should be called by the backgroundworker. 
    internal void ApplyExxageration()
    {
      previousExxageration = exxageration;

      IntPtr geodesicGridVerticesPointer = CoreDll.GeodesicGridVertices(Generation);
      IntPtr geodesicGridIndicesPointer = CoreDll.GeodesicGridIndices(Generation);
      int verticesCount = CoreDll.GeodesicGridVerticesCount(Generation);
      int indicesCount = CoreDll.GeodesicGridIndicesCount(Generation);

      IntPtr newVerticesPointer = CMemoryBlock.Allocate(verticesCount * 24);
      IntPtr newNormalsPointer = CMemoryBlock.Allocate(verticesCount * 24);
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
          (*normal).Normalize();
      }

      lock (locker)
      {
        DisposeVerticesNormals();
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

      IntPtr newColors;

      if (ActiveLayer.UseTexture)
      {
        TextureCache textureCache = new TextureCache(this);
        if (textureCache.TryLoad())
          return;

        //cache loading did not work. 
        newColors = CMemoryBlock.Allocate(verticesCount * 16);
        ActiveLayer.Texture.Apply(newColors, Generation);
        textureCache.AlternativeColorArray = newColors;
        textureCache.Save();
      }
      else
      {
        if (ColorMap == null)
          return;

        bool singleColor = false;
        if (ColorableValues == null || ColorableValues.Length != verticesCount)
          singleColor = true;

        double[] colorable = ColorableValues;
        ColorMap colorMap = ColorMap;

        if (ActiveLayer.Name == "Default")
          ColorMap = new ColorMap(color); 

        newColors = CMemoryBlock.Allocate(verticesCount * 16);
        unsafe
        {
          ColorFloat* color = (ColorFloat*)newColors.ToPointer();
          if (singleColor)
            for (int i = 0; i < verticesCount; i++, color++)
              *color = colorMap.StartColor;
          else
            for (int i = 0; i < verticesCount; i++, color++)
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
      }
      Changed = true;
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
          CMemoryBlock.Free(vertices);
          CMemoryBlock.Free(normals);
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
          CMemoryBlock.Free(colors);
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

      if (Position.HasNaN)
        return; 

      lock (locker)
      {
        SetDetailLevel(camera);
        if (!camera.IgnoreObjectPositions)
          RenderPoint();

        //don't render if it's too far away. 
        double ratio = camera.ViewRatio(Position, MaximumRadius);
        if (ratio < MaxRenderRatio)
        {
          using (GlPushPop rotationPushPop = new GlPushPop())
          {
            if (RotationAxis != null)
            {
              RenderableObject.Transform.Rotation = Rotation;
            }

            RenderableObject.Render(camera);

            if (RingSystem != null)
            {
              RingSystem.Transform.Position = Position;
              if (RotationAxis != null)
                RingSystem.Transform.Rotation = Rotation.SystemRotation;
              RingSystem.Render(camera);
            }
          }
        }
      }
    }

    private void SetDetailLevel(Camera camera)
    {
      int indicesCount;
      IntPtr indices;

      int displayGeneration = Generation;

      double ratio = camera.ViewRatio(Position, MaximumRadius);
      double logRatio = Math.Log(ratio, 2);
      int desiredQuality = 10 - Convert.ToInt32(Math.Floor(logRatio));

      if (desiredQuality < displayGeneration)
        displayGeneration = desiredQuality;

      if (MaximumDisplayGeneration < displayGeneration)
        displayGeneration = MaximumDisplayGeneration;

      if (displayGeneration < 0)
        displayGeneration = 0;

      if (displayGeneration >= Generation)
      {
        indicesCount = CoreDll.GeodesicGridIndicesCount(Generation);
        indices = CoreDll.GeodesicGridIndices(Generation);
      }
      else
      {
        indicesCount = CoreDll.GeodesicGridIndicesCount(displayGeneration);
        indices = CoreDll.GeodesicGridMipMapIndices(Generation, displayGeneration);
      }

      RenderableObject.RenderGeometry.indices = indices;
      RenderableObject.RenderGeometry.indicesCount = indicesCount;
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

    public void TimeUpdate()
    {
      SetActive();
      RenderableObject.Transform.Position = new Point3D(
        CoreDll.PlanetPositionX(),
        CoreDll.PlanetPositionY(),
        CoreDll.PlanetPositionZ());
      AroundAxisRotation = CoreDll.PlanetRotation();
      LocalRotation = new Quaternion(new Point3D(0, 0, 1), AroundAxisRotation + RotationCalibration);
    }

    private void SetActive()
    {
      if (ID != -1)
        CoreDll.SetActivePlanetID(ID);
      else
        ID = CoreDll.SetActivePlanet(Name);
    }

    private double RotationCalibrationOf(SolarSystemPlanet planet)
    {
      switch(planet)
      {
        case SolarSystemPlanet.Earth:
          return 180;
        case SolarSystemPlanet.Moon:
          return 74;
        case SolarSystemPlanet.Mars:
          return 250;
        default:
          return 0; 
      }
    }

    /// <summary>
    /// Gets the inclination of the planets axis relative to its orbit normal in radian.  
    /// </summary>
    /// <returns></returns>
    public double GetInclination()
    {
      Point3D orbitNormal = new Point3D();
      Point3D axisNormal = Rotation.SystemRotation.Rotate(new Point3D(0, 0, 1)); 
      CoreDll.GetOrbitNormal(ID, ref orbitNormal);
      double distance = (orbitNormal - axisNormal).Magnitude;
      return 2 * Math.Asin(distance / 2);
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

    public Layer AddTexture(string fileName, double rotation = 0, bool messageNotExists = true)
    {
      if (!System.IO.File.Exists(fileName))
      {
        if (messageNotExists)
          System.Windows.Forms.MessageBox.Show("Texture file does not exist " + fileName, "Error");
        return null; 
      }
      string layerName = "Texture";
      bool nameExists = false;
      int count = 0;

      do
      {
        nameExists = false; 
        string checkLayerName = layerName;
        if (count != 0)
          checkLayerName += " " + count.ToString();
        foreach (Layer layer in Layers)
        {
          if (layer.Name == checkLayerName)
          {
            nameExists = true;
            count++;
          }
        }
      } while (nameExists);
      if (count!=0)
        layerName += " " + count.ToString();

      Layer textureLayer = new Layer(layerName);
      textureLayer.Texture = new Texture(fileName, rotation);

      if (TextureLayer == null)
        TextureLayer = textureLayer;

      Layers.Add(textureLayer);
      return textureLayer; 
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
