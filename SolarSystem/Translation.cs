using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class Transform
  {
    public Point3D Position { get; set; } = new Point3D();
    public Point3D Scale { get; set; } = new Point3D(1, 1, 1);
    public IRotation Rotation { get; set; }
    public bool TranslationActive => Position.x != 0 || Position.y != 0 || Position.z != 0;
    public bool ScaleActive => Scale.x != 1 || Scale.y != 1 || Scale.z != 1;
    public bool RotationActive => Rotation.Active; 

    public void GlScale()
    {
      if (!ScaleActive)
        return;
      Gl.Scale(Scale.x, Scale.y, Scale.z);
    }

    public void GlRotate()
    {
      if (Rotation!=null)
        Rotation.GlRotate();
    }

    public void GlTranslate()
    {
      Gl.Translate(Position.x, Position.y, Position.z);
    }
  }
  
  /// <summary>
  /// Automatically handles the push and pop for opengl. 
  /// </summary>
  public class ApplyTransform : IDisposable
  {
    private Transform Transform { get; }
    private readonly GlPushPop scale;
    private readonly GlPushPop translate;
    private readonly GlPushPop rotate;

    public ApplyTransform(Transform transform)
    {
      Transform = transform;
      scale = new GlPushPop(transform.ScaleActive);
      Transform.GlScale();
      translate = new GlPushPop(transform.TranslationActive);
      Transform.GlTranslate();
      rotate = new GlPushPop(transform.Rotation!=null && transform.RotationActive);
      Transform.GlRotate();
    }

    public void Dispose()
    {
      rotate.Dispose();
      translate.Dispose();
      scale.Dispose();
    }
  }  
}
