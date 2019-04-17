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
    GlControl OpenGLControl; 

    public MainForm()
    {
      InitializeComponent();
      OpenGLControl = new OpenGL.GlControl();
      OpenGLControl.Width = OpenGLPanel.Width;
      OpenGLControl.Height = OpenGLPanel.Height;
      OpenGLControl.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
      OpenGLPanel.Controls.Add(OpenGLControl);
    }

    private void TestButton_Click(object sender, EventArgs e)
    {
      MessageBox.Show(CoreDll.ExampleGetInt().ToString());
    }

    private void testGLButton_Click(object sender, EventArgs e)
    {
      OpenGLControl.Render += RenderControl_Render;
      OpenGLControl.Visible = false;
      OpenGLControl.Visible = true;

    }

    private void RenderControl_Render(object sender, GlControlEventArgs e)
    {
      Control senderControl = (Control)sender;

      Gl.Viewport(0, 0, senderControl.ClientSize.Width, senderControl.ClientSize.Height);
      Gl.Clear(ClearBufferMask.ColorBufferBit);

      Gl.Begin(PrimitiveType.Triangles);
      Gl.Color3(1.0f, 0.0f, 0.0f); Gl.Vertex2(0.0f, 0.0f);
      Gl.Color3(0.0f, 1.0f, 0.0f); Gl.Vertex2(0.5f, 1.0f);
      Gl.Color3(0.0f, 0.0f, 1.0f); Gl.Vertex2(1.0f, 0.0f);
      Gl.End();
    }
  }
}
