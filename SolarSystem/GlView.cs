using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  public partial class GlView : UserControl
  {
    public Camera Camera => GlControlExtended.Camera;
    public Scene Scene => GlControlExtended.Scene;
    public GlView()
    {
      InitializeComponent();
    }


    private void BackgroudColorButton_Click(object sender, EventArgs e)
    {
      using (ColorDialog colorDialog = new ColorDialog())
      {
        colorDialog.Tag = "Choose background color.";
        if (colorDialog.ShowDialog() != DialogResult.OK)
          return;

        Camera.BackgroundColor = new ColorFloat(colorDialog.Color);
        Refresh(); 
      }
    }

    private void CameraLightButton_Click(object sender, EventArgs e)
    {
      Camera.Light.On = !Camera.Light.On;
    }
  }
}
