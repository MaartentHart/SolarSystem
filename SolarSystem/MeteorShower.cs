//Copyright (C) Maarten 't Hart 2019
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
    public CIntArrray Indices { get; private set;  }
    public CColorArrray Colors { get; private set; }

    public int MeteorCount { get; }
    public int ID { get; private set; }
    public float PointSize
    {
      get => RenderObject.pointSize;
      set => RenderObject.pointSize = value;
    }
    public bool On { get; set; } = true;
    public string Name { get; set; } = "Meteor Shower";
    public CRenderGeometry RenderObject { get; private set; }
    public MeteorPositionObject MeteorPosition { get; private set; }

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


    /// <summary>
    /// Create a spherical meteor shower. 
    /// </summary>
    /// <param name="position"></param>
    /// <param name="velocity"></param>
    /// <param name="generation"></param>
    /// <param name="minimumSpeed"></param>
    /// <param name="speedStep"></param>
    /// <param name="steps"></param>
    /// <param name="initialRadius"></param>
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
      FinishConstructor(); 
    }

    public MeteorShower(Point3D position, Point3D velocity, Point3D sheetNormal, int arrayLength, double spacing)
    {
      MeteorCount = arrayLength * arrayLength;
      Positions = new CPoint3DArray(MeteorCount);
      Velocities = new CPoint3DArray(MeteorCount);

      Point3D xDirection = sheetNormal.Cross(new Point3D(0, 0, 1)).Normal;
      Point3D yDirection = xDirection.Cross(sheetNormal).Normal;

      Point3D gridSize = xDirection * arrayLength * spacing + yDirection * arrayLength * spacing;
      Point3D gridCenter = gridSize / 2; 

      int i = 0;

      for (int y = 0; y < arrayLength; y++)
        for (int x = 0; x < arrayLength; x++, i++)
        {
          Positions[i] = position + xDirection * x * spacing + yDirection * y * spacing - gridCenter;
          Velocities[i] = velocity; 
        }

      FinishConstructor();
    }

    private void FinishConstructor()
    {
      ID = CoreDll.AddFallingObject(Positions.Ptr, Velocities.Ptr, MeteorCount);

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

  public class MeteorShowerSheetTentative : IRenderable
  {
    bool on = true; 
    bool changed = false; 

    public Point3D[] Extents { get; private set; }
    public float PointSize { set => throw new NotImplementedException(); }
    public bool On
    {
      get => on;
      set
      {
        if (on == value)
          return;
        changed = true;
        on = value;
      }
    }

    public string Name { get; set; } = "Sheet Meteorite Shower Position";

    private Mesh mesh; 

    public bool Changed
    {
      get
      {
        bool result = changed;
        changed = false;
        return result; 
      }
      set => changed = value; 
    }

    public MeteorShowerSheetTentative(Point3D position, Point3D sheetNormal, int arrayLength, double spacing)
    {
      SetValues(position, sheetNormal, arrayLength, spacing); 
    }

    public void SetValues(Point3D position, Point3D sheetNormal, int arrayLength, double spacing)
    { 
      Point3D xDirection = sheetNormal.Cross(new Point3D(0, 0, 1)).Normal;
      Point3D yDirection = xDirection.Cross(sheetNormal).Normal;

      Point3D gridSize = xDirection * arrayLength * spacing + yDirection * arrayLength * spacing;
      Point3D gridCenter = gridSize / 2;

      Extents = new Point3D[]
      {
        new Point3D(position - gridCenter),
        new Point3D(position + xDirection * arrayLength * spacing  - gridCenter),
        new Point3D(position + xDirection * arrayLength * spacing   + yDirection * arrayLength * spacing - gridCenter),
        new Point3D(position + yDirection * arrayLength * spacing - gridCenter)
      };

      double[] vertices = new double[]
      {
        Extents[0].x,Extents[0].y,Extents[0].z,
        Extents[1].x,Extents[1].y,Extents[1].z,
        Extents[2].x,Extents[2].y,Extents[2].z,
        Extents[3].x,Extents[3].y,Extents[3].z,
      };

      double[] normals = new double[]
      {
        sheetNormal.x, sheetNormal.y, sheetNormal.z,
        sheetNormal.x, sheetNormal.y, sheetNormal.z,
        sheetNormal.x, sheetNormal.y, sheetNormal.z,
        sheetNormal.x, sheetNormal.y, sheetNormal.z,
      };

      float[] colors = new float[]
      {
        1,1,1,0.5f,
        1,1,1,0.5f,
        1,1,1,0.5f,
        1,1,1,0.5f,
      };

      mesh = new Mesh();
      mesh.vertices = vertices;
      mesh.normals = normals;
      mesh.indices = new int[] { 0, 1, 3, 3, 1, 2 };
      mesh.colors = colors;
      mesh.Transparent = true; 
      changed = true; 
    }

    public void Render(Camera camera)
    {
      if (On)
        mesh?.Render(camera); 
    }

    public void SetColorMap(ColorMap colorMap)
    {

    }

    public void TimeUpdate()
    {

    }
  }
}
