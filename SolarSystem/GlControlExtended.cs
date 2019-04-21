using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  class GlControlExtended : GlControl
  {
    public Scene Scene { get; set; } = new Scene();
    public Camera Camera { get; set; } = new Camera(); 

    public GlControlExtended()
    {
      Render += UpdateRender; 
    }

    public void UpdateRender(object sender, GlControlEventArgs e)
    {
      Control senderControl = (Control)sender;
      int width = senderControl.ClientSize.Width;
      int height = senderControl.ClientSize.Height;
      Camera.Set(width, height);
      Scene.Render();
    }

  }
}
