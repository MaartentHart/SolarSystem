using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem.Debugging
{
  public partial class RotationTest : Form
  {
    private Mesh mesh;

    public RotationTest(Mesh mesh)
    {
      this.mesh = mesh; 
      InitializeComponent();
    }

    private void xBar_Scroll(object sender, EventArgs e)
    {
      xLabel.Text = "x: " + xBar.Value.ToString();
      SetRotation(); 
    }

    private void yBar_Scroll(object sender, EventArgs e)
    {
      yLabel.Text = "y: " + yBar.Value.ToString();
      SetRotation();
    }

    private void zBar_Scroll(object sender, EventArgs e)
    {
      zLabel.Text = "z: " + zBar.Value.ToString();
      SetRotation();
    }

    private void SetRotation()
    {
      mesh.Changed = true;
      mesh.Transform.Rotation = new EulerAngles(xBar.Value, yBar.Value, zBar.Value);
    }
  }
}
