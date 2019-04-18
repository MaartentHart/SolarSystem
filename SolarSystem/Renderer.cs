using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenGL;
namespace SolarSystem
{
  public class Renderer
  {
    public Scene Scene { get; set; } = new Scene(); 

    public void UpdateRender(object sender, GlControlEventArgs e)
    {
      Control senderControl = (Control)sender;
      int width = senderControl.ClientSize.Width;
      int height = senderControl.ClientSize.Height;
      Scene.Render(width, height); 
    }
  }



}
