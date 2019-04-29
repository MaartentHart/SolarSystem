namespace SolarSystem.Debugging
{
  partial class RotationTest
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
      this.xBar = new System.Windows.Forms.TrackBar();
      this.xLabel = new System.Windows.Forms.Label();
      this.yBar = new System.Windows.Forms.TrackBar();
      this.zBar = new System.Windows.Forms.TrackBar();
      this.yLabel = new System.Windows.Forms.Label();
      this.zLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.xBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.yBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.zBar)).BeginInit();
      this.SuspendLayout();
      // 
      // xBar
      // 
      this.xBar.Location = new System.Drawing.Point(58, 12);
      this.xBar.Maximum = 360;
      this.xBar.Name = "xBar";
      this.xBar.Size = new System.Drawing.Size(707, 45);
      this.xBar.TabIndex = 0;
      this.xBar.Scroll += new System.EventHandler(this.xBar_Scroll);
      // 
      // xLabel
      // 
      this.xLabel.AutoSize = true;
      this.xLabel.Location = new System.Drawing.Point(771, 12);
      this.xLabel.Name = "xLabel";
      this.xLabel.Size = new System.Drawing.Size(24, 13);
      this.xLabel.TabIndex = 1;
      this.xLabel.Text = "x: 0";
      // 
      // yBar
      // 
      this.yBar.Location = new System.Drawing.Point(58, 63);
      this.yBar.Maximum = 360;
      this.yBar.Name = "yBar";
      this.yBar.Size = new System.Drawing.Size(707, 45);
      this.yBar.TabIndex = 2;
      this.yBar.Scroll += new System.EventHandler(this.yBar_Scroll);
      // 
      // zBar
      // 
      this.zBar.Location = new System.Drawing.Point(58, 112);
      this.zBar.Maximum = 360;
      this.zBar.Name = "zBar";
      this.zBar.Size = new System.Drawing.Size(707, 45);
      this.zBar.TabIndex = 3;
      this.zBar.Scroll += new System.EventHandler(this.zBar_Scroll);
      // 
      // yLabel
      // 
      this.yLabel.AutoSize = true;
      this.yLabel.Location = new System.Drawing.Point(771, 63);
      this.yLabel.Name = "yLabel";
      this.yLabel.Size = new System.Drawing.Size(24, 13);
      this.yLabel.TabIndex = 4;
      this.yLabel.Text = "y: 0";
      // 
      // zLabel
      // 
      this.zLabel.AutoSize = true;
      this.zLabel.Location = new System.Drawing.Point(771, 112);
      this.zLabel.Name = "zLabel";
      this.zLabel.Size = new System.Drawing.Size(24, 13);
      this.zLabel.TabIndex = 5;
      this.zLabel.Text = "z: 0";
      // 
      // RotationTest
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1006, 169);
      this.Controls.Add(this.zLabel);
      this.Controls.Add(this.yLabel);
      this.Controls.Add(this.zBar);
      this.Controls.Add(this.yBar);
      this.Controls.Add(this.xLabel);
      this.Controls.Add(this.xBar);
      this.Name = "RotationTest";
      this.Text = "RotationTest";
      ((System.ComponentModel.ISupportInitialize)(this.xBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.yBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.zBar)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TrackBar xBar;
    private System.Windows.Forms.Label xLabel;
    private System.Windows.Forms.TrackBar yBar;
    private System.Windows.Forms.TrackBar zBar;
    private System.Windows.Forms.Label yLabel;
    private System.Windows.Forms.Label zLabel;
  }
}