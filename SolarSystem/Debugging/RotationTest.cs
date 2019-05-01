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

    private void XLocalBar_Scroll(object sender, EventArgs e)
    {
      xLocalLabel.Text = "x: " + XBar.Value.ToString();
      SetRotation();
    }

    private void YLocalBar_Scroll(object sender, EventArgs e)
    {
      yLocalLabel.Text = "y: " + YBar.Value.ToString();
      SetRotation();
    }

    private void ZLocalBar_Scroll(object sender, EventArgs e)
    {
      zLocalLabel.Text = "z: " + ZBar.Value.ToString();
      SetRotation();
    }

    private void SetRotation()
    {
      Quaternion systemRotation = new EulerAngles(XBar.Value, YBar.Value, ZBar.Value).Quaternion;
      Quaternion localRotation = new EulerAngles(XLocalBar.Value, YLocalBar.Value, ZLocalBar.Value).Quaternion;

      //opengl rotation
      glRotateMesh.Changed = true;
      glRotateMesh.Transform.Rotation = systemRotation;

      foreach (IRenderable child in glRotateMesh.Children)
      {
        if (child is Mesh childMesh)
          childMesh.Transform.Rotation = localRotation; 
      }

      //custom rotation: physically modify the object. 
      //Quaternion testRotation = systemRotation;
      DoubleRotation doubleRotation = new DoubleRotation(systemRotation, localRotation);

      Quaternion testRotation = doubleRotation.ToQuaternion(); 

      customRotateMesh.vertices = Point3D.ToVerticesArray(testRotation.Rotate(Point3D.ToPointArray(customRotationMeshOriginalVertices)));
      double[] testVertices = Point3D.ToVerticesArray(testRotation.RotateReverse(Point3D.ToPointArray(customRotateMesh.vertices)));
      
    }


  }
}
