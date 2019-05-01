using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
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
    private ColorFloat previousColor = new ColorFloat(1, 1, 1, 1);
    private Point3D previousDirection = new Point3D();
    public Point3D RelativeDirection { get; set; } = new Point3D(-1, 1, 1);
    public bool Changed
    {
      get
      {
        bool changed = false;
        if (On != wasOn)
          changed = true;
        if (previousColor != Color)
          changed = true;
        if (previousDirection != Position)
          changed = true;
        wasOn = On;
        previousColor = Color;
        previousDirection = Position;
        return changed;
      }
    }
    public bool On { get; set; } = true;
    public ColorFloat Color { get; set; } = new ColorFloat();
    public Point3D Position =>
      camera.ForwardNormal * RelativeDirection.x
      + camera.RightNormal * RelativeDirection.y
      + camera.UpNormal * RelativeDirection.z;

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

  public class SunLight : ILight
  {
    private int lightnr;
    private bool on = true;
    private bool changed = true;
    Planet Sun { get; }
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
    public bool On
    {
      get => on;
      set
      {
        changed = true;
        on = value;
      }
    }
    public ColorFloat Color { get; } = new ColorFloat(1, 1, 1);
    public Point3D Position => Sun.Position;

    public SunLight(Planet sun)
    {
      Sun = sun;
    }

    public void Render(int number)
    {
      lightnr = number;

      if (!On)
      {
        Gl.Disable(Light.LightNr(number));
        return;
      }

      Gl.Enable(EnableCap.Lighting);
      Gl.Enable(Light.LightNr(number));
      float[] color = new float[] { Color.R, Color.G, Color.B, Color.A };
      Gl.Light(Light.LightName(number), LightParameter.Diffuse, color);
      Gl.Light(Light.LightName(number), LightParameter.Specular, color);
      SetDirection(new Point3D());
    }

    public void SetDirection(Point3D Target)
    {
      Point3D direction = (Position - Target).Normal;
      float[] positionv = new float[4];
      positionv[0] = (float)direction.x;
      positionv[1] = (float)direction.y;
      positionv[2] = (float)direction.z;
      positionv[3] = 0; //0 = directional light, 1 = point light.
      Gl.Light(Light.LightName(lightnr), LightParameter.Position, positionv);
    }
  }

  public static class Light 
  {
    public static EnableCap LightNr(int number)
    {
      switch (number)
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

}
