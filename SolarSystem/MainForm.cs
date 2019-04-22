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
    private Planet TestEarth; 
    private double cameraRotationTest = 0;


    private Camera Camera => GlView.Camera;
    private Scene Scene => GlView.Scene;

    public MainForm()
    {
      InitializeComponent();
    }

    private void TestButton_Click(object sender, EventArgs e)
    { 
      Camera.Eye = new PositionObject(-10, 0, 0);
    }

    private void TestEarthButton_Click(object sender, EventArgs e)
    {
      if (TestEarth != null)
        return;

      TestEarth = new Planet();
      TestEarth.CRenderableObject.RenderGeometry.SetGeodesicGrid(6);
      Scene.RenderableObjects.Add(TestEarth.CRenderableObject);
      
    }

    private void ForceRender()
    {
      GlView.Refresh(); 
    }

    private void CamLightTestButton_Click(object sender, EventArgs e)
    {
      Camera.Light.On = !Camera.Light.On; 
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
    }

    private void TargetTestButton_Click(object sender, EventArgs e)
    {
      Camera.Target = new PositionObject(1, 0, 1);
    }

    private void CPPTestButton_Click(object sender, EventArgs e)
    {
      CRenderableObject test = new CRenderableObject();
      test.RenderGeometry.SetTest();
      Scene.RenderableObjects.Add(test); 
    }

    private void ScaleTestButton_Click(object sender, EventArgs e)
    {
      if (TestEarth == null)
        return;
      TestEarth.CRenderableObject.Scale *= 1.2; 
    }
  }
}
