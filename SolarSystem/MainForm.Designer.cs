namespace SolarSystem
{
  partial class MainForm
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.OpenGLPanel = new System.Windows.Forms.Panel();
      this.TestEarthButton = new System.Windows.Forms.Button();
      this.PaintButton = new System.Windows.Forms.Button();
      this.TriangleTestButton = new System.Windows.Forms.Button();
      this.CameraTestButton = new System.Windows.Forms.Button();
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.BackgroudColorButton = new System.Windows.Forms.ToolStripButton();
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.TargetTestButton = new System.Windows.Forms.Button();
      this.ToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // OpenGLPanel
      // 
      this.OpenGLPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.OpenGLPanel.Location = new System.Drawing.Point(12, 57);
      this.OpenGLPanel.Name = "OpenGLPanel";
      this.OpenGLPanel.Size = new System.Drawing.Size(479, 320);
      this.OpenGLPanel.TabIndex = 2;
      // 
      // TestEarthButton
      // 
      this.TestEarthButton.Location = new System.Drawing.Point(12, 28);
      this.TestEarthButton.Name = "TestEarthButton";
      this.TestEarthButton.Size = new System.Drawing.Size(75, 23);
      this.TestEarthButton.TabIndex = 3;
      this.TestEarthButton.Text = "Earth";
      this.TestEarthButton.UseVisualStyleBackColor = true;
      this.TestEarthButton.Click += new System.EventHandler(this.TestEarthButton_Click);
      // 
      // PaintButton
      // 
      this.PaintButton.Location = new System.Drawing.Point(93, 28);
      this.PaintButton.Name = "PaintButton";
      this.PaintButton.Size = new System.Drawing.Size(75, 23);
      this.PaintButton.TabIndex = 4;
      this.PaintButton.Text = "Paint";
      this.PaintButton.UseVisualStyleBackColor = true;
      this.PaintButton.Click += new System.EventHandler(this.PaintButton_Click);
      // 
      // TriangleTestButton
      // 
      this.TriangleTestButton.Location = new System.Drawing.Point(174, 28);
      this.TriangleTestButton.Name = "TriangleTestButton";
      this.TriangleTestButton.Size = new System.Drawing.Size(75, 23);
      this.TriangleTestButton.TabIndex = 5;
      this.TriangleTestButton.Text = "Tetrahedron";
      this.TriangleTestButton.UseVisualStyleBackColor = true;
      this.TriangleTestButton.Click += new System.EventHandler(this.TetrahedronTestButton_Click);
      // 
      // CameraTestButton
      // 
      this.CameraTestButton.Location = new System.Drawing.Point(255, 28);
      this.CameraTestButton.Name = "CameraTestButton";
      this.CameraTestButton.Size = new System.Drawing.Size(75, 23);
      this.CameraTestButton.TabIndex = 6;
      this.CameraTestButton.Text = "Camera";
      this.CameraTestButton.UseVisualStyleBackColor = true;
      this.CameraTestButton.Click += new System.EventHandler(this.CameraTestButton_Click);
      // 
      // ToolStrip
      // 
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackgroudColorButton});
      this.ToolStrip.Location = new System.Drawing.Point(0, 0);
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.Size = new System.Drawing.Size(503, 25);
      this.ToolStrip.TabIndex = 7;
      this.ToolStrip.Text = "toolStrip1";
      // 
      // BackgroudColorButton
      // 
      this.BackgroudColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BackgroudColorButton.Image = ((System.Drawing.Image)(resources.GetObject("BackgroudColorButton.Image")));
      this.BackgroudColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BackgroudColorButton.Name = "BackgroudColorButton";
      this.BackgroudColorButton.Size = new System.Drawing.Size(23, 22);
      this.BackgroudColorButton.Text = "Background Color";
      this.BackgroudColorButton.Click += new System.EventHandler(this.BackgroudColorButton_Click);
      // 
      // UpdateTimer
      // 
      this.UpdateTimer.Enabled = true;
      this.UpdateTimer.Interval = 1;
      this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
      // 
      // TargetTestButton
      // 
      this.TargetTestButton.Location = new System.Drawing.Point(336, 28);
      this.TargetTestButton.Name = "TargetTestButton";
      this.TargetTestButton.Size = new System.Drawing.Size(75, 23);
      this.TargetTestButton.TabIndex = 8;
      this.TargetTestButton.Text = "Target";
      this.TargetTestButton.UseVisualStyleBackColor = true;
      this.TargetTestButton.Click += new System.EventHandler(this.TargetTestButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(503, 389);
      this.Controls.Add(this.TargetTestButton);
      this.Controls.Add(this.ToolStrip);
      this.Controls.Add(this.CameraTestButton);
      this.Controls.Add(this.TriangleTestButton);
      this.Controls.Add(this.PaintButton);
      this.Controls.Add(this.TestEarthButton);
      this.Controls.Add(this.OpenGLPanel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Solar System Simulator";
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Panel OpenGLPanel;
    private System.Windows.Forms.Button TestEarthButton;
    private System.Windows.Forms.Button PaintButton;
    private System.Windows.Forms.Button TriangleTestButton;
    private System.Windows.Forms.Button CameraTestButton;
    private System.Windows.Forms.ToolStrip ToolStrip;
    private System.Windows.Forms.ToolStripButton BackgroudColorButton;
    private System.Windows.Forms.Timer UpdateTimer;
    private System.Windows.Forms.Button TargetTestButton;
  }
}

