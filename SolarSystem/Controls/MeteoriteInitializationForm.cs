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
  public partial class MeteoriteInitializationForm : Form
  {
    public Point3D position = new Point3D();
    public Point3D velocity = new Point3D();
    public int generation = 5;
    public double minimumSpeed = 1;
    public double speedStep = 1;
    public int steps = 10;
    public double initialRadius = 1.0;
    public int arrayLength = 100;
    public double spacing = 200;
    public Point3D sheetNormal = new Point3D(1, 0, 0);

    public Point3D ObjectPosition { get; set; } = new Point3D();
    private Scene Scene { get; }
    private Mesh Triad { get; set; }
    private Mesh Arrow { get; set; }

    private MeteorShowerSheetTentative TentativeSheet {get; set;}

    public Color Color { get
      {
        try
        {
          if (SetColorButton.BackColor != null)
            return SetColorButton.BackColor; 
        }
        catch
        {

        }
        return Color.White; 
      }
    }

    public MeteoriteInitializationForm(Scene scene)
    {
      Scene = scene;

      InitializeComponent();

      DistanceToBox.Items.Clear();
      VelocityRelativeToBox.Items.Clear();
      foreach (IRenderable renderable in scene.RenderableObjects)
        if (renderable is Planet planet)
        {
          DistanceToBox.Items.Add(renderable.Name);
          VelocityRelativeToBox.Items.Add(renderable.Name); 
        }

      if (DistanceToBox.Items.Count > 0)
      {
        DistanceToBox.Text = DistanceToBox.Items[0].ToString();
        VelocityRelativeToBox.Text = VelocityRelativeToBox.Items[0].ToString();
      }

      DistanceTrackBar.ValueChanged += ChangePosition;
      PositionRightAscensionTrackBar.ValueChanged += ChangePosition;
      PositionDeclinationTrackBar.ValueChanged += ChangePosition;

      SpeedTrackBar.ValueChanged += ChangeVelocity;
      VelocityRightAscensionTrackBar.ValueChanged += ChangeVelocity;
      VelocityDeclinationTrackBar.ValueChanged += ChangeVelocity;

      ChangePosition(null,null);
      ChangeVelocity(null, null); 

      ShowTriad();
      ShowTentativeSheet(); 
    }

    private void ShowTriad()
    {
      Triad = new Mesh();
      Triad.Name = "Meteorite Shower Position";
      TriadGeometry triad = new TriadGeometry();
      triad.Arrows.Transform.Rotation = EquatorialCoordinateSystem.Main.SystemRotation; 
      Triad.Children.Add(triad.Arrows);
      Arrow = TriadGeometry.GenerateArrow();
      Triad.Children.Add(Arrow);
      Scene.RenderableObjects.Add(Triad);
    }

    private void RemoveTriad()
    {
      Scene.RenderableObjects.Remove(Triad); 
    }

    private void ShowTentativeSheet()
    {
      TentativeSheet = new MeteorShowerSheetTentative(new Point3D(), new Point3D(), 0, 0);
      TentativeSheet.On = false;
      Scene.RenderableObjects.Add(TentativeSheet); 
    }

    private void RemoveTentativeSheet()
    {
      Scene.RenderableObjects.Remove(TentativeSheet); 
    }

    private void RepositionTriad()
    {
      if (Triad == null)
        return;

      Triad.Transform.Position = position;

      Point3D arrowDirection = velocity.Normal;

      double pitch = -Math.Asin(arrowDirection.z);
      double yaw = Math.Atan2(arrowDirection.y, arrowDirection.x);
      double roll = 0; 

      Arrow.Transform.Rotation = new Quaternion(yaw,pitch,roll);

      double scale = velocity.Magnitude * 500;
      Point3D scale3D = new Point3D(scale, scale, scale);

      foreach (Mesh c in Triad.Children)
        foreach (Mesh child in c.Children)
          child.Transform.Scale = scale3D;
      Arrow.Transform.Scale = scale3D; 

      Scene.Changed = true;
      try
      {
        ModifyTentativeSheet();
      }
      catch
      {

      }
    }

    /// <summary>
    /// Read the velocity from the trackbars and set the x, y and z boxes accordingly. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ChangeVelocity(object sender, EventArgs e)
    {
      double rightAscension = VelocityRightAscensionTrackBar.Value;
      double declination = VelocityDeclinationTrackBar.Value;

      Point3D direction = EquatorialCoordinateSystem.Main.EquatorialCoordinate(rightAscension, declination);
      velocity = direction * SpeedTrackBar.Value;

      VelocityXBox.Text = velocity.x.ToString();
      VelocityYBox.Text = velocity.y.ToString();
      VelocityZBox.Text = velocity.z.ToString();

      RepositionTriad(); 
    }

    /// <summary>
    /// Read the position from the trackbars and set the x, y and z boxes accordingly. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ChangePosition(object sender, EventArgs e)
    {
      double rightAscension = PositionRightAscensionTrackBar.Value;
      double declination = PositionDeclinationTrackBar.Value;

      Point3D direction = EquatorialCoordinateSystem.Main.EquatorialCoordinate(rightAscension, declination);
      position = direction * DistanceTrackBar.Value;

      position += ObjectPosition; 

      PositionXBox.Text = position.x.ToString();
      PositionYBox.Text = position.y.ToString();
      PositionZBox.Text = position.z.ToString();

      RepositionTriad(); 
    }

    /// <summary>
    /// Read the position from the x, y and z value, and set the trackbars accordingly.
    /// </summary>
    private void ReadPosition()
    {
      position = new Point3D(
        Convert.ToDouble(PositionXBox.Text),
        Convert.ToDouble(PositionYBox.Text),
        Convert.ToDouble(PositionZBox.Text));

      position -= ObjectPosition;
      double distance = position.Magnitude;
      double rightAscension = EquatorialCoordinateSystem.Main.DirectionRightAscension(position);  
      double declination = EquatorialCoordinateSystem.Main.DirectionDeclination(position);

      DistanceTrackBar.Value = distance;
      PositionRightAscensionTrackBar.Value = rightAscension;
      PositionDeclinationTrackBar.Value = declination;

      RepositionTriad(); 
    }

    /// <summary>
    /// Read the velocity from the x, y and z value, and set the trackbars accordingly. 
    /// </summary>
    private void ReadVelocity()
    {
      velocity = new Point3D(
        Convert.ToDouble(VelocityXBox.Text),
        Convert.ToDouble(VelocityYBox.Text),
        Convert.ToDouble(VelocityZBox.Text));

      double speed = velocity.Magnitude;
      double rightAscension = EquatorialCoordinateSystem.Main.DirectionRightAscension(velocity);
      double declination = EquatorialCoordinateSystem.Main.DirectionDeclination(velocity);

      SpeedTrackBar.Value = speed;
      VelocityRightAscensionTrackBar.Value = rightAscension;
      VelocityDeclinationTrackBar.Value = declination;

      RepositionTriad(); 
    }

    private Point3D GetVelocity()
    {
      Point3D velocity = new Point3D(Convert.ToDouble(VelocityXBox.Text),
          Convert.ToDouble(VelocityYBox.Text),
          Convert.ToDouble(VelocityZBox.Text));

      if (VelocityRelativeToBox.Text.ToLower() == "sun")
        return velocity; 

      if (VelocityRelativeToBox.SelectedIndex>=0 && VelocityRelativeToBox.SelectedIndex<VelocityRelativeToBox.Items.Count)
      {
        string relativeObjectName = VelocityRelativeToBox.Items[VelocityRelativeToBox.SelectedIndex] as string;

        foreach (IRenderable renderable in Scene.RenderableObjects)
        {
          if (renderable is Planet planet)
          {
            if (planet.Name != relativeObjectName)
              continue;

            velocity += planet.GetVelocity(); 
          }
        }
      }
      return velocity; 
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      try
      {
        position = new Point3D(Convert.ToDouble(PositionXBox.Text),
          Convert.ToDouble(PositionYBox.Text),
          Convert.ToDouble(PositionZBox.Text));

        velocity = GetVelocity();

        if (ExplosionTypeTabControl.SelectedTab == SphericalTab)
        {
          generation = Convert.ToInt32(DetailLevelTrackBar.Value);
          minimumSpeed = Convert.ToDouble(MinimumSpeedBox.Text);
          speedStep = Convert.ToDouble(SpeedStepBox.Text);
          steps = Convert.ToInt32(StepsBox.Text);
          initialRadius = Convert.ToDouble(InitialRadiusBox.Text);

          AddMeteorShower();
        }
        else if (ExplosionTypeTabControl.SelectedTab == SheetTab)
        {
          arrayLength = Convert.ToInt32(ArrayLengthBox.Text);
          spacing = Convert.ToDouble(SpacingBox.Text);
          double declination = SheetDeclinationTrackbar.Value;
          double rightAscension = SheetRightAscensionTrackBar.Value;

          sheetNormal = EquatorialCoordinateSystem.Main.EquatorialCoordinate(rightAscension, declination);

          AddMeteorShower(false); 
        }

        Close(); 
      }
      catch
      {
        MessageBox.Show("Invalid input.");
      }
    }

    private void AddMeteorShower(bool spherical = true)
    {
      MeteorShower meteorShower;
      ColorFloat color = new ColorFloat(Color); 

      if (spherical)
        meteorShower = new MeteorShower(position, velocity, generation, minimumSpeed, speedStep, steps, initialRadius, color);
      else
        meteorShower = new MeteorShower(position, velocity, sheetNormal, arrayLength, spacing, color);

      //give meteor shower a unique name. 
      int i = 0;
      bool ok = false;
      while (!ok)
      {
        ok = true;
        foreach (IRenderable renderable in Scene.RenderableObjects)
        {
          if (renderable.Name == meteorShower.Name)
          {
            i++;
            string name = "Meteor Shower ";
            if (!spherical)
              name += "(sheet) "; 
            meteorShower.Name = name + i.ToString();
            ok = false;
            break;
          }
        }
      }

      Scene.RenderableObjects.Add(meteorShower);
    }

    private void DistanceToBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      string selected = DistanceToBox.Text; 
      foreach (IRenderable renderable in Scene.RenderableObjects)
        if (renderable is Planet planet)
          if (planet.Name == selected)
            ObjectPosition = planet.Position;

      ChangePosition(sender, e); 
    }
 
    private void PositionBox_Leave(object sender, EventArgs e)
    {
      ReadPosition();
    }

    private void PositionBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        ReadPosition(); 
    }

    private void VelocityBox_Leave(object sender, EventArgs e)
    {
      ReadVelocity(); 
    }

    private void VelocityBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        ReadVelocity(); 
    }

    private void MeteoriteInitializationForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      RemoveTriad();
      RemoveTentativeSheet(); 
    }

    private void ArrayLengthBox_Leave(object sender, EventArgs e)
    {
      try
      {
        int length = Convert.ToInt32(ArrayLengthBox.Text);
      }
      catch
      {
        ArrayLengthBox.Text = "100"; 
      }
    }

    private void SpacingBox_Leave(object sender, EventArgs e)
    {
      try
      {
        double spacing = Convert.ToDouble(SpacingBox.Text);
      }
      catch
      {
        SpacingBox.Text = "200"; 
      }

    }

    private void ModifyTentativeSheet()
    {
      arrayLength = Convert.ToInt32(ArrayLengthBox.Text);
      spacing = Convert.ToDouble(SpacingBox.Text);
      double declination = SheetDeclinationTrackbar.Value;
      double rightAscension = SheetRightAscensionTrackBar.Value;

      sheetNormal = EquatorialCoordinateSystem.Main.EquatorialCoordinate(rightAscension, declination);

      TentativeSheet.SetValues(position, sheetNormal, arrayLength, spacing);

    }

    private void ExplosionTypeTabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (ExplosionTypeTabControl.SelectedTab == SheetTab)
      {
        try
        {
          ModifyTentativeSheet();           
          TentativeSheet.On = true;
        }
        catch
        {

        }
      }
      else
      {
        TentativeSheet.On = false; 
      }
    }

    private void SheetChanged(object sender, EventArgs e)
    {
      ModifyTentativeSheet(); 
    }

    private void SetColorButton_Click(object sender, EventArgs e)
    {
      using (ColorDialog colorDialog = new ColorDialog())
      {
        if (colorDialog.ShowDialog() != DialogResult.OK)
          return;
        SetColorButton.BackColor = colorDialog.Color; 
      }
    }
  }
}
