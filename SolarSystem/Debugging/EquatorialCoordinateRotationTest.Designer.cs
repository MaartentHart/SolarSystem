namespace SolarSystem.Debugging
{
  partial class EquatorialRotationTest
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
      this.yLabel = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.zLabel = new System.Windows.Forms.Label();
      this.ZBar = new System.Windows.Forms.TrackBar();
      ((System.ComponentModel.ISupportInitialize)(this.XBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.YBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ZBar)).BeginInit();
      this.SuspendLayout();
      // 
      // XBar
      // 
      this.XBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.XBar.Location = new System.Drawing.Point(111, 12);
      this.XBar.Maximum = 360;
      this.XBar.Name = "XBar";
      this.XBar.Size = new System.Drawing.Size(646, 45);
      this.XBar.TabIndex = 0;
      this.XBar.Scroll += new System.EventHandler(this.XBar_Scroll);
      // 
      // xLabel
      // 
      this.xLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.xLabel.AutoSize = true;
      this.xLabel.Location = new System.Drawing.Point(763, 12);
      this.xLabel.Name = "xLabel";
      this.xLabel.Size = new System.Drawing.Size(24, 13);
      this.xLabel.TabIndex = 1;
      this.xLabel.Text = "x: 0";
      // 
      // YBar
      // 
      this.YBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.YBar.Location = new System.Drawing.Point(111, 63);
      this.YBar.Maximum = 360;
      this.YBar.Name = "YBar";
      this.YBar.Size = new System.Drawing.Size(646, 45);
      this.YBar.TabIndex = 2;
      this.YBar.Scroll += new System.EventHandler(this.YBar_Scroll);
      // 
      // yLabel
      // 
      this.yLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.yLabel.AutoSize = true;
      this.yLabel.Location = new System.Drawing.Point(763, 63);
      this.yLabel.Name = "yLabel";
      this.yLabel.Size = new System.Drawing.Size(24, 13);
      this.yLabel.TabIndex = 4;
      this.yLabel.Text = "y: 0";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(21, 63);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Declination:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(21, 12);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(84, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "RightAscension:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(21, 112);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(65, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Around axis:";
      // 
      // zLabel
      // 
      this.zLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.zLabel.AutoSize = true;
      this.zLabel.Location = new System.Drawing.Point(763, 112);
      this.zLabel.Name = "zLabel";
      this.zLabel.Size = new System.Drawing.Size(24, 13);
      this.zLabel.TabIndex = 5;
      this.zLabel.Text = "z: 0";
      // 
      // ZBar
      // 
      this.ZBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ZBar.Location = new System.Drawing.Point(111, 112);
      this.ZBar.Maximum = 360;
      this.ZBar.Name = "ZBar";
      this.ZBar.Size = new System.Drawing.Size(646, 45);
      this.ZBar.TabIndex = 3;
      this.ZBar.Scroll += new System.EventHandler(this.ZBar_Scroll);
      // 
      // EquatorialRotationTest
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(818, 169);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.zLabel);
      this.Controls.Add(this.yLabel);
      this.Controls.Add(this.ZBar);
      this.Controls.Add(this.YBar);
      this.Controls.Add(this.xLabel);
      this.Controls.Add(this.XBar);
      this.Name = "EquatorialRotationTest";
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
    private System.Windows.Forms.Label yLabel;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label zLabel;
    private System.Windows.Forms.TrackBar ZBar;
  }
}