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
    private GlControl OpenGLControl;
    private Renderer Renderer { get; } = new Renderer();
    private Scene Scene => Renderer.Scene;
    private Camera Camera => Renderer.Scene.Camera;

    private double cameraRotationTest = 0; 


    public MainForm()
    {
      InitializeComponent();
      OpenGLControl = new GlControl
      {
        Width = OpenGLPanel.Width,
        Height = OpenGLPanel.Height,
        Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top
      };
      OpenGLControl.Render += Renderer.UpdateRender; 
      OpenGLPanel.Controls.Add(OpenGLControl);
    }

    private void TestButton_Click(object sender, EventArgs e)
    { 
      Camera.Eye = new PositionObject(-10, 0, 0);
    }

    private void TestEarthButton_Click(object sender, EventArgs e)
    {
      CRenderableObject earth = new CRenderableObject();
      earth.RenderGeometry.SetGeodesicGrid(6);
      Scene.RenderableObjects.Add(earth);
      Camera.Eye = new PositionObject(10, 0, 0);
      Camera.Target = new PositionObject(0, 0, 0); 
    }

    private void ForceRender()
    {
      OpenGLPanel.Visible = false;
      OpenGLPanel.Visible = true; 
    }

    private void PaintButton_Click(object sender, EventArgs e)
    {
      ForceRender(); 
    }

    private void TetrahedronTestButton_Click(object sender, EventArgs e)
    {
      Mesh mesh = new Mesh
      {
        indices = new int[]
        { 0, 1, 2,
          1, 0, 3,
          2, 1, 3,
          0, 2, 3
        },
        vertices = new double[]
        { 0, 1, 0,
          1, 0, 0,
          -1, 0, 0,
          0, 0, 1 },
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
      Scene.Camera.Eye = new PositionObject(15 * Math.Cos(cameraRotationTest), 15 * Math.Sin(cameraRotationTest), 0); 
    }

    private void BackgroudColorButton_Click(object sender, EventArgs e)
    {
      using (ColorDialog colorDialog = new ColorDialog())
      {
        colorDialog.Tag = "Choose background color.";
        if (colorDialog.ShowDialog() != DialogResult.OK)
          return;

        Renderer.Scene.BackgroundColor = new ColorFloat(colorDialog.Color);
        ForceRender(); 
      }
    }

    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
      if (Scene.Changed)
        ForceRender();
    }

    private void TargetTestButton_Click(object sender, EventArgs e)
    {
      Camera.Target = new PositionObject(1, 0, 1);
    }
  }
}
