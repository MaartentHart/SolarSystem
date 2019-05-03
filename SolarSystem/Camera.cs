//Copyright Maarten 't Hart 2019
using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{

  public class Camera
  {
    private bool lockDistance = false; 
    private int width;
    private int height; 
    private bool changed = false;
    private double near = 0.001;
    private double far = 1000.0;
    private IPositionObject target = new PositionObject(0, 0, 0);
    private IPositionObject eye = new PositionObject(10, 0, 0);

    //track changes. 
    private Point3D previousEye = new Point3D();
    private Point3D previousTarget = new Point3D();
    private double previousNear;
    private double previousFar;
    private double previousFieldOfView;
    private ColorFloat previousBackgroundColor = new ColorFloat();

    /// <summary>
    /// ViewDistance is used by lockdistance. 
    /// </summary>
    public double ViewDistance { get; set; } = 10;
    public bool LockDistance
    {
      get => lockDistance;
      set
      {
        lockDistance = value;
        UpdateLockDirection(); 
      }
    }

    public Point3D LockDirection { get; set; } = new Point3D(10, 0, 0); 
    public ColorFloat BackgroundColor { get; set; } = new ColorFloat();
    public CameraLight Light { get; }

    public TriadGeometry Triad { get; } = new TriadGeometry();

    public double FieldOfViewRatio => Math.Sin(Angle.ToRadians(FieldOfView / 2));

    /// <summary>
    /// automatically set the near and far clipping plane. 
    /// </summary>
    public double ViewRadius
    {
      set
      {
        ViewDistance = value;
        near = 0.001 * value;
        far = 1000.0 * value;
      }
      get => ViewDistance; 
    }
    public double FieldOfView { get; set; } = 25;
    public double AspectRatio => ((double)width) / height;
    public IPositionObject Target
    {
      get => target;
      set
      {
        target = value;
        ViewRadius = (target.Position - eye.Position).Magnitude;
      }
    }
    public IPositionObject Eye
    {
      get => eye;
      set
      {
        eye = value;
        ViewRadius = (target.Position - eye.Position).Magnitude;
      }
    }

    public Point3D UpVector { get; set; } = new Point3D(0, 0, 1);
    public Point3D ViewDirection => Target.Position - Eye.Position;

    public Point3D ForwardNormal => ViewDirection.Normal;
    public Point3D RightNormal => ViewDirection.Cross(UpVector).Normal;
    public Point3D UpNormal => RightNormal.Cross(ForwardNormal).Normal;

    public Camera()
    {
      Light = new CameraLight(this);
    }

    public bool Changed
    {
      get
      {
        bool changed = this.changed;
        this.changed = false; 
        if (previousEye != Eye.Position || previousTarget != Target.Position || previousFieldOfView != FieldOfView
          || previousNear != near || previousFar != far || BackgroundColor != previousBackgroundColor)
          changed = true;

        previousEye = new Point3D(Eye.Position);
        previousTarget = new Point3D(Target.Position);
        previousNear = near;
        previousFar = far;
        previousFieldOfView = FieldOfView;
        previousBackgroundColor = BackgroundColor;

        if (Light.Changed)
          changed = true;

        return changed;
      }
      set => changed = true; 
    }

    public void Render(int width, int height)
    {
      this.width = width;
      this.height = height; 
      if (LockDistance)
        if (Eye is PositionObject eye)
          eye.Position = Target.Position + LockDirection;

      Gl.ClearColor(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B, BackgroundColor.A);
      Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      Gl.Viewport(0, 0, width, height);

      Light.Render(0);

      if (Triad.On)
      {
        Gl.MatrixMode(MatrixMode.Projection);
        Gl.LoadIdentity();
        GluPerspective(FieldOfView, ((double)width) / height, 0.001, 1000);
        Gl.MatrixMode(MatrixMode.Modelview);
        Gl.LoadIdentity();

        GluLookAt(new Point3D(0, 0, 0), ForwardNormal, UpVector);
        RenderTriad();
      }

      Gl.MatrixMode(MatrixMode.Projection);
      Gl.LoadIdentity();
      GluPerspective(FieldOfView, AspectRatio, near, far);
      Gl.MatrixMode(MatrixMode.Modelview);
      Gl.LoadIdentity();

      GluLookAt(Eye.Position, Target.Position, UpVector);

    }

    private void UpdateLockDirection()
    {
      LockDirection = Eye.Position - Target.Position;
    }

    /// <summary>
    /// Render the XYZ Triad. 
    /// </summary>
    private void RenderTriad()
    {
      if (!Triad.On)
        return;

      double FieldOfViewCorrection = FieldOfViewRatio * 2.5; 
      Triad.Arrows.Transform.Position = ForwardNormal * 3 + RightNormal * -FieldOfViewCorrection * AspectRatio + UpNormal * -FieldOfViewCorrection;
      Point3D scale = new Point3D(0.2,0.2,0.2)*FieldOfViewCorrection;
      foreach (Mesh arrow in Triad.Arrows.Children)
        arrow.Transform.Scale = scale;
      Triad.Arrows.Render(this); 
    }

    public static void GluPerspective(double fovY, double aspect, double zNear, double zFar)
    {
      //https://stackoverflow.com/questions/12943164/replacement-for-gluperspective-with-glfrustrum
      const double pi = Math.PI;
      double fW, fH;
      fH = Math.Tan(fovY / 360 * pi) * zNear;
      fW = fH * aspect;
      Gl.Frustum(-fW, fW, -fH, fH, zNear, zFar);
    }

    void GluLookAt(Point3D eye, Point3D target, Point3D up)
    {
      //https://www.gamedev.net/forums/topic/421529-manual-alternative-to-glulookat-/
      //https://www.khronos.org/registry/OpenGL-Refpages/gl2.1/xhtml/gluLookAt.xml
      // determine the new n
      Point3D vN = (eye - target).Normal;
      // determine the new u by crossing with the up vector
      Point3D vU = up.Cross(vN).Normal;
      // determine v by crossing n and u
      Point3D vV = vN.Cross(vU).Normal;

      // create a model view matrix
      double[] modelView = new double[]
      {
        vU.x,        vV.x,        vN.x,        0.0f,
        vU.y,        vV.y,        vN.y,        0.0f,
        vU.z,        vV.z,        vN.z,        0.0f,
        -eye.Dot(vU), -eye.Dot(vV), -eye.Dot(vN), 1.0f
      };

      // load the model view matrix
      // the model view matrix should already be active
      Gl.LoadMatrix(modelView);
    }

    public void Rotate(int x, int y, bool targetPivot = true, double step = 0.005)
    {
      Point3D difference = ViewDirection;
      double distance = difference.Magnitude;
      Point3D direction = difference / distance;
      double tilt = Math.Asin(direction.z);
      double orientation = Math.Atan2(direction.y, direction.x);

      tilt -= y * step;
      if (tilt > Math.PI / 2)
        tilt = Math.PI / 2;
      if (tilt < -Math.PI / 2)
        tilt = -Math.PI / 2;
      orientation -= x * step;

      Point3D newDirection = new Point3D(Math.Cos(tilt) * Math.Cos(orientation), Math.Cos(tilt) * Math.Sin(orientation), Math.Sin(tilt));
      Point3D shift = newDirection * distance;
      
      if (targetPivot)
      {
        if (Eye is PositionObject eye)
          eye.Position = Target.Position - shift;
      }
      else
      {
        if (Target is PositionObject target)
          target.Position = Eye.Position + shift;
      }

      UpdateLockDirection(); 
    }

    public void Zoom(double zoomFactor)
    {
      if (Eye is PositionObject eye)
      {
        eye.Position = (eye.Position - Target.Position) * zoomFactor + Target.Position;

        //force an update.
        Eye = Eye;
      }
      LockDirection = Eye.Position - Target.Position;
    }

    public void Lookat(IPositionObject target)
    {
      Target = target;
      if (Eye is PositionObject eye && target is Planet planet)
      {
        double viewDistance = planet.Scale.x * 5;
        Point3D direction = eye.Position - Target.Position;
        direction *= (viewDistance / direction.Magnitude);
        eye.Position = Target.Position + direction;
        Eye = Eye;
      }
    }

    public double ViewRatio(Point3D position, double radius)
    {
      return (position - Eye.Position).Magnitude / radius * FieldOfViewRatio / height * 1000;
    }
  }
}
