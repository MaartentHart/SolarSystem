using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class MeteorShower: IRenderable
  {
    public bool changed = false; 

    public Point3D[] positions;
    public Point3D[] velocities;

    public float PointSize { get; set; }
    public bool On { get ; set; }
    public string Name { get; set; } = "Meteor Shower";

    public bool Changed
    {
      get
      {
        bool ret = changed;
        changed = false;
        return ret; 
      }
      set => changed = value;
    }

    public MeteorShower (Point3D position, Point3D velocity, int generation, double minimumSpeed, double speedStep, int steps)
    {
      int verticesCount = CoreDll.GeodesicGridVerticesCount(generation);
      int totalVerticesCount = verticesCount * steps + 1;
      IntPtr geodesicGridVertices = CoreDll.GeodesicGridIndices(generation);
      byte[] geodesicGridBytes = new byte[verticesCount*24];
      Marshal.Copy(geodesicGridBytes, 0, geodesicGridVertices, verticesCount * 24);
      throw new NotImplementedException(); 
    }

    public void Render(Camera camera)
    {
      throw new NotImplementedException();
    }

    public void SetColorMap(ColorMap colorMap)
    {
      
    }

    public void TimeUpdate()
    {
      throw new NotImplementedException();
    }
  }
}
