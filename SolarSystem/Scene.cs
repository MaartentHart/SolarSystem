using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class Scene
  {
    private bool changed = false;
    private ColorFloat backgroundColor = new ColorFloat();

    public ColorFloat BackgroundColor
    {
      get
      {
        return backgroundColor;
      }
      set
      {
        Changed = true;
        backgroundColor = value; 
      }
    }
    public Camera Camera { get; } = new Camera();
    public List<IRenderable> RenderableObjects { get; } = new List<IRenderable>();
    public bool Changed
    {
      get
      {
        if (Camera.Changed)
          return true;
        foreach (IRenderable renderable in RenderableObjects)
          if (renderable.Changed)
            return true; 

        return changed; 
      }
      set
      {
        changed = value;
      }
    }


    public void Render(int width, int height)
    {
      Changed = false; 

      Gl.ClearColor(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B, BackgroundColor.A);

      Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      Gl.Viewport(0, 0, width, height);
      Gl.MatrixMode(MatrixMode.Projection);
      Gl.LoadIdentity();
      Camera.Set(width, height);
      foreach (IRenderable renderableObject in RenderableObjects)
        renderableObject.Render();
    }
  }

  public interface IPositionObject
  {
    Point3D Position { get; } 
  }

  public class PositionObject: IPositionObject
  {
    public Point3D Position { get; set; }

    public PositionObject(double x = 0, double y = 0, double z = 0)
    {
      Position = new Point3D(x, y, z);
    }

    public PositionObject(Point3D position)
    {
      Position = position; 
    }
  }

  public class Camera
  {
    private double near = 0.001;
    private double far = 1000.0;
    private Point3D previousEye = new Point3D();
    private Point3D previousTarget = new Point3D();
    private double previousNear;
    private double previousFar;
    private double previousFieldOfView; 

    /// <summary>
    /// automatically set the near and far clipping plane. 
    /// </summary>
    public double ViewRadius
    {
      set
      {
        near = 0.001 * value;
        far = 1000.0 * value;
      }
    }
    public double FieldOfView { get; set; } = 25; 

    public IPositionObject Target { get; set; } = new PositionObject(0, 0, 0);
    public IPositionObject Eye { get; set; } = new PositionObject(10, 0, 0); 
    //public double ViewDistance => (Target - Position).Magnitude;
    //public Point3D ViewDirection => (Target - Position) / ViewDistance;
    public Point3D UpVector { get; set; } = new Point3D(0, 0, 1);
    public bool Changed
    {
      get
      {
        bool changed = false;
        if (previousEye != Eye.Position || previousTarget != Target.Position || previousFieldOfView != FieldOfView
          || previousNear != near || previousFar != far)
          changed = true;

        previousEye = new Point3D(Eye.Position);
        previousTarget = new Point3D(Target.Position);
        previousNear = near;
        previousFar = far;
        previousFieldOfView = FieldOfView; 

        return changed;
      }

    }

    public void Set(int width, int height)
    {
      Gl.LoadIdentity(); 
      GluPerspective(FieldOfView, ((double)width) / height, near, far);
      Gl.MatrixMode(MatrixMode.Modelview);
      Gl.LoadIdentity();
     
      GluLookAt(Eye.Position, Target.Position, UpVector);
    }

    void GluPerspective(double fovY, double aspect, double zNear, double zFar)
    {
      //https://stackoverflow.com/questions/12943164/replacement-for-gluperspective-with-glfrustrum
      const double pi = Math.PI;
      double fW, fH;
      fH = Math.Tan(fovY / 360 * pi) * zNear;
      fW = fH * aspect;
      Gl.Frustum(-fW, fW, -fH, fH, zNear, zFar);
    }

    void GluLookAt(Point3D position, Point3D target, Point3D upVector)
    {
      //https://www.gamedev.net/forums/topic/421529-manual-alternative-to-glulookat-/
      //https://www.khronos.org/registry/OpenGL-Refpages/gl2.1/xhtml/gluLookAt.xml
      Point3D dirN;
      Point3D upN;
      Point3D rightN;

      dirN = (target-position).Normal;
      upN = upVector.Normal;
      rightN = dirN.Cross(upN).Normal;
      upN = rightN.Cross(dirN).Normal;

      double[] mat = new double[16];
      mat[0] = rightN.x;
      mat[1] = upN.x;
      mat[2] = -dirN.x;
      mat[3] = 0.0;

      mat[4] = rightN.y;
      mat[5] = upN.y;
      mat[6] = -dirN.y;
      mat[7] = 0.0;

      mat[8] = rightN.z;
      mat[9] = upN.z;
      mat[10] = -dirN.z;
      mat[11] = 0.0;

      mat[12] = -(rightN.Dot(position));
      mat[13] = -(upN.Dot(position));
      mat[14] = (dirN.Dot(position));
      mat[15] = 1.0;

      Gl.MultMatrix(mat);
      Gl.Translate(-position.x, -position.y, -position.z);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="position"></param>
    /// <param name="target"></param>
    /// <param name="upVector">Usually Point3D(0,0,1)</param>
    void GluLookAt2( Point3D position,
                  Point3D target, Point3D upVector)
    {
      //https://www.khronos.org/opengl/wiki/GluLookAt_code
      //https://github.com/openMVG/openMVG/blob/master/src/openMVG/numeric/numeric.cpp
      Point3D forward = (target - position).Normal;
      Point3D side = forward.Cross(upVector).Normal;
      Point3D up = side.Cross(forward).Normal; 


    }
  }

  public class ColorFloat
  {
    public float A { get; set; } = 1.0f;
    public float R { get; set; } = 0.0f;
    public float G { get; set; } = 0.0f;
    public float B { get; set; } = 0.0f;

    public ColorFloat(float r = 0.0f, float g = 0.0f, float b = 0.0f, float a = 1.0f)
    {
      A = a;
      R = r;
      G = g;
      B = b;
    }

    public ColorFloat(System.Drawing.Color color)
    {
      R = color.R / 256f;
      G = color.G / 256f;
      B = color.B / 256f;
      A = 1.0f;
    }
  }
}
