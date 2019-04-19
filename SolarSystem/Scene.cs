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
    public ColorFloat BackgroundColor { get; set; } = new ColorFloat();
    public Camera Camera { get; } = new Camera();
    public List<RenderableObject> RenderableObjects { get; } = new List<RenderableObject>();

    public void Render(int width, int height)
    {
      Gl.Viewport(0, 0, width, height);
      Gl.ClearColor(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B, BackgroundColor.A);

      Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

      Gl.MatrixMode(MatrixMode.Projection);
      Gl.LoadIdentity();
      Camera.Set(width, height);
      foreach (RenderableObject renderableObject in RenderableObjects)
        renderableObject.Render(); 
    }
  }

  public class Camera
  {
    private double near = 0.001;
    private double far = 1000.0;
    public double ViewRadius
    {
      set
      {
        near = 0.001 * value;
        far = 1000.0 * value;
      }
    }
    public Point3D Target { get; set; }
    public Point3D Position { get; set; }

    public void Set(int width, int height)
    {
      GluPerspective(25.0, width / height, near, far);
      Gl.MatrixMode(MatrixMode.Modelview);
      Gl.LoadIdentity();

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

    void GluLookAt(Point3D pos, Point3D dir, Point3D up)
    {
      //https://www.gamedev.net/forums/topic/421529-manual-alternative-to-glulookat-/
      Point3D dirN;
      Point3D upN;
      Point3D rightN;

      dirN = dir;
      dirN.Normalize();

      upN = up;
      upN.Normalize();

      rightN = dirN.Cross(upN);
      rightN.Normalize();

      upN = rightN.Cross(dirN);
      upN.Normalize();

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

      mat[12] = -(rightN.Dot(pos));
      mat[13] = -(upN.Dot(pos));
      mat[14] = (dirN.Dot(pos));
      mat[15] = 1.0;

      Gl.MultMatrix(mat);
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
  }
}
