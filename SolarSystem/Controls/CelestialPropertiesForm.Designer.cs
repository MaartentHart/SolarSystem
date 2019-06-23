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
      this.AutoUpdateCheckBox = new System.Windows.Forms.CheckBox();
      this.Timer = new System.Windows.Forms.Timer(this.components);
      this.label5 = new System.Windows.Forms.Label();
      this.TypeBox = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.PositionZBox = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.PositionYBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.PositionXBox = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.VelocityZBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.VelocityYBox = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.VelocityXBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.SpeedBox = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.DistanceBox = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
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
      // AutoUpdateCheckBox
      // 
      this.AutoUpdateCheckBox.AutoSize = true;
      this.AutoUpdateCheckBox.Location = new System.Drawing.Point(12, 323);
      this.AutoUpdateCheckBox.Name = "AutoUpdateCheckBox";
      this.AutoUpdateCheckBox.Size = new System.Drawing.Size(86, 17);
      this.AutoUpdateCheckBox.TabIndex = 7;
      this.AutoUpdateCheckBox.Text = "Auto Update";
      this.AutoUpdateCheckBox.UseVisualStyleBackColor = true;
      this.AutoUpdateCheckBox.CheckedChanged += new System.EventHandler(this.AutoUpdateCheckBox_CheckedChanged);
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
      this.groupBox2.Controls.Add(this.DistanceBox);
      this.groupBox2.Controls.Add(this.label10);
      this.groupBox2.Controls.Add(this.PositionZBox);
      this.groupBox2.Controls.Add(this.label8);
      this.groupBox2.Controls.Add(this.PositionYBox);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.PositionXBox);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Location = new System.Drawing.Point(12, 58);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(179, 126);
      this.groupBox2.TabIndex = 10;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Position";
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
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.SpeedBox);
      this.groupBox1.Controls.Add(this.label9);
      this.groupBox1.Controls.Add(this.VelocityZBox);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.VelocityYBox);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.VelocityXBox);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Location = new System.Drawing.Point(12, 190);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(179, 127);
      this.groupBox1.TabIndex = 17;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Velocity";
      // 
      // VelocityZBox
      // 
      this.VelocityZBox.Location = new System.Drawing.Point(70, 71);
      this.VelocityZBox.Name = "VelocityZBox";
      this.VelocityZBox.Size = new System.Drawing.Size(100, 20);
      this.VelocityZBox.TabIndex = 16;
      this.VelocityZBox.TextChanged += new System.EventHandler(this.VelocityZBox_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 74);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(14, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Z";
      // 
      // VelocityYBox
      // 
      this.VelocityYBox.Location = new System.Drawing.Point(70, 45);
      this.VelocityYBox.Name = "VelocityYBox";
      this.VelocityYBox.Size = new System.Drawing.Size(100, 20);
      this.VelocityYBox.TabIndex = 14;
      this.VelocityYBox.TextChanged += new System.EventHandler(this.VelocityYBox_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 48);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(14, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Y";
      // 
      // VelocityXBox
      // 
      this.VelocityXBox.Location = new System.Drawing.Point(70, 19);
      this.VelocityXBox.Name = "VelocityXBox";
      this.VelocityXBox.Size = new System.Drawing.Size(100, 20);
      this.VelocityXBox.TabIndex = 12;
      this.VelocityXBox.TextChanged += new System.EventHandler(this.VelocityXBox_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 22);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(14, 13);
      this.label4.TabIndex = 11;
      this.label4.Text = "X";
      // 
      // SpeedBox
      // 
      this.SpeedBox.Location = new System.Drawing.Point(70, 97);
      this.SpeedBox.Name = "SpeedBox";
      this.SpeedBox.Size = new System.Drawing.Size(100, 20);
      this.SpeedBox.TabIndex = 18;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(6, 100);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(38, 13);
      this.label9.TabIndex = 17;
      this.label9.Text = "Speed";
      // 
      // DistanceBox
      // 
      this.DistanceBox.Location = new System.Drawing.Point(70, 97);
      this.DistanceBox.Name = "DistanceBox";
      this.DistanceBox.Size = new System.Drawing.Size(100, 20);
      this.DistanceBox.TabIndex = 18;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(6, 100);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(49, 13);
      this.label10.TabIndex = 17;
      this.label10.Text = "Distance";
      // 
      // CelestialPropertiesForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(197, 346);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.TypeBox);
      this.Controls.Add(this.AutoUpdateCheckBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.NameBox);
      this.Name = "CelestialPropertiesForm";
      this.Text = "CelestialPropertiesForm";
      this.Load += new System.EventHandler(this.CelestialPropertiesForm_Load);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox NameBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox AutoUpdateCheckBox;
    private System.Windows.Forms.Timer Timer;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox TypeBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox PositionZBox;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox PositionYBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox PositionXBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox VelocityZBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox VelocityYBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox VelocityXBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox SpeedBox;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox DistanceBox;
    private System.Windows.Forms.Label label10;
  }
}