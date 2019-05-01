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
    //the mesh that will be rotated by opengl.
    private Mesh glRotateMesh;
    //the mesh that we will rotate ourselves by testing a quaternion. 
    private Mesh customRotateMesh;
    private double[] customRotationMeshOriginalVertices;

    public RotationTest(Mesh glRotateMesh, Mesh customRotateMesh)
    {
      this.glRotateMesh = glRotateMesh;
      this.customRotateMesh = customRotateMesh;
      customRotationMeshOriginalVertices = customRotateMesh.vertices; 
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
      Quaternion quaternion = new EulerAngles(XBar.Value, YBar.Value, ZBar.Value).Quaternion;
      glRotateMesh.Transform.Rotation = quaternion;

      //custom rotation: physically modify the object. 
      customRotateMesh.vertices = Point3D.ToVerticesArray(quaternion.Rotate(Point3D.ToPointArray(customRotationMeshOriginalVertices))); 
    }
  }
}
