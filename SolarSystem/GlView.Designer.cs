namespace SolarSystem
{
  partial class GlView
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlView));
      SolarSystem.Camera camera1 = new SolarSystem.Camera();
      SolarSystem.Scene scene1 = new SolarSystem.Scene();
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.BackgroundColorButton = new System.Windows.Forms.ToolStripButton();
      this.CameraLightButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.LookatDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
      this.GlControlExtended = new SolarSystem.GlControlExtended();
      this.CameraLockDistanceToggleButton = new System.Windows.Forms.ToolStripButton();
      this.ToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // ToolStrip
      // 
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackgroundColorButton,
            this.CameraLightButton,
            this.toolStripLabel1,
            this.LookatDropDownButton,
            this.CameraLockDistanceToggleButton});
      this.ToolStrip.Location = new System.Drawing.Point(0, 0);
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.Size = new System.Drawing.Size(682, 25);
      this.ToolStrip.TabIndex = 0;
      this.ToolStrip.Text = "toolStrip1";
      // 
      // BackgroundColorButton
      // 
      this.BackgroundColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BackgroundColorButton.Image = ((System.Drawing.Image)(resources.GetObject("BackgroundColorButton.Image")));
      this.BackgroundColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BackgroundColorButton.Name = "BackgroundColorButton";
      this.BackgroundColorButton.Size = new System.Drawing.Size(23, 22);
      this.BackgroundColorButton.Text = "Background Color";
      this.BackgroundColorButton.Click += new System.EventHandler(this.BackgroudColorButton_Click);
      // 
      // CameraLightButton
      // 
      this.CameraLightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CameraLightButton.Image = ((System.Drawing.Image)(resources.GetObject("CameraLightButton.Image")));
      this.CameraLightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CameraLightButton.Name = "CameraLightButton";
      this.CameraLightButton.Size = new System.Drawing.Size(23, 22);
      this.CameraLightButton.Text = "Camera Light";
      this.CameraLightButton.Click += new System.EventHandler(this.CameraLightButton_Click);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
      this.toolStripLabel1.Text = "Look at:";
      // 
      // LookatDropDownButton
      // 
      this.LookatDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.LookatDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("LookatDropDownButton.Image")));
      this.LookatDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.LookatDropDownButton.Name = "LookatDropDownButton";
      this.LookatDropDownButton.Size = new System.Drawing.Size(49, 22);
      this.LookatDropDownButton.Text = "None";
      this.LookatDropDownButton.DropDownOpening += new System.EventHandler(this.LookatDropDownButton_Click);
      // 
      // GlControlExtended
      // 
      this.GlControlExtended.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlControlExtended.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      camera1.FieldOfView = 25D;
      this.GlControlExtended.Camera = camera1;
      this.GlControlExtended.ColorBits = ((uint)(24u));
      this.GlControlExtended.DepthBits = ((uint)(24u));
      this.GlControlExtended.Location = new System.Drawing.Point(0, 28);
      this.GlControlExtended.MultisampleBits = ((uint)(0u));
      this.GlControlExtended.Name = "GlControlExtended";
      scene1.Changed = false;
      scene1.Exxageration = 0D;
      this.GlControlExtended.Scene = scene1;
      this.GlControlExtended.Size = new System.Drawing.Size(682, 398);
      this.GlControlExtended.StencilBits = ((uint)(0u));
      this.GlControlExtended.TabIndex = 1;
      // 
      // CameraLockDistanceToggleButton
      // 
      this.CameraLockDistanceToggleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CameraLockDistanceToggleButton.Image = ((System.Drawing.Image)(resources.GetObject("CameraLockDistanceToggleButton.Image")));
      this.CameraLockDistanceToggleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CameraLockDistanceToggleButton.Name = "CameraLockDistanceToggleButton";
      this.CameraLockDistanceToggleButton.Size = new System.Drawing.Size(23, 22);
      this.CameraLockDistanceToggleButton.Text = "Lock Camera View Distance";
      this.CameraLockDistanceToggleButton.Click += new System.EventHandler(this.CameraLockDistanceToggleButton_Click);
      // 
      // GlView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.GlControlExtended);
      this.Controls.Add(this.ToolStrip);
      this.Name = "GlView";
      this.Size = new System.Drawing.Size(682, 426);
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip ToolStrip;
    private GlControlExtended GlControlExtended;
    private System.Windows.Forms.ToolStripButton BackgroundColorButton;
    private System.Windows.Forms.ToolStripButton CameraLightButton;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripDropDownButton LookatDropDownButton;
    private System.Windows.Forms.ToolStripButton CameraLockDistanceToggleButton;
  }
}
