using OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class Scene
  {
    private static Scene mainScene; 
    private BackgroundWorker decorationBackgroundWorker;
    private double exxageration = 0; 
    private bool changed = false;
    private List<IRenderable> PreviousRenderableObjects { get; } = new List<IRenderable>();
    private List<ILight> PreviousLights { get; } = new List<ILight>();

    public Scene MainScene => mainScene;
    public bool IsMainScene => mainScene == this;  
    public List<ILight> Lights { get; } = new List<ILight>(); 
    public List<IRenderable> RenderableObjects { get; } = new List<IRenderable>();
    public List<GravityObject> GravityObjects { get; } = new List<GravityObject>(); 

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

    public double Exxageration
    {
      get
      {
        return exxageration; 
      }
      set
      {
        if (exxageration == value)
          return;
        exxageration = value; 
        foreach (IRenderable renderable in RenderableObjects)
          if (renderable is Planet planet)
            planet.SetExxageration(exxageration);
      }
    }

    internal void Render(Camera camera)
    {
      try
      {
        if (Lights.Count > 0)
          Gl.Enable(EnableCap.Lighting);

        int lightCount = Lights.Count;
        //light 0 is reserved for the camera light. 
        if (lightCount > 7)
          //8 lights is the limit. 
          lightCount = 7;
        for (int i = 0; i < lightCount; i++)
          Lights[i].Render(i + 1);
        foreach (IRenderable renderableObject in RenderableObjects)
          renderableObject.Render(camera);
      }
      catch
      {
        Changed = true; 
      }
    }
       
    public void SetAsMainScene()
    {
      if (mainScene != null)
        throw new Exception("There should only be 1 main scene!");
      mainScene = this; 
      StartBackgroundWorker();
    }

    private void StartBackgroundWorker()
    {
      if (decorationBackgroundWorker == null)
        decorationBackgroundWorker = new BackgroundWorker();
      if (!decorationBackgroundWorker.IsBusy)
      {
        decorationBackgroundWorker.DoWork += ApplyChanges;
        decorationBackgroundWorker.RunWorkerAsync();
      }
    }

    /// <summary>
    /// Modifying the vertical scale exxageration using a backgroundworker
    /// Memory management is c-style based. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ApplyChanges(object sender, DoWorkEventArgs e)
    {
      int errorCount = 0; 
      while (Program.Running())
      {
        bool changed = false;
        try
        {
          for (int i = 0; i < RenderableObjects.Count; i++)
          {
            IRenderable renderable = RenderableObjects[i];
            if (renderable is Planet planet)
            {
              if (planet.ExxagerationChanged)
              {
                changed = true;
                planet.ApplyExxageration();
              }
              if (planet.PaintChanged)
              {
                changed = true;
                planet.Paint();
              }
            }
          }
        }
        catch (Exception ex)
        {
          changed = true; 
          errorCount++;
          if (errorCount<100)
            ErrorLog.LogException(ex, "Decoration painter error.");
        }
        if (!changed)
          System.Threading.Thread.Sleep(1); 
      }
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
  
  public interface ILight : IPositionObject
  {
    bool Changed { get; }
    bool On { get; }
    ColorFloat Color { get; }
    void Render(int number); 
  }

  public class SunLight :ILight
  {
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
      if (!On)
      {
        Gl.Disable(Light.LightNr(number));
        return;
      }

      Gl.Enable(EnableCap.Lighting);
      Gl.Enable(Light.LightNr(number));
      float[] position = new float[4];
      position[0] = (float)Position.x;
      position[1] = (float)Position.y;
      position[2] = (float)Position.z;
      position[3] = 1; //0 = directional light, 1 = point light.
      Gl.Light(Light.LightName(number), LightParameter.Position, position);
    }
  }

  public class CameraLight : ILight
  {
    private Camera camera;

    //track changes. 
    private bool wasOn;
    private ColorFloat previousColor = new ColorFloat(1,1,1,1);
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

}
