//Copyright Maarten 't Hart 2019
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

    private void LookatDropDownButton_Click(object sender, EventArgs e)
    {
      LookatDropDownButton.DropDownItems.Clear(); 
      foreach (IRenderable renderable in Scene.RenderableObjects)
      {
        if (renderable is IPositionObject positionObject)
        {
          ToolStripItem toolStripItem = LookatDropDownButton.DropDownItems.Add(renderable.Name);
          toolStripItem.Click += LookatTargetButton_Click;
        }
      }
    }

    private void LookatTargetButton_Click(object sender, EventArgs e)
    {
      try
      {
        foreach (IRenderable renderable in Scene.RenderableObjects)
          if (renderable is IPositionObject positionObject && sender is ToolStripItem toolStripItem)
            if (toolStripItem.Text == renderable.Name)
              Lookat(positionObject, renderable.Name);
      }
      catch 
      {

      }
    }

    internal void Lookat(IPositionObject target, string name)
    {
      Camera.Lookat(target);
      LookatDropDownButton.Text = name;
    }

    private void CameraLockDistanceToggleButton_Click(object sender, EventArgs e)
    {
      Camera.LockDistance = !Camera.LockDistance;
    }

    private void ToggleXYZTriadButton_Click(object sender, EventArgs e)
    {
      Camera.Triad.On = !Camera.Triad.On;
      Camera.Changed = true; 
    }

    private void ViewAngleTrackBar_Scroll(object sender, EventArgs e)
    {
      double viewAngle = ViewAngleTrackBar.Value * 0.1;
      ViewAngleBox.Text = viewAngle.ToString();
      ApplyViewAngle(viewAngle);
    }

    private void ApplyViewAngle(double ViewAngle)
    {
      Camera.FieldOfView = ViewAngle;
      Camera.Changed = true; 
    }

    private void ViewAngleTextBoxApply()
    {
      try
      {
        double viewAngle = Convert.ToDouble(ViewAngleBox.Text);
        int trackBarValue = Convert.ToInt32(viewAngle * 10);
        if (trackBarValue < ViewAngleTrackBar.Minimum || trackBarValue > ViewAngleTrackBar.Maximum)
          throw new ArgumentOutOfRangeException();
        ViewAngleTrackBar.Value = trackBarValue;
        ApplyViewAngle(viewAngle); 
      }
      catch
      {
        ViewAngleBox.Text = Camera.FieldOfView.ToString();
      }
    }

    private void ViewAngleBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        ViewAngleTextBoxApply(); 
    }

    private void ViewAngleBox_Leave(object sender, EventArgs e)
    {
      ViewAngleTextBoxApply(); 
    }

    private void ToggleSunLightButton_Click(object sender, EventArgs e)
    {
      if (Scene.SunLight != null)
        Scene.SunLight.On = !Scene.SunLight.On; 
    }

    private void PointSizeBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        SetPointSize(); 
    }

    private void PointSizeBox_Leave(object sender, EventArgs e)
    {
      SetPointSize(); 
    }

    private void SetPointSize()
    {
      try
      {
        float pointSize = Convert.ToSingle(PointSizeBox.Text);
        if (pointSize<0)
        {
          PointSizeBox.Text = Scene.PointSize.ToString();
          return;
        }
        Scene.PointSize = pointSize; 
      }
      catch
      {
        PointSizeBox.Text = Scene.PointSize.ToString();
      }
    }

    private void DisplayButton_DropDownOpening(object sender, EventArgs e)
    {
      DisplayButton.DropDownItems.Clear();

      HashSet<string> layerNames = new HashSet<string>();
      foreach (IRenderable renderable in Scene.RenderableObjects)
        if (renderable is Planet planet)
          foreach (Layer layer in planet.Layers)
            layerNames.Add(layer.Name); 

      foreach (string layerName in layerNames)
      {
        ToolStripItem toolStripItem = DisplayButton.DropDownItems.Add(layerName);
        toolStripItem.Click += DisplayLayerButton_Click;
      }
    }

    private void DisplayLayerButton_Click(object sender, EventArgs e)
    {
      string layerName = (sender as ToolStripItem).Text;
      DisplayButton.Text = layerName;

      foreach (IRenderable renderable in Scene.RenderableObjects)
        if (renderable is Planet planet)
          planet.ActivateLayer(layerName); 
    }
  }
}
