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
    private double cameraRotationTest = 0;

    private GlControlExtended GlControlExtended { get; set; }
    private Camera Camera => GlControlExtended.Camera;
    private Scene Scene => GlControlExtended.Scene;

    public MainForm()
    {
      InitializeComponent();
      GlControlExtended = new GlControlExtended
      {
        Width = OpenGLPanel.Width,
        Height = OpenGLPanel.Height,
        Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top
      };

      OpenGLPanel.Controls.Add(GlControlExtended);
    }

    private void TestButton_Click(object sender, EventArgs e)
    { 
      Camera.Eye = new PositionObject(-10, 0, 0);
    }

    private void TestEarthButton_Click(object sender, EventArgs e)
    {
      CRenderableObject earth = new CRenderableObject();
      double scale = 2;

      earth.Scale = new Point3D(scale, scale, scale);
      earth.RenderGeometry.SetGeodesicGrid(6);
      Scene.RenderableObjects.Add(earth);
      Camera.Eye = new PositionObject(5*scale, 0, 0);
      Camera.Target = new PositionObject(0, 0, 0); 
    }

    private void ForceRender()
    {
      Refresh(); 
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

    private void CameraTestButton_Click(object sender, EventArgs e)
    {
      cameraRotationTest += 0.01; 
      Camera.Eye = new PositionObject(15 * Math.Cos(cameraRotationTest), 15 * Math.Sin(cameraRotationTest), 0); 
    }

    private void BackgroudColorButton_Click(object sender, EventArgs e)
    {
      using (ColorDialog colorDialog = new ColorDialog())
      {
        colorDialog.Tag = "Choose background color.";
        if (colorDialog.ShowDialog() != DialogResult.OK)
          return;

        GlControlExtended.Camera.BackgroundColor = new ColorFloat(colorDialog.Color);
        ForceRender(); 
      }
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
  }
}
