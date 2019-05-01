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
      SolarSystem.Camera camera2 = new SolarSystem.Camera();
      SolarSystem.Scene scene2 = new SolarSystem.Scene();
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.ToggleXYZTriadButton = new System.Windows.Forms.ToolStripButton();
      this.BackgroundColorButton = new System.Windows.Forms.ToolStripButton();
      this.CameraLightButton = new System.Windows.Forms.ToolStripButton();
      this.CameraLockDistanceToggleButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.LookatDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
      this.ViewAngleTrackBar = new System.Windows.Forms.TrackBar();
      this.ViewAngleBox = new System.Windows.Forms.TextBox();
      this.GlControlExtended = new SolarSystem.GlControlExtended();
      this.FieldOfViewLabel = new System.Windows.Forms.Label();
      this.ToolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ViewAngleTrackBar)).BeginInit();
      this.SuspendLayout();
      // 
      // ToolStrip
      // 
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleXYZTriadButton,
            this.BackgroundColorButton,
            this.CameraLightButton,
            this.CameraLockDistanceToggleButton,
            this.toolStripLabel1,
            this.LookatDropDownButton});
      this.ToolStrip.Location = new System.Drawing.Point(0, 0);
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.Size = new System.Drawing.Size(682, 25);
      this.ToolStrip.TabIndex = 0;
      this.ToolStrip.Text = "toolStrip1";
      // 
      // ToggleXYZTriadButton
      // 
      this.ToggleXYZTriadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ToggleXYZTriadButton.Image = ((System.Drawing.Image)(resources.GetObject("ToggleXYZTriadButton.Image")));
      this.ToggleXYZTriadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ToggleXYZTriadButton.Name = "ToggleXYZTriadButton";
      this.ToggleXYZTriadButton.Size = new System.Drawing.Size(23, 22);
      this.ToggleXYZTriadButton.Text = "Toggle XYZ Triad";
      this.ToggleXYZTriadButton.Click += new System.EventHandler(this.ToggleXYZTriadButton_Click);
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
      // ViewAngleTrackBar
      // 
      this.ViewAngleTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ViewAngleTrackBar.Location = new System.Drawing.Point(518, 0);
      this.ViewAngleTrackBar.Maximum = 1200;
      this.ViewAngleTrackBar.Minimum = 1;
      this.ViewAngleTrackBar.Name = "ViewAngleTrackBar";
      this.ViewAngleTrackBar.Size = new System.Drawing.Size(164, 45);
      this.ViewAngleTrackBar.TabIndex = 2;
      this.ViewAngleTrackBar.Value = 250;
      this.ViewAngleTrackBar.Scroll += new System.EventHandler(this.ViewAngleTrackBar_Scroll);
      // 
      // ViewAngleBox
      // 
      this.ViewAngleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ViewAngleBox.Location = new System.Drawing.Point(475, 5);
      this.ViewAngleBox.Name = "ViewAngleBox";
      this.ViewAngleBox.Size = new System.Drawing.Size(37, 20);
      this.ViewAngleBox.TabIndex = 3;
      this.ViewAngleBox.Text = "25.0";
      this.ViewAngleBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewAngleBox_KeyDown);
      this.ViewAngleBox.Leave += new System.EventHandler(this.ViewAngleBox_Leave);
      // 
      // GlControlExtended
      // 
      this.GlControlExtended.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlControlExtended.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      camera2.Changed = false;
      camera2.FieldOfView = 25D;
      camera2.LockDistance = false;
      camera2.ViewDistance = 10D;
      camera2.ViewRadius = 10D;
      this.GlControlExtended.Camera = camera2;
      this.GlControlExtended.ColorBits = ((uint)(24u));
      this.GlControlExtended.DepthBits = ((uint)(24u));
      this.GlControlExtended.Location = new System.Drawing.Point(0, 28);
      this.GlControlExtended.MultisampleBits = ((uint)(0u));
      this.GlControlExtended.Name = "GlControlExtended";
      scene2.Changed = false;
      scene2.Exxageration = 0D;
      this.GlControlExtended.Scene = scene2;
      this.GlControlExtended.Size = new System.Drawing.Size(682, 398);
      this.GlControlExtended.StencilBits = ((uint)(0u));
      this.GlControlExtended.TabIndex = 1;
      // 
      // FieldOfViewLabel
      // 
      this.FieldOfViewLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.FieldOfViewLabel.AutoSize = true;
      this.FieldOfViewLabel.Location = new System.Drawing.Point(400, 8);
      this.FieldOfViewLabel.Name = "FieldOfViewLabel";
      this.FieldOfViewLabel.Size = new System.Drawing.Size(69, 13);
      this.FieldOfViewLabel.TabIndex = 4;
      this.FieldOfViewLabel.Text = "Field of view:";
      // 
      // GlView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.FieldOfViewLabel);
      this.Controls.Add(this.ViewAngleBox);
      this.Controls.Add(this.GlControlExtended);
      this.Controls.Add(this.ViewAngleTrackBar);
      this.Controls.Add(this.ToolStrip);
      this.Name = "GlView";
      this.Size = new System.Drawing.Size(682, 426);
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ViewAngleTrackBar)).EndInit();
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
    private System.Windows.Forms.ToolStripButton ToggleXYZTriadButton;
    private System.Windows.Forms.TrackBar ViewAngleTrackBar;
    private System.Windows.Forms.TextBox ViewAngleBox;
    private System.Windows.Forms.Label FieldOfViewLabel;
  }
}
