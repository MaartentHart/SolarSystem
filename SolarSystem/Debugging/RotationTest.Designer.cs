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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.SystemRotationBox = new System.Windows.Forms.GroupBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.XLocalBar = new System.Windows.Forms.TrackBar();
      this.label4 = new System.Windows.Forms.Label();
      this.xLocalLabel = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.YLocalBar = new System.Windows.Forms.TrackBar();
      this.label7 = new System.Windows.Forms.Label();
      this.ZLocalBar = new System.Windows.Forms.TrackBar();
      this.zLocalLabel = new System.Windows.Forms.Label();
      this.yLocalLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.XBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.YBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ZBar)).BeginInit();
      this.SystemRotationBox.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.XLocalBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.YLocalBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ZLocalBar)).BeginInit();
      this.SuspendLayout();
      // 
      // XBar
      // 
      this.XBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.XBar.Location = new System.Drawing.Point(47, 19);
      this.XBar.Maximum = 360;
      this.XBar.Name = "XBar";
      this.XBar.Size = new System.Drawing.Size(699, 45);
      this.XBar.TabIndex = 0;
      this.XBar.Scroll += new System.EventHandler(this.XBar_Scroll);
      // 
      // xLabel
      // 
      this.xLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.xLabel.AutoSize = true;
      this.xLabel.Location = new System.Drawing.Point(752, 19);
      this.xLabel.Name = "xLabel";
      this.xLabel.Size = new System.Drawing.Size(24, 13);
      this.xLabel.TabIndex = 1;
      this.xLabel.Text = "x: 0";
      // 
      // YBar
      // 
      this.YBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.YBar.Location = new System.Drawing.Point(47, 70);
      this.YBar.Maximum = 360;
      this.YBar.Name = "YBar";
      this.YBar.Size = new System.Drawing.Size(699, 45);
      this.YBar.TabIndex = 2;
      this.YBar.Scroll += new System.EventHandler(this.YBar_Scroll);
      // 
      // ZBar
      // 
      this.ZBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ZBar.Location = new System.Drawing.Point(47, 119);
      this.ZBar.Maximum = 360;
      this.ZBar.Name = "ZBar";
      this.ZBar.Size = new System.Drawing.Size(699, 45);
      this.ZBar.TabIndex = 3;
      this.ZBar.Scroll += new System.EventHandler(this.ZBar_Scroll);
      // 
      // yLabel
      // 
      this.yLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.yLabel.AutoSize = true;
      this.yLabel.Location = new System.Drawing.Point(752, 70);
      this.yLabel.Name = "yLabel";
      this.yLabel.Size = new System.Drawing.Size(24, 13);
      this.yLabel.TabIndex = 4;
      this.yLabel.Text = "y: 0";
      // 
      // zLabel
      // 
      this.zLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.zLabel.AutoSize = true;
      this.zLabel.Location = new System.Drawing.Point(752, 119);
      this.zLabel.Name = "zLabel";
      this.zLabel.Size = new System.Drawing.Size(24, 13);
      this.zLabel.TabIndex = 5;
      this.zLabel.Text = "z: 0";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 119);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(31, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Yaw:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 70);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(34, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Pitch:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 19);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(28, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "Roll:";
      // 
      // SystemRotationBox
      // 
      this.SystemRotationBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.SystemRotationBox.Controls.Add(this.XBar);
      this.SystemRotationBox.Controls.Add(this.label3);
      this.SystemRotationBox.Controls.Add(this.xLabel);
      this.SystemRotationBox.Controls.Add(this.label2);
      this.SystemRotationBox.Controls.Add(this.YBar);
      this.SystemRotationBox.Controls.Add(this.label1);
      this.SystemRotationBox.Controls.Add(this.ZBar);
      this.SystemRotationBox.Controls.Add(this.zLabel);
      this.SystemRotationBox.Controls.Add(this.yLabel);
      this.SystemRotationBox.Location = new System.Drawing.Point(12, 12);
      this.SystemRotationBox.Name = "SystemRotationBox";
      this.SystemRotationBox.Size = new System.Drawing.Size(794, 164);
      this.SystemRotationBox.TabIndex = 9;
      this.SystemRotationBox.TabStop = false;
      this.SystemRotationBox.Text = "System Rotation";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.XLocalBar);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.xLocalLabel);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.YLocalBar);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.ZLocalBar);
      this.groupBox1.Controls.Add(this.zLocalLabel);
      this.groupBox1.Controls.Add(this.yLocalLabel);
      this.groupBox1.Location = new System.Drawing.Point(12, 182);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(794, 164);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Local Rotation";
      // 
      // XLocalBar
      // 
      this.XLocalBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.XLocalBar.Location = new System.Drawing.Point(47, 19);
      this.XLocalBar.Maximum = 360;
      this.XLocalBar.Name = "XLocalBar";
      this.XLocalBar.Size = new System.Drawing.Size(699, 45);
      this.XLocalBar.TabIndex = 0;
      this.XLocalBar.Scroll += new System.EventHandler(this.XLocalBar_Scroll);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 19);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(28, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Roll:";
      // 
      // xLocalLabel
      // 
      this.xLocalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.xLocalLabel.AutoSize = true;
      this.xLocalLabel.Location = new System.Drawing.Point(752, 19);
      this.xLocalLabel.Name = "xLocalLabel";
      this.xLocalLabel.Size = new System.Drawing.Size(24, 13);
      this.xLocalLabel.TabIndex = 1;
      this.xLocalLabel.Text = "x: 0";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(10, 70);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(34, 13);
      this.label6.TabIndex = 7;
      this.label6.Text = "Pitch:";
      // 
      // YLocalBar
      // 
      this.YLocalBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.YLocalBar.Location = new System.Drawing.Point(47, 70);
      this.YLocalBar.Maximum = 360;
      this.YLocalBar.Name = "YLocalBar";
      this.YLocalBar.Size = new System.Drawing.Size(699, 45);
      this.YLocalBar.TabIndex = 2;
      this.YLocalBar.Scroll += new System.EventHandler(this.YLocalBar_Scroll);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(10, 119);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(31, 13);
      this.label7.TabIndex = 6;
      this.label7.Text = "Yaw:";
      // 
      // ZLocalBar
      // 
      this.ZLocalBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ZLocalBar.Location = new System.Drawing.Point(47, 119);
      this.ZLocalBar.Maximum = 360;
      this.ZLocalBar.Name = "ZLocalBar";
      this.ZLocalBar.Size = new System.Drawing.Size(699, 45);
      this.ZLocalBar.TabIndex = 3;
      this.ZLocalBar.Scroll += new System.EventHandler(this.ZLocalBar_Scroll);
      // 
      // zLocalLabel
      // 
      this.zLocalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.zLocalLabel.AutoSize = true;
      this.zLocalLabel.Location = new System.Drawing.Point(752, 119);
      this.zLocalLabel.Name = "zLocalLabel";
      this.zLocalLabel.Size = new System.Drawing.Size(24, 13);
      this.zLocalLabel.TabIndex = 5;
      this.zLocalLabel.Text = "z: 0";
      // 
      // yLocalLabel
      // 
      this.yLocalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.yLocalLabel.AutoSize = true;
      this.yLocalLabel.Location = new System.Drawing.Point(752, 70);
      this.yLocalLabel.Name = "yLocalLabel";
      this.yLocalLabel.Size = new System.Drawing.Size(24, 13);
      this.yLocalLabel.TabIndex = 4;
      this.yLocalLabel.Text = "y: 0";
      // 
      // RotationTest
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(818, 363);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.SystemRotationBox);
      this.Name = "RotationTest";
      this.Text = "RotationTest";
      ((System.ComponentModel.ISupportInitialize)(this.XBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.YBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ZBar)).EndInit();
      this.SystemRotationBox.ResumeLayout(false);
      this.SystemRotationBox.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.XLocalBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.YLocalBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ZLocalBar)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TrackBar XBar;
    private System.Windows.Forms.Label xLabel;
    private System.Windows.Forms.TrackBar YBar;
    private System.Windows.Forms.TrackBar ZBar;
    private System.Windows.Forms.Label yLabel;
    private System.Windows.Forms.Label zLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox SystemRotationBox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TrackBar XLocalBar;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label xLocalLabel;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TrackBar YLocalBar;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TrackBar ZLocalBar;
    private System.Windows.Forms.Label zLocalLabel;
    private System.Windows.Forms.Label yLocalLabel;
  }
}