using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL; 

namespace SolarSystem
{
  public class RenderGeometry
  {
    public enum RenderMode
    {
      triangles,
      points
    }

    public IntPtr vertices;
    public IntPtr indices;
    public IntPtr colors;
    public bool enableColors = false; 
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
      throw new NotImplementedException();
    }
  }

  public class RenderableObject
  {
    public string Name { get; set; } = "Default";
    public bool On { get; set; } = true;
    public Translation Translation {get;set;} = new Translation();

    public Point3D Position
    {
      get => Translation.Position;
      set => Translation.Position = value; 
    }

    public Rotation Rotation
    {
      get => Translation.Rotation;
      set => Translation.Rotation = value; 
    }

    public RenderGeometry RenderGeometry { get; set; } = new RenderGeometry();

    public void Render()
    {
      using (GlPushPop rotate = new GlPushPop())
      {
        GlRotate();
        using (GlPushPop translate = new GlPushPop())
        {
          GlTranslate();
          RenderGeometry.Render(); 
        }
      }     
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
    public GlPushPop()
    {
      Gl.PushMatrix();
    }

    public void Dispose()
    {
      Gl.PopMatrix();
    }
  }
}
