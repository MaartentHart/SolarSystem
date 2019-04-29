using OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  class GlControlExtended : GlControl
  {
    private Point mouseLeftDownLocation;
    
    public Camera Camera { get; set; } = new Camera();
    public Scene Scene { get; set; } = new Scene();

    public GlControlExtended()
    {
      InitializeComponent();
      ContextCreated += ContextCreatedEvent;
      MouseDown += MouseDownEvent;
      MouseMove += MouseMoveEvent;
      MouseWheel += MouseWheelEvent;
      Render += UpdateRender;
    }

    private void MouseWheelEvent(object sender, MouseEventArgs e)
    {
      double zoomFactor = Math.Pow(0.8, e.Delta/120);
      Camera.Zoom(zoomFactor);
    }

    private void ContextCreatedEvent(object sender, GlControlEventArgs e)
    {
      Gl.ClearColor(0.0f, 0.0f, 0.0f, 0.5f); // Black Background
      Gl.ClearDepth(1.0f);
      Gl.Enable(EnableCap.DepthTest); // Enables Depth Testing
      Gl.DepthFunc(DepthFunction.Lequal); // The Type Of Depth Testing To Do
      Gl.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
    }

    private void MouseDownEvent(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        mouseLeftDownLocation = e.Location;
      }
    }

    private void MouseMoveEvent(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        int x = e.X - mouseLeftDownLocation.X;
        int y = e.Y - mouseLeftDownLocation.Y;
        Camera.Rotate(x, y, true, Math.PI*2/Width);
        mouseLeftDownLocation = e.Location; 
      }
    }

    public void UpdateRender(object sender, GlControlEventArgs e)
    {
      Control senderControl = (Control)sender;
      int width = senderControl.ClientSize.Width;
      int height = senderControl.ClientSize.Height;
      Camera.Render(width, height);

      try
      {
        Scene.Render(Camera);
      }
      catch
      {
        Scene.Changed = true; 
      }
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // GlControlExtended
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.DepthBits = ((uint)(24u));
      this.Name = "GlControlExtended";
      this.Size = new System.Drawing.Size(618, 294);
      this.ResumeLayout(false);

    }
  }
}
