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
      this.XBar = new System.Windows.Forms.TrackBar();
      this.xLabel = new System.Windows.Forms.Label();
      this.YBar = new System.Windows.Forms.TrackBar();
      this.ZBar = new System.Windows.Forms.TrackBar();
      this.yLabel = new System.Windows.Forms.Label();
      this.zLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.XBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.YBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ZBar)).BeginInit();
      this.SuspendLayout();
      // 
      // XBar
      // 
      this.XBar.Location = new System.Drawing.Point(58, 12);
      this.XBar.Maximum = 360;
      this.XBar.Name = "XBar";
      this.XBar.Size = new System.Drawing.Size(707, 45);
      this.XBar.TabIndex = 0;
      this.XBar.Scroll += new System.EventHandler(this.XBar_Scroll);
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
      // YBar
      // 
      this.YBar.Location = new System.Drawing.Point(58, 63);
      this.YBar.Maximum = 360;
      this.YBar.Name = "YBar";
      this.YBar.Size = new System.Drawing.Size(707, 45);
      this.YBar.TabIndex = 2;
      this.YBar.Scroll += new System.EventHandler(this.YBar_Scroll);
      // 
      // ZBar
      // 
      this.ZBar.Location = new System.Drawing.Point(58, 112);
      this.ZBar.Maximum = 360;
      this.ZBar.Name = "ZBar";
      this.ZBar.Size = new System.Drawing.Size(707, 45);
      this.ZBar.TabIndex = 3;
      this.ZBar.Scroll += new System.EventHandler(this.ZBar_Scroll);
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
      this.Controls.Add(this.ZBar);
      this.Controls.Add(this.YBar);
      this.Controls.Add(this.xLabel);
      this.Controls.Add(this.XBar);
      this.Name = "RotationTest";
      this.Text = "RotationTest";
      ((System.ComponentModel.ISupportInitialize)(this.XBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.YBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ZBar)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TrackBar XBar;
    private System.Windows.Forms.Label xLabel;
    private System.Windows.Forms.TrackBar YBar;
    private System.Windows.Forms.TrackBar ZBar;
    private System.Windows.Forms.Label yLabel;
    private System.Windows.Forms.Label zLabel;
  }
}