namespace SolarSystem
{
  partial class CelestialPropertiesForm
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
      this.NameBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.RotationXBox = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.ytrack = new System.Windows.Forms.TrackBar();
      this.RotationZBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.ztrack = new System.Windows.Forms.TrackBar();
      this.RotationYBox = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.xtrack = new System.Windows.Forms.TrackBar();
      this.label2 = new System.Windows.Forms.Label();
      this.AutoUpdateCheckBox = new System.Windows.Forms.CheckBox();
      this.Timer = new System.Windows.Forms.Timer(this.components);
      this.label5 = new System.Windows.Forms.Label();
      this.TypeBox = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.PositionXBox = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.PositionYBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.PositionZBox = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ytrack)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ztrack)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.xtrack)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // NameBox
      // 
      this.NameBox.Location = new System.Drawing.Point(55, 6);
      this.NameBox.Name = "NameBox";
      this.NameBox.Size = new System.Drawing.Size(100, 20);
      this.NameBox.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Object";
      // 
      // RotationXBox
      // 
      this.RotationXBox.Location = new System.Drawing.Point(70, 13);
      this.RotationXBox.Name = "RotationXBox";
      this.RotationXBox.Size = new System.Drawing.Size(100, 20);
      this.RotationXBox.TabIndex = 2;
      this.RotationXBox.TextChanged += new System.EventHandler(this.RotationXBox_TextChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.ytrack);
      this.groupBox1.Controls.Add(this.RotationZBox);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.ztrack);
      this.groupBox1.Controls.Add(this.RotationYBox);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.xtrack);
      this.groupBox1.Controls.Add(this.RotationXBox);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Location = new System.Drawing.Point(12, 58);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(179, 253);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Rotation";
      // 
      // ytrack
      // 
      this.ytrack.Location = new System.Drawing.Point(9, 124);
      this.ytrack.Maximum = 360;
      this.ytrack.Name = "ytrack";
      this.ytrack.Size = new System.Drawing.Size(161, 45);
      this.ytrack.TabIndex = 6;
      this.ytrack.Scroll += new System.EventHandler(this.ytrack_Scroll);
      // 
      // RotationZBox
      // 
      this.RotationZBox.Location = new System.Drawing.Point(70, 169);
      this.RotationZBox.Name = "RotationZBox";
      this.RotationZBox.Size = new System.Drawing.Size(100, 20);
      this.RotationZBox.TabIndex = 4;
      this.RotationZBox.TextChanged += new System.EventHandler(this.RotationZBox_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 172);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(58, 13);
      this.label4.TabIndex = 2;
      this.label4.Text = "Revolution";
      // 
      // ztrack
      // 
      this.ztrack.Location = new System.Drawing.Point(9, 202);
      this.ztrack.Maximum = 360;
      this.ztrack.Name = "ztrack";
      this.ztrack.Size = new System.Drawing.Size(161, 45);
      this.ztrack.TabIndex = 10;
      this.ztrack.Scroll += new System.EventHandler(this.ztrack_Scroll);
      // 
      // RotationYBox
      // 
      this.RotationYBox.Location = new System.Drawing.Point(70, 92);
      this.RotationYBox.Name = "RotationYBox";
      this.RotationYBox.Size = new System.Drawing.Size(100, 20);
      this.RotationYBox.TabIndex = 3;
      this.RotationYBox.TextChanged += new System.EventHandler(this.RotationYBox_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 95);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(58, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Orientation";
      // 
      // xtrack
      // 
      this.xtrack.Location = new System.Drawing.Point(9, 41);
      this.xtrack.Maximum = 360;
      this.xtrack.Name = "xtrack";
      this.xtrack.Size = new System.Drawing.Size(161, 45);
      this.xtrack.TabIndex = 5;
      this.xtrack.Scroll += new System.EventHandler(this.xtrack_Scroll);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Inclination";
      // 
      // AutoUpdateCheckBox
      // 
      this.AutoUpdateCheckBox.AutoSize = true;
      this.AutoUpdateCheckBox.Location = new System.Drawing.Point(15, 423);
      this.AutoUpdateCheckBox.Name = "AutoUpdateCheckBox";
      this.AutoUpdateCheckBox.Size = new System.Drawing.Size(86, 17);
      this.AutoUpdateCheckBox.TabIndex = 7;
      this.AutoUpdateCheckBox.Text = "Auto Update";
      this.AutoUpdateCheckBox.UseVisualStyleBackColor = true;
      // 
      // Timer
      // 
      this.Timer.Enabled = true;
      this.Timer.Interval = 250;
      this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 35);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(31, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Type";
      // 
      // TypeBox
      // 
      this.TypeBox.Location = new System.Drawing.Point(55, 32);
      this.TypeBox.Name = "TypeBox";
      this.TypeBox.Size = new System.Drawing.Size(100, 20);
      this.TypeBox.TabIndex = 8;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.PositionZBox);
      this.groupBox2.Controls.Add(this.label8);
      this.groupBox2.Controls.Add(this.PositionYBox);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.PositionXBox);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Location = new System.Drawing.Point(12, 317);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(179, 100);
      this.groupBox2.TabIndex = 10;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Position";
      // 
      // PositionXBox
      // 
      this.PositionXBox.Location = new System.Drawing.Point(70, 19);
      this.PositionXBox.Name = "PositionXBox";
      this.PositionXBox.Size = new System.Drawing.Size(100, 20);
      this.PositionXBox.TabIndex = 12;
      this.PositionXBox.TextChanged += new System.EventHandler(this.PositionXBox_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 22);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(14, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "X";
      // 
      // PositionYBox
      // 
      this.PositionYBox.Location = new System.Drawing.Point(70, 45);
      this.PositionYBox.Name = "PositionYBox";
      this.PositionYBox.Size = new System.Drawing.Size(100, 20);
      this.PositionYBox.TabIndex = 14;
      this.PositionYBox.TextChanged += new System.EventHandler(this.PositionYBox_TextChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 48);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(14, 13);
      this.label7.TabIndex = 13;
      this.label7.Text = "Y";
      // 
      // PositionZBox
      // 
      this.PositionZBox.Location = new System.Drawing.Point(70, 71);
      this.PositionZBox.Name = "PositionZBox";
      this.PositionZBox.Size = new System.Drawing.Size(100, 20);
      this.PositionZBox.TabIndex = 16;
      this.PositionZBox.TextChanged += new System.EventHandler(this.PositionZBox_TextChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(6, 74);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(14, 13);
      this.label8.TabIndex = 15;
      this.label8.Text = "Z";
      // 
      // CelestialPropertiesForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(205, 450);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.TypeBox);
      this.Controls.Add(this.AutoUpdateCheckBox);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.NameBox);
      this.Name = "CelestialPropertiesForm";
      this.Text = "CelestialPropertiesForm";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ytrack)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ztrack)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.xtrack)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox NameBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox RotationXBox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox RotationYBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox RotationZBox;
    private System.Windows.Forms.CheckBox AutoUpdateCheckBox;
    private System.Windows.Forms.Timer Timer;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox TypeBox;
    private System.Windows.Forms.TrackBar xtrack;
    private System.Windows.Forms.TrackBar ytrack;
    private System.Windows.Forms.TrackBar ztrack;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox PositionZBox;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox PositionYBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox PositionXBox;
    private System.Windows.Forms.Label label6;
  }
}