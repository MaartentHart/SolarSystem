using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class MeteorShower: IRenderable, IDisposable
  {
    public bool changed = false;
    
    public CPoint3DArray positions;
    public CPoint3DArray velocities;

    public int MeteorCount { get; }
    public int ID { get; }
    public float PointSize { get; set; } = 3;
    public bool On { get; set; } = true;
    public string Name { get; set; } = "Meteor Shower";
    public CRenderGeometry RenderObject { get; }

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

    public MeteorShower (Point3D position, Point3D velocity, int generation, double minimumSpeed, double speedStep, int steps, double initialRadius = 1)
    {
      int verticesCount = CoreDll.GeodesicGridVerticesCount(generation);
      IntPtr geodesicGridVertices = CoreDll.GeodesicGridVertices(generation);

      using (CPoint3DArray source = new CPoint3DArray(verticesCount, geodesicGridVertices, false))
      {
        MeteorCount = verticesCount * steps + 1;

        positions = new CPoint3DArray(MeteorCount);
        velocities = new CPoint3DArray(MeteorCount);
        for (int step = 0; step < steps; step++)
        {
          positions.CopyRange(source, 0, step * verticesCount, verticesCount);
          using (CPoint3DArray scaledVertices = new CPoint3DArray(verticesCount, source.Ptr, true))
          {
            double speed = minimumSpeed + speedStep * step;
            scaledVertices.Scale(speed);
            scaledVertices.Move(velocity);
            velocities.CopyRange(scaledVertices, 0, step * verticesCount, verticesCount);
          }
        }
        positions.Scale(initialRadius);
        positions.Move(position); 
      }
      CoreDll.AddFallingObject(positions.Ptr, velocities.Ptr, MeteorCount);

      CIntArrray indices = new CIntArrray(verticesCount);
      indices.SetDefaultIndex();

      RenderObject = new CRenderGeometry
      {
        vertices = positions.Ptr,
        indices = indices.Ptr
      };


      RenderObject.renderMode = CRenderGeometry.RenderMode.points; 

    }

    public void Render(Camera camera)
    {
      RenderObject.Render(false);
    }

    public void SetColorMap(ColorMap colorMap)
    {
      
    }

    public void TimeUpdate()
    {
      
    }

    public void Dispose()
    {
      CoreDll.RemoveFallingObject(ID); 
      positions?.Dispose();
      velocities?.Dispose(); 
    }
  }
}
