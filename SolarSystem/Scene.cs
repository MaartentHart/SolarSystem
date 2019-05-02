//Copyright Maarten 't Hart 2019
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

    public SunLight SunLight { get; set; }

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
        {
          if (renderableObject is Planet planet)
            if (SunLight!=null)
              SunLight.SetDirection(planet.RenderableObject.Transform.Position); 
           
          renderableObject.Render(camera);
        }
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
  
  

}
