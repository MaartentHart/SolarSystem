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
      this.TestEarthButton = new System.Windows.Forms.Button();
      this.TriangleTestButton = new System.Windows.Forms.Button();
      this.SampleFormTestButton = new System.Windows.Forms.Button();
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.TargetTestButton = new System.Windows.Forms.Button();
      this.GlView = new SolarSystem.GlView();
      this.ScaleTestButton = new System.Windows.Forms.Button();
      this.HeigtmapTestButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
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
      // SampleFormTestButton
      // 
      this.SampleFormTestButton.Location = new System.Drawing.Point(255, 28);
      this.SampleFormTestButton.Name = "SampleFormTestButton";
      this.SampleFormTestButton.Size = new System.Drawing.Size(75, 23);
      this.SampleFormTestButton.TabIndex = 6;
      this.SampleFormTestButton.Text = "Sample Form";
      this.SampleFormTestButton.UseVisualStyleBackColor = true;
      this.SampleFormTestButton.Click += new System.EventHandler(this.SampleFormTestButton_Click);
      // 
      // ToolStrip
      // 
      this.ToolStrip.Location = new System.Drawing.Point(0, 0);
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.Size = new System.Drawing.Size(503, 25);
      this.ToolStrip.TabIndex = 7;
      this.ToolStrip.Text = "toolStrip1";
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
      // GlView
      // 
      this.GlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlView.Location = new System.Drawing.Point(12, 57);
      this.GlView.Name = "GlView";
      this.GlView.Size = new System.Drawing.Size(479, 320);
      this.GlView.TabIndex = 10;
      // 
      // ScaleTestButton
      // 
      this.ScaleTestButton.Location = new System.Drawing.Point(93, 28);
      this.ScaleTestButton.Name = "ScaleTestButton";
      this.ScaleTestButton.Size = new System.Drawing.Size(75, 23);
      this.ScaleTestButton.TabIndex = 11;
      this.ScaleTestButton.Text = "Scale";
      this.ScaleTestButton.UseVisualStyleBackColor = true;
      this.ScaleTestButton.Click += new System.EventHandler(this.ScaleTestButton_Click);
      // 
      // HeigtmapTestButton
      // 
      this.HeigtmapTestButton.Location = new System.Drawing.Point(417, 28);
      this.HeigtmapTestButton.Name = "HeigtmapTestButton";
      this.HeigtmapTestButton.Size = new System.Drawing.Size(75, 23);
      this.HeigtmapTestButton.TabIndex = 12;
      this.HeigtmapTestButton.Text = "HeightMap";
      this.HeigtmapTestButton.UseVisualStyleBackColor = true;
      this.HeigtmapTestButton.Click += new System.EventHandler(this.HeigtmapTestButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(503, 389);
      this.Controls.Add(this.HeigtmapTestButton);
      this.Controls.Add(this.ScaleTestButton);
      this.Controls.Add(this.GlView);
      this.Controls.Add(this.TargetTestButton);
      this.Controls.Add(this.ToolStrip);
      this.Controls.Add(this.SampleFormTestButton);
      this.Controls.Add(this.TriangleTestButton);
      this.Controls.Add(this.TestEarthButton);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Solar System Simulator";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button TestEarthButton;
    private System.Windows.Forms.Button TriangleTestButton;
    private System.Windows.Forms.Button SampleFormTestButton;
    private System.Windows.Forms.ToolStrip ToolStrip;
    private System.Windows.Forms.Timer UpdateTimer;
    private System.Windows.Forms.Button TargetTestButton;
    private GlView GlView;
    private System.Windows.Forms.Button ScaleTestButton;
    private System.Windows.Forms.Button HeigtmapTestButton;
  }
}

