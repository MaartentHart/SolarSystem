//Copyright Maarten 't Hart 2019
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
  public partial class CelestialPropertiesForm : Form
  {
    private bool updating = false; 
    private IRenderable activeObject;

    public bool Editable { get; set; } = true;

    public IRenderable ActiveObject
    {
      get => activeObject;
      set
      {
        if (value == activeObject)
          return;
        activeObject = value;
        UpdateInfo(); 
      }
    }

    public CelestialPropertiesForm()
    {
      InitializeComponent();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (AutoUpdateCheckBox.Checked)
        UpdateInfo(); 
    }

    private void UpdateInfo()
    {
      updating = true;
      if (ActiveObject == null)
      {
        NameBox.Text = "";
        TypeBox.Text = "";
        updating = false; 
        return;
      }
      NameBox.Text = ActiveObject.Name;
      
      if (ActiveObject is Planet planet)
      {
        Point3D position = planet.RenderableObject.Position; 
        PositionXBox.Text = position.x.ToString();
        PositionYBox.Text = position.y.ToString();
        PositionZBox.Text = position.z.ToString();
        DistanceBox.Text = position.Magnitude.ToString(); 

        Point3D velocity = planet.GetVelocity();
        VelocityXBox.Text = velocity.x.ToString();
        VelocityYBox.Text = velocity.y.ToString();
        VelocityZBox.Text = velocity.z.ToString();
        SpeedBox.Text = velocity.Magnitude.ToString(); 

        TypeBox.Text = "Planet";

        AdditionalBox.Text = "Obliquity to orbit (deg): " + (planet.GetInclination()/Math.PI*180).ToString(); 

      }
      else
      {
        PositionXBox.Text = "0";
        PositionYBox.Text = "0";
        PositionZBox.Text = "0";
        TypeBox.Text = "Other";
        AdditionalBox.Text = ""; 
      }
      updating = false; 
    }

    private void SetRotationTest_Click(object sender, EventArgs e)
    {
      SetRotation(); 
    }

    private double TryDouble(string value)
    {
      try
      {
        return Convert.ToDouble(value);
      }
      catch
      { }
      return 0; 
    }

    private void SetRotation()
    {
      if (Editable && ActiveObject is Planet planet)
      {
        /*
        planet.RenderableObject.Rotation = new CelestialRotation(
          TryDouble(RotationXBox.Text),
          TryDouble(RotationYBox.Text),
          TryDouble(RotationZBox.Text));
          */
      }
    }

    private void SetPosition()
    {
      if (Editable)
      {
        if (ActiveObject is Planet planet)
        {
          planet.RenderableObject.Position = new Point3D (
            TryDouble(PositionXBox.Text),
            TryDouble(PositionYBox.Text),
            TryDouble(PositionZBox.Text));
        }
      }      
    }

    private void SetVelocity()
    {

    }

    private int Range360(double value)
    {
      if (value >= 0 && value <= 360)
        return Convert.ToInt32(value);
      int integerValue = Convert.ToInt32(value);
      return integerValue % 360;
    }

    private void PositionXBox_TextChanged(object sender, EventArgs e)
    {
      if (updating)
        return;
      SetPosition(); 
    }

    private void PositionYBox_TextChanged(object sender, EventArgs e)
    {
      if (updating)
        return;
      SetPosition();
    }

    private void PositionZBox_TextChanged(object sender, EventArgs e)
    {
      if (updating)
        return;
      SetPosition(); 
    }
          
    private void AutoUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void VelocityXBox_TextChanged(object sender, EventArgs e)
    {
      if (updating)
        return;
      SetVelocity(); 
    }

    private void VelocityYBox_TextChanged(object sender, EventArgs e)
    {
      if (updating)
        return;
      SetVelocity(); 
    }

    private void VelocityZBox_TextChanged(object sender, EventArgs e)
    {
      if (updating)
        return;
      SetVelocity(); 
    }

    private void CelestialPropertiesForm_Load(object sender, EventArgs e)
    {

    }
  }
}
