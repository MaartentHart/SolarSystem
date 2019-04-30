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
  }
}
