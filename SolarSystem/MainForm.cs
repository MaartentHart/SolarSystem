using OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  public partial class MainForm : Form
  {
    private double Exxageration
    {
      get => Scene.Exxageration;
      set => Scene.Exxageration = value; 
    }
    private Camera Camera => GlView.Camera;
    private Scene Scene => GlView.Scene;

    public Planet Earth { get; private set; }

    public MainForm()
    {
      InitializeComponent();
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += IntializeEarth;
      backgroundWorker.RunWorkerAsync(); 
    }

    private void IntializeEarth(object sender, DoWorkEventArgs e)
    {
      Earth = AddPlanet(SolarSystemPlanet.Earth);
    }

    private void TestButton_Click(object sender, EventArgs e)
    { 
      Camera.Eye = new PositionObject(-10, 0, 0);
    }

    private void Add(IRenderable renderable)
    {
      Scene.RenderableObjects.Add(renderable); 
    }

    private Planet AddPlanet(SolarSystemPlanet planetID)
    {
      foreach (IRenderable renderable in Scene.RenderableObjects)
        if (renderable is Planet existingPlanet)
          if (existingPlanet.PlanetID == planetID)
            return existingPlanet;

      Planet planet = new Planet(planetID);
      planet.RenderableObject.RenderGeometry.SetGeodesicGrid(9);
      Add(planet);
      Camera.Lookat(planet);
      return planet;
    }

    private void ForceRender()
    {
      GlView.Refresh(); 
    }

    private void TetrahedronTestButton_Click(object sender, EventArgs e)
    {
      Mesh mesh = new Mesh
      {
        vertices = new double[]
        {
          -1, 0.5, 0,
          1, 0.5, 0,
          0, -1, 0,
          0, 0, 1 },

        indices = new int[]
        {
          2, 1, 0,
          3, 0, 1,
          3, 1, 2,
          3, 2, 0
        },

        colors = new float[]
        { 0, 1, 0, 1,
          1, 0, 0, 1,
          0, 0, 1, 1,
          1, 1, 0, 1}
      };

      Scene.RenderableObjects.Add(mesh); 
    }

    private void SampleFormTestButton_Click(object sender, EventArgs e)
    {
      using (HelloTriangle.ANGLE.SampleForm form = new HelloTriangle.ANGLE.SampleForm())
        form.ShowDialog(); 
    }

    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
      if (Scene.Changed || Camera.Changed)
        ForceRender();

      if (SceneContentBox.Items.Count != Scene.RenderableObjects.Count)
      {
        SceneContentBox.Items.Clear();
        foreach (IRenderable renderable in Scene.RenderableObjects)
          SceneContentBox.Items.Add(renderable.Name, renderable.On);
      }
    }

    private void TargetTestButton_Click(object sender, EventArgs e)
    {
      Camera.Target = new PositionObject(1, 0, 1);
    }


    private void ExxagerateTestButton_Click(object sender, EventArgs e)
    {
      double Exxageration = 25;
      foreach (IRenderable renderable in Scene.RenderableObjects)
        if (renderable is Planet planet)
          planet.SetExxageration(Exxageration);
      
    }

    private void ExxagerationBar_Scroll(object sender, EventArgs e)
    {
      double exxageration = ExxagerationBar.Value;
      exxageration /= 1000;
      exxageration *= exxageration;
      Math.Round(exxageration, 2); 
      ExxagerationTextBox.Text = exxageration.ToString();

      Exxageration = exxageration;  
    }

    private void ExxagerationBar_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

    }

    private void ExxagerationTextBox_Apply(object sender, EventArgs e)
    {
      try
      {
        double exxageration = Convert.ToDouble(ExxagerationTextBox.Text);
        if (exxageration == Exxageration)
          return;
        if (exxageration < 0)
          exxageration = 0;
        else if (exxageration > 100)
          ExxagerationBar.Value = 10000;
        else
          ExxagerationBar.Value = Convert.ToInt32(exxageration * exxageration);

        Exxageration = exxageration; 
      }
      catch
      {
        ExxagerationTextBox.Text = Exxageration.ToString(); 
      }
    }

    private void ExxagerationTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        ExxagerationTextBox_Apply(sender, e); 
    }

    private void SceneContentBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      bool on = (e.NewValue == CheckState.Checked);
      if (e.Index >= Scene.RenderableObjects.Count)
        return;
      Scene.RenderableObjects[e.Index].On = on;      
    }

    private void TestColorButton_Click(object sender, EventArgs e)
    {
      if (Earth == null || Earth.HeightMap == null || Earth.HeightMap.Heights == null)
        return;
      Earth.SetColorMap(new ColorMap("Example"), Earth.HeightMap.Heights); 
    }
  }
}
