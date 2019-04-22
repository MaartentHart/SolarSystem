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
    private List<IRenderable> PreviousRenderableObjects { get; } = new List<IRenderable>();
    private List<ILight> PreviousLights { get; } = new List<ILight>(); 

    public List<ILight> Lights { get; } = new List<ILight>(); 
    public List<IRenderable> RenderableObjects { get; } = new List<IRenderable>();

    public bool Changed
    {
      get
      {
        bool wasChanged = changed;
        changed = false;

        if (RenderableObjects.Count != PreviousRenderableObjects.Count)
          wasChanged = true;
        else
          for (int i = 0; i < RenderableObjects.Count; i++)
            if (RenderableObjects[i] != PreviousRenderableObjects[i] || RenderableObjects[i].Changed)
              wasChanged = true;

        if (Lights.Count != PreviousLights.Count)
          wasChanged = true;
        else
          for (int i = 0; i < Lights.Count; i++)
            if (Lights[i] != PreviousLights[i] || Lights[i].Changed)
              wasChanged = true; 

        PreviousRenderableObjects.Clear();
        PreviousRenderableObjects.AddRange(RenderableObjects);
        PreviousLights.Clear();
        PreviousLights.AddRange(Lights); 

        return wasChanged;
      }
      set
      {
        changed = value;
      }
    }

    internal void Render()
    {
      if (Lights.Count > 0)
        Gl.Enable(EnableCap.Lighting); 

      int lightCount = Lights.Count;
      //light 0 is reserved for the camera light. 
      if (lightCount > 7)
        //8 lights is the limit. 
        lightCount = 7;
      for (int i = 0; i < lightCount;i++)
        Lights[i].Render(i+1); 
      foreach (IRenderable renderableObject in RenderableObjects)
        renderableObject.Render();
    }

  }

  public interface IPositionObject
  {
    Point3D Position { get; }
  }

  public class PositionObject : IPositionObject
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

    //track changes. 
    private Point3D previousEye = new Point3D();
    private Point3D previousTarget = new Point3D();
    private double previousNear;
    private double previousFar;
    private double previousFieldOfView;
    private ColorFloat previousBackgroundColor = new ColorFloat();

    public ColorFloat BackgroundColor { get; set; } = new ColorFloat();
    public CameraLight Light { get; }

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
        bool changed = false;
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
    }

    public void Render(int width, int height)
    {
      Gl.ClearColor(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B, BackgroundColor.A);
      Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      Gl.Viewport(0, 0, width, height);
      Gl.MatrixMode(MatrixMode.Projection);
      Gl.LoadIdentity();
      GluPerspective(FieldOfView, ((double)width) / height, near, far);
      Gl.MatrixMode(MatrixMode.Modelview);
      Gl.LoadIdentity();

      GluLookAt(Eye.Position, Target.Position, UpVector);
      Light.Render(0); 
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

    public static void GluLookAt(Point3D position, Point3D target, Point3D upVector)
    {
      //https://www.gamedev.net/forums/topic/421529-manual-alternative-to-glulookat-/
      //https://www.khronos.org/registry/OpenGL-Refpages/gl2.1/xhtml/gluLookAt.xml
      Point3D dirN;
      Point3D upN;
      Point3D rightN;

      dirN = (target - position).Normal;
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
    }

    public void Zoom(double zoomFactor)
    {
      if (Eye is PositionObject eye)
        eye.Position = (eye.Position - Target.Position) * zoomFactor + Target.Position; 
    }
  }

  public interface ILight : IPositionObject
  {
    bool Changed { get; }
    bool On { get; }
    ColorFloat Color { get; }
    void Render(int number); 
  }

  public class CameraLight : ILight
  {
    private Camera camera;

    //track changes. 
    private bool wasOn;
    private ColorFloat previousColor = new ColorFloat(1,1,1,1);
    private Point3D previousPosition = new Point3D(); 

    public Point3D relativePosition = new Point3D(0, 5, 5);
    
    public bool Changed
    {
      get
      {
        bool changed = false;
        if (On != wasOn)
          changed = true;
        if (previousColor != Color)
          changed = true;
        if (previousPosition != Position)
          changed = true;
        wasOn = On;
        previousColor = Color; 
        previousPosition = Position;
        return changed; 
      }
    }

    public bool On { get; set; } = true;

    public ColorFloat Color { get; set; } = new ColorFloat(); 

    public Point3D Position => camera.Eye.Position
      + camera.ForwardNormal * relativePosition.x
      + camera.RightNormal * relativePosition.y
      + camera.UpNormal * relativePosition.z; 

    public CameraLight(Camera camera)
    {
      this.camera = camera; 
    }

    public void Render(int number)
    {
      if (!On)
      {
        Gl.Disable(EnableCap.Lighting);
        Gl.Disable(Light.LightNr(number));
        return; 
      }

      Gl.Enable(EnableCap.Lighting); 
      Gl.Enable(Light.LightNr(number));
      float[] position = new float[4];
      position[0] = (float)Position.x;
      position[1] = (float)Position.y;
      position[2] = (float)Position.z;
      position[3] = 0; //0 = directional light, 1 = point light.
      Gl.Light(Light.LightName(number), LightParameter.Position, position);
    }
  }

  public class Light : ILight
  {
    public bool Changed => throw new NotImplementedException();

    public bool On => throw new NotImplementedException();

    public ColorFloat Color => throw new NotImplementedException();

    public Point3D Position => throw new NotImplementedException();

    public void Render(int number)
    {
      throw new NotImplementedException();
    }

    public static EnableCap LightNr(int number)
    {
      switch(number)
      {
        case 0:
          return EnableCap.Light0;
        case 1:
          return EnableCap.Light1;
        case 2:
          return EnableCap.Light2;
        case 3:
          return EnableCap.Light3;
        case 4:
          return EnableCap.Light4;
        case 5:
          return EnableCap.Light5;
        case 6:
          return EnableCap.Light6;
        case 7:
          return EnableCap.Light7;
      }

      throw new Exception("OpenGL supports Light0 to Light7. Number is " + number.ToString());
    }

    public static LightName LightName(int number)
    {
      switch (number)
      {
        case 0:
          return OpenGL.LightName.Light0;
        case 1:
          return OpenGL.LightName.Light1;
        case 2:
          return OpenGL.LightName.Light2;
        case 3:
          return OpenGL.LightName.Light3;
        case 4:
          return OpenGL.LightName.Light4;
        case 5:
          return OpenGL.LightName.Light5;
        case 6:
          return OpenGL.LightName.Light6;
        case 7:
          return OpenGL.LightName.Light7;
      }

      throw new Exception("OpenGL supports Light0 to Light7. Number is " + number.ToString());
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

    public static bool operator==(ColorFloat a, ColorFloat b)
    {
      return a.A == b.A && a.B == b.B && a.G == b.G && a.R == b.R; 
    }

    public static bool operator !=(ColorFloat a, ColorFloat b)
    {
      return a.A != b.A || a.B != b.B || a.G != b.G || a.R != b.R;
    }

    public override bool Equals(object obj)
    {
      var @float = obj as ColorFloat;
      return @float != null &&
             A == @float.A &&
             R == @float.R &&
             G == @float.G &&
             B == @float.B;
    }

    public override int GetHashCode()
    {
      var hashCode = -1749689076;
      hashCode = hashCode * -1521134295 + A.GetHashCode();
      hashCode = hashCode * -1521134295 + R.GetHashCode();
      hashCode = hashCode * -1521134295 + G.GetHashCode();
      hashCode = hashCode * -1521134295 + B.GetHashCode();
      return hashCode;
    }
  }
}
