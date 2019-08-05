using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem.Controls
{
  public partial class CompareForm : Form
  {

    Planet leftPlanet;
    Planet rightPlanet;

    double ViewDistance { get; set; } = 10;

    public CompareForm()
    {
      InitializeComponent();
      foreach (Planet planet in MainForm.Main.GlView.Scene.GetPlanets())
      {
        Planet1Box.Items.Add(planet.Name);
        Planet2Box.Items.Add(planet.Name);
      }
      GlLeft.Camera.IgnoreObjectPositions = true;
      GlRight.Camera.IgnoreObjectPositions = true;

      GlLeft.Scene.Lights.Add(GlLeft.Camera.Light);
      GlRight.Scene.Lights.Add(GlRight.Camera.Light);
    }

    private void Planet1Box_SelectedIndexChanged(object sender, EventArgs e)
    { 
      string name = Planet1Box.Items[Planet1Box.SelectedIndex] as string;
      foreach (Planet planet in MainForm.Main.GlView.Scene.GetPlanets())
        if (planet.Name == name)
          leftPlanet = planet;
      GlLeft.Scene.RenderableObjects.Clear();
      GlLeft.Scene.RenderableObjects.Add(leftPlanet);
      GlLeft.Camera.Lookat(new PositionObject());
      SetCamerasToDefault();
    }


    private void Planet2Box_SelectedIndexChanged(object sender, EventArgs e)
    {
      string name = Planet2Box.Items[Planet2Box.SelectedIndex] as string;
      foreach (Planet planet in MainForm.Main.GlView.Scene.GetPlanets())
        if (planet.Name == name)
          rightPlanet = planet;

      GlRight.Scene.RenderableObjects.Clear();
      GlRight.Scene.RenderableObjects.Add(rightPlanet);
      GlRight.Camera.Lookat(new PositionObject());
      SetCamerasToDefault();
    }

    private void SetCamerasToDefault()
    {
      double distance = DefaultCameraViewDistance();
      Point3D position = new Point3D(distance);

      GlLeft.Camera.ViewRadius = distance;
      GlRight.Camera.ViewRadius = distance;
      GlLeft.Camera.LockDirection = position;
      GlRight.Camera.LockDirection = position;
      ViewDistance = distance;
    }

    private void SetViewDistance(double distance)
    {
      GlLeft.Camera.LockDirection /= GlLeft.Camera.LockDirection.Magnitude;
      GlRight.Camera.LockDirection /= GlRight.Camera.LockDirection.Magnitude;

      GlLeft.Camera.LockDirection *= distance;
      GlRight.Camera.LockDirection *= distance; 
    }

    public double DefaultCameraViewDistance()
    {
      double radius = 1; 

      if (leftPlanet != null)
        radius = leftPlanet.MaximumRadius;
      if (rightPlanet != null && (leftPlanet == null || rightPlanet.MaximumRadius > leftPlanet.MaximumRadius))
        radius = rightPlanet.MaximumRadius;

      return radius * 10; 
    }


    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
      if (GlLeft.Scene.Changed || GlLeft.Camera.Changed || GlRight.Scene.Changed || GlRight.Camera.Changed)
      {
        if (GlLeft.Scrolled)
          SetViewDistance(GlLeft.Camera.ViewDirection.Magnitude);
        if (GlRight.Scrolled)
          SetViewDistance(GlRight.Camera.ViewDirection.Magnitude); 


        GlLeft.Refresh();
        GlRight.Refresh();
      }
    }
  }
}
