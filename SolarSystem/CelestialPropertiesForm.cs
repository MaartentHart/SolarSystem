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
        RotationXBox.Text = planet.RenderableObject.Rotation.axisTilt.ToString();
        RotationYBox.Text = planet.RenderableObject.Rotation.axisDirection.ToString();
        RotationZBox.Text = planet.RenderableObject.Rotation.aroundAxis.ToString();
        PositionXBox.Text = planet.RenderableObject.Position.x.ToString();
        PositionYBox.Text = planet.RenderableObject.Position.y.ToString();
        PositionZBox.Text = planet.RenderableObject.Position.z.ToString();
        TypeBox.Text = "Planet";
      }
      else
      {
        RotationXBox.Text = "0";
        RotationYBox.Text = "0";
        RotationZBox.Text = "0";
        PositionXBox.Text = "0";
        PositionYBox.Text = "0";
        PositionZBox.Text = "0";
        TypeBox.Text = "Other";
      }
      updating = false; 
    }

    private double Rad2Deg(double value)
    {
      return value / Math.PI * 180; 
    }

    private double Deg2Rad(double value)
    {
      return value / 180 * Math.PI;
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
        planet.RenderableObject.Rotation = new Rotation(
          TryDouble(RotationXBox.Text),
          TryDouble(RotationYBox.Text),
          TryDouble(RotationZBox.Text));
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

    private void xtrack_Scroll(object sender, EventArgs e)
    {
      RotationXBox.Text = xtrack.Value.ToString();
    }

    private void ytrack_Scroll(object sender, EventArgs e)
    {
      RotationYBox.Text = ytrack.Value.ToString();
    }

    private void ztrack_Scroll(object sender, EventArgs e)
    {
      RotationZBox.Text = ztrack.Value.ToString();
    }

    private int Range360(double value)
    {
      if (value >= 0 && value <= 360)
        return Convert.ToInt32(value);
      int integerValue = Convert.ToInt32(value);
      return integerValue % 360;
    }

    private void RotationXBox_TextChanged(object sender, EventArgs e)
    {
      if (!updating)
        SetRotation();
      try
      {
        xtrack.Value = Range360(Convert.ToDouble(RotationXBox.Text));
      }
      catch
      { }
    }

    private void RotationYBox_TextChanged(object sender, EventArgs e)
    {
      if (!updating)
        SetRotation();
      try
      {
        ytrack.Value = Range360(Convert.ToDouble(RotationYBox.Text));
      }
      catch
      { }
    }

    private void RotationZBox_TextChanged(object sender, EventArgs e)
    {
      if (!updating)
        SetRotation();
      try
      {
        ztrack.Value = Range360(Convert.ToDouble(RotationZBox.Text));
      }
      catch
      { }
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
  }
}
