using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class PlanetaryRingSystem : IRenderable, IDisposable
  {
    object locker = new object(); 
    private Planet planet;
    private double ringRadius;
    private string ringTexture;
    private double ringTextureInnerRadius;
    private bool unmanagedColors;

    public CRenderableObject RenderableObject { get; }
    public Transform Transform { get; set; } = new Transform(); 

    public PlanetaryRingSystem(Planet planet, double ringRadius, string ringTexture, double ringTextureInnerRadius)
    {     
      this.planet = planet;
      this.ringRadius = ringRadius;
      this.ringTexture = ringTexture;
      this.ringTextureInnerRadius = ringTextureInnerRadius;
      Name = planet.Name + " Ring System";
      On = true;

      if (!System.IO.File.Exists(ringTexture))
      {
        On = false;
        return; 
      }
      double innerRadiusRatio = ringTextureInnerRadius / ringRadius; 

      RenderableObject = new CRenderableObject(); 
      RenderableObject.RenderGeometry.SetGeodesicGrid(planet.Generation);
      RenderableObject.Scale = new Point3D(ringRadius, ringRadius, ringRadius/10000);
      int verticesCount = CoreDll.GeodesicGridVerticesCount(planet.Generation); 
      lock(locker)
        RenderableObject.RenderGeometry.colors = CMemoryBlock.Allocate(verticesCount * 16);
      unmanagedColors = true; 
      RenderableObject.RenderGeometry.enableColors = true;
      RenderableObject.RenderGeometry.Transparent = true; 
      Texture texture = new Texture(ringTexture);
      texture.ApplyRing(RenderableObject.RenderGeometry.colors, planet.Generation, innerRadiusRatio);
    }

    public float PointSize { set { }}
    public bool On { get; set; }
    public string Name { get; set ;}

    public bool Changed => false;

    public int Generation => planet.Generation;

    public Point3D Position => RenderableObject.Position; 

    public void Render(Camera camera)
    {
      SetDetailLevel(camera); 
      using (ApplyTransform apply = new ApplyTransform(Transform))
        RenderableObject.Render(camera); 
    }

    public void SetColorMap(ColorMap colorMap)
    {
      
    }

    public void TimeUpdate()
    {

    }
    private void DisposeColors()
    {
      lock (locker)
      {
        if (unmanagedColors)
        {
          RenderableObject.RenderGeometry.enableColors = false;
          CMemoryBlock.Free(RenderableObject.RenderGeometry.colors);
          unmanagedColors = false;
        }
      }
    }

    private void SetDetailLevel(Camera camera)
    {
      int indicesCount;
      IntPtr indices;

      int displayGeneration = Generation;

      double ratio = camera.ViewRatio(Transform.Position, ringRadius);
      double logRatio = Math.Log(ratio, 2);
      int desiredQuality = 10 - Convert.ToInt32(Math.Floor(logRatio));

      if (desiredQuality < displayGeneration)
        displayGeneration = desiredQuality;

      if (Planet.MaximumDisplayGeneration < displayGeneration)
        displayGeneration = Planet.MaximumDisplayGeneration;

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

    public void Dispose()
    {
      DisposeColors(); 
    }
  }
}
