namespace SolarSystem.Controls
{
  partial class RecordScreen
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      SolarSystem.Camera camera1 = new SolarSystem.Camera();
      SolarSystem.Scene scene1 = new SolarSystem.Scene();
      this.GlControl = new SolarSystem.GlControlExtended();
      this.SuspendLayout();
      // 
      // GlControl
      // 
      this.GlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      camera1.Changed = false;
      camera1.FieldOfView = 25D;
      camera1.LockDistance = true;
      camera1.ViewDistance = 10D;
      camera1.ViewRadius = 10D;
      this.GlControl.Camera = camera1;
      this.GlControl.ColorBits = ((uint)(24u));
      this.GlControl.DepthBits = ((uint)(24u));
      this.GlControl.Location = new System.Drawing.Point(0, 0);
      this.GlControl.MultisampleBits = ((uint)(0u));
      this.GlControl.Name = "GlControl";
      scene1.Changed = false;
      scene1.Exxageration = 0D;
      scene1.MaximumDisplayGeneration = 9;
      scene1.PointSize = 3F;
      scene1.SunLight = null;
      this.GlControl.Scene = scene1;
      this.GlControl.Size = new System.Drawing.Size(800, 450);
      this.GlControl.StencilBits = ((uint)(0u));
      this.GlControl.TabIndex = 0;
      // 
      // RecordScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.ControlBox = false;
      this.Controls.Add(this.GlControl);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "RecordScreen";
      this.ShowIcon = false;
      this.Text = "RecordScreen";
      this.ResumeLayout(false);

    }

    #endregion

    internal GlControlExtended GlControl;
  }
}