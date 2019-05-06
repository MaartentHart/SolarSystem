using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class MeteorShower: IRenderable, IDisposable, IPositionObject
  {
    private readonly object locker = new object(); 
    public bool changed = false;
    
    public CPoint3DArray Positions { get; }
    public CPoint3DArray Velocities { get; }
    public CIntArrray Indices { get; }
    public CColorArrray Colors { get; }

    public int MeteorCount { get; }
    public int ID { get; }
    public float PointSize
    {
      get => RenderObject.pointSize;
      set => RenderObject.pointSize = value;
    }
    public bool On { get; set; } = true;
    public string Name { get; set; } = "Meteor Shower";
    public CRenderGeometry RenderObject { get; }
    public MeteorPositionObject MeteorPosition { get; }

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

    public Point3D Position => MeteorPosition.Position; 

    public MeteorShower (Point3D position, Point3D velocity, int generation, double minimumSpeed, double speedStep, int steps, double initialRadius = 1)
    {
      int verticesCount = CoreDll.GeodesicGridVerticesCount(generation);
      IntPtr geodesicGridVertices = CoreDll.GeodesicGridVertices(generation);

      using (CPoint3DArray source = new CPoint3DArray(verticesCount, geodesicGridVertices, false))
      {
        MeteorCount = verticesCount * steps + 1;

        Positions = new CPoint3DArray(MeteorCount);
        Velocities = new CPoint3DArray(MeteorCount);
        for (int step = 0; step < steps; step++)
        {
          Positions.CopyRange(source, 0, step * verticesCount, verticesCount);
          using (CPoint3DArray scaledVertices = new CPoint3DArray(verticesCount, source.Ptr, true))
          {
            double speed = minimumSpeed + speedStep * step;
            scaledVertices.Scale(speed);
            scaledVertices.Move(velocity);
            Velocities.CopyRange(scaledVertices, 0, step * verticesCount, verticesCount);
          }
        }
        Velocities[MeteorCount - 1] = velocity; 
        Positions.Scale(initialRadius);
        Positions.Move(position); 
      }
      CoreDll.AddFallingObject(Positions.Ptr, Velocities.Ptr, MeteorCount);

      Indices = new CIntArrray(MeteorCount);
      Indices.SetDefaultIndex();

      Colors = new CColorArrray(MeteorCount);
      Colors.SetColor(new ColorFloat(1, 1, 1, 1));

      RenderObject = new CRenderGeometry
      {
        vertices = Positions.Ptr,
        indices = Indices.Ptr,
        colors = Colors.Ptr,
        enableColors = true,
        verticesCount = MeteorCount
      };
      
      RenderObject.renderMode = CRenderGeometry.RenderMode.points;
      MeteorPosition = new MeteorPositionObject(this); 
    }

    public void Render(Camera camera)
    {
      if (!On)
        return;
      lock (locker)
      {
        RenderObject.Render(false);
      }
    }

    public void SetColorMap(ColorMap colorMap)
    {
      
    }

    public void TimeUpdate()
    {
      
    }

    public void Dispose()
    {
      lock (locker)
      {
        CoreDll.RemoveFallingObject(ID);
        Positions?.Dispose();
        Velocities?.Dispose();
        Indices?.Dispose();
        Colors?.Dispose();
      }
    }
  }

  public class MeteorPositionObject : IPositionObject
  {
    private int index;

    public int Index
    {
      get => index;
      set
      {
        if (value < 0 || value >= MeteorShower.Positions.Size)
          throw new ArgumentOutOfRangeException();
        index = value; 
      }
    }

    public MeteorShower MeteorShower { get; }
    public Point3D Position => MeteorShower.Positions[Index];

    public MeteorPositionObject(MeteorShower meteorShower)
    {
      MeteorShower = meteorShower;
      index = meteorShower.Positions.Size - 1; 
    }
  }
}
