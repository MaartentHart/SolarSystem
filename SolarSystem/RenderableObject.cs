using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL; 

namespace SolarSystem
{
  public interface IRenderable
  {
    bool On { get; set; }
    string Name { get; set; }
    bool Changed { get; }

    void Render();
  }

  public class CRenderGeometry
  {
    public enum RenderMode
    {
      triangles,
      points
    }

    public IntPtr vertices;
    public IntPtr indices;
    public IntPtr colors;
    public IntPtr normals; 
    public bool enableColors = false;
    public bool enableNormals = false; 

    public int verticesCount;
    public int indicesCount;
    public RenderMode renderMode;
    public float pointSize = 1;

    public void Render()
    {
      switch (renderMode)
      {
        case RenderMode.triangles:
          RenderTriangles();
          break;
        case RenderMode.points:
          RenderPoints();
          break; 
      }
    }

    private void RenderPoints()
    {
      Gl.EnableClientState(EnableCap.VertexArray);
      Gl.Disable(EnableCap.NormalArray);
      Gl.VertexPointer(verticesCount, VertexPointerType.Double, 0, vertices);
      Gl.Disable(EnableCap.Lighting);
      if (enableColors)
      {
        Gl.EnableClientState(EnableCap.ColorArray);
        Gl.ColorPointer(4, ColorPointerType.Float, 0, colors); 
      }
      else
      {
        Gl.DisableClientState(EnableCap.ColorArray); 
      }
      Gl.PointSize(pointSize);
      Gl.DrawElements(PrimitiveType.Points, verticesCount, DrawElementsType.UnsignedInt, vertices);
    }

    private void RenderTriangles()
    {
      Gl.EnableClientState(EnableCap.VertexArray);
      Gl.VertexPointer(3, VertexPointerType.Double, 0, vertices);
      if (enableNormals)
      {
        Gl.Enable(EnableCap.Lighting);
        Gl.Enable(EnableCap.Normalize); 
        Gl.NormalPointer(NormalPointerType.Double, 0, normals);
        Gl.EnableClientState(EnableCap.NormalArray);
      }
      else
        Gl.DisableClientState(EnableCap.NormalArray);

      if (enableColors)
      {
        Gl.Enable(EnableCap.ColorMaterial);
        Gl.EnableClientState(EnableCap.ColorArray);
        Gl.ColorPointer(4, ColorPointerType.Float, 0, colors);
      }
      else
        Gl.DisableClientState(EnableCap.ColorArray);

      Gl.DrawElements(PrimitiveType.Triangles, indicesCount, DrawElementsType.UnsignedInt, indices);
    }    

    public void SetGeodesicGrid(int generation)
    {
      vertices = CoreDll.GeodesicGridVertices(generation);
      verticesCount = CoreDll.GeodesicGridVerticesCount(generation);

      indices = CoreDll.GeodesicGridIndices(generation);
      indicesCount = CoreDll.GeodesicGridIndicesCount(generation); 

      normals = vertices;
      enableNormals = true;

      renderMode = RenderMode.triangles; 
    }

    public void SetTest()
    {
      vertices = CoreDll.TestVertices();
      verticesCount = CoreDll.TestVerticesCount();

      indices = CoreDll.TestIndices();
      indicesCount = CoreDll.TestIndicesCount();
      renderMode = RenderMode.triangles;
    }
  }

  public class CRenderableObject : IRenderable, IPositionObject
  {
    public string Name { get; set; } = "Default";
    public bool On { get; set; } = true;
    public Translation Translation {get;set;} = new Translation();

    public Point3D Position
    {
      get => Translation.Position;
      set
      {
        Translation.Position = value;
        Changed = true; 
      }
    }

    public Point3D Scale
    {
      get => Translation.Scale;
      set
      {
        Translation.Scale = value;
        Changed = true;
      }
    }
    public Rotation Rotation
    {
      get => Translation.Rotation;
      set
      {
        Translation.Rotation = value;
        Changed = true;
      }
    }

    public CRenderGeometry RenderGeometry { get; set; } = new CRenderGeometry();
    public bool Changed { get; set; } = false; 

    public void Render()
    {
      using (GlPushPop scale = new GlPushPop(Translation.ScaleActive))
      {
        GlScale(); 
        using (GlPushPop rotate = new GlPushPop(Rotation.Active))
        {
          GlRotate();
          using (GlPushPop translate = new GlPushPop(Translation.Active))
          {
            GlTranslate();
            RenderGeometry.Render();
          }
        }
      }   
    }

    public void GlScale()
    {
      if (!Translation.ScaleActive)
        return;
      Gl.Scale(Translation.Scale.x, Translation.Scale.y, Translation.Scale.z);
    }

    public void GlRotate()
    {
      if (!Rotation.Active)
        return;
      Gl.Rotate(Rotation.axisTilt, 1, 0, 0);
      Gl.Rotate(Rotation.axisDirection, 0, 0, 1);
      double sinA = Math.Sin(Rotation.axisTilt);
      Gl.Rotate(Rotation.aroundAxis,
        sinA * Math.Sin(Rotation.axisDirection),
        sinA * Math.Cos(Rotation.axisDirection),
        Math.Cos(Rotation.axisTilt));
    }

    public void GlTranslate()
    {
      Gl.Translate(Position.x, Position.y, Position.z);
    }
  }

  public class GlPushPop : IDisposable
  {
    private readonly bool active;

    public GlPushPop(bool active = true)
    {
      this.active = active; 
      if (active)
        Gl.PushMatrix();
    }

    public void Dispose()
    {
      if (active)
       Gl.PopMatrix();
    }
  }

  public class Mesh : IRenderable
  {
    public int[] indices;
    public float[] colors; 
    public double[] vertices;
    public double[] normals; 
    public bool On { get; set; } = true;
    public string Name { get; set; } = "Mesh";
    public bool Changed { get; set; } = false; 

    public void Render()
    {
      if (vertices == null || indices == null || vertices.Length == 0 || indices.Length == 0)
        return;

      Gl.EnableClientState(EnableCap.VertexArray);
      Gl.VertexPointer(3, VertexPointerType.Double, 0, vertices);
      if (normals!=null && normals.Length == vertices.Length)
      {
        Gl.Enable(EnableCap.Lighting);
        Gl.NormalPointer(NormalPointerType.Double, 0, normals);
        Gl.EnableClientState(EnableCap.NormalArray);
      }
      else
        Gl.DisableClientState(EnableCap.NormalArray);

      if (colors!=null && colors.Length/4 == vertices.Length/3)
      {
        Gl.Enable(EnableCap.ColorMaterial);
        Gl.EnableClientState(EnableCap.ColorArray);
        Gl.ColorPointer(4, ColorPointerType.Float, 0, colors);
      }
      else
        Gl.DisableClientState(EnableCap.ColorArray);

      Gl.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, indices);

    }
  }
}
