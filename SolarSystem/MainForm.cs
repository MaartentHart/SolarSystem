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
      Renderer.Scene.BackgroundColor.G = 1; 
    }

    private void TestEarthButton_Click(object sender, EventArgs e)
    {
      RenderableObject earth = new RenderableObject();
      earth.RenderGeometry.SetGeodesicGrid(6);
      Scene.RenderableObjects.Add(earth);
      Camera.Position = new Point3D(10, 0, 0);
      Camera.Target = new Point3D(0, 0, 0); 
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
  }
}
