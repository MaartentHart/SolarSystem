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
  public partial class EquatorialRotationTest : Form
  {
    //the mesh that will be rotated by opengl.
    private Mesh glRotateMesh;

    public EquatorialRotationTest(Mesh glRotateMesh)
    {
      this.glRotateMesh = glRotateMesh;
      InitializeComponent();
    }

    private void XBar_Scroll(object sender, EventArgs e)
    {
      xLabel.Text = "x: " + XBar.Value.ToString();
      SetRotation(); 
    }

    private void YBar_Scroll(object sender, EventArgs e)
    {
      yLabel.Text = "y: " + YBar.Value.ToString();
      SetRotation();
    }

    private void ZBar_Scroll(object sender, EventArgs e)
    {
      zLabel.Text = "z: " + ZBar.Value.ToString();
      SetRotation();
    }

    private void SetRotation()
    {
      //opengl rotation
      glRotateMesh.Changed = true;
      throw new NotImplementedException(); 
    }
  }
}
