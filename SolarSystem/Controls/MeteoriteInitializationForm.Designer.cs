namespace SolarSystem
{
  partial class MeteoriteInitializationForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label11 = new System.Windows.Forms.Label();
      this.DistanceToBox = new System.Windows.Forms.ComboBox();
      this.PositionDeclinationTrackBar = new SolarSystem.TextBoxTrackBar();
      this.PositionZBox = new System.Windows.Forms.TextBox();
      this.PositionRightAssensionTrackBar = new SolarSystem.TextBoxTrackBar();
      this.PositionYBox = new System.Windows.Forms.TextBox();
      this.PositionXBox = new System.Windows.Forms.TextBox();
      this.DistanceBox = new SolarSystem.TextBoxTrackBar();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.VelocityDeclinationTrackBar = new SolarSystem.TextBoxTrackBar();
      this.VelocityZBox = new System.Windows.Forms.TextBox();
      this.VelocityRightAscensionTrackBar = new SolarSystem.TextBoxTrackBar();
      this.VelocityYBox = new System.Windows.Forms.TextBox();
      this.SpeedTrackBar = new SolarSystem.TextBoxTrackBar();
      this.VelocityXBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.label7 = new System.Windows.Forms.Label();
      this.InitialRadiusBox = new System.Windows.Forms.TextBox();
      this.DetailLevelTrackBar = new SolarSystem.TextBoxTrackBar();
      this.label10 = new System.Windows.Forms.Label();
      this.StepsBox = new System.Windows.Forms.TextBox();
      this.SpeedStepBox = new System.Windows.Forms.TextBox();
      this.MinimumSpeedBox = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.OKButton = new System.Windows.Forms.Button();
      this.Cancel_Button = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(14, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "X";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(132, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(14, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Y";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(258, 16);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(14, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Z";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label11);
      this.groupBox1.Controls.Add(this.DistanceToBox);
      this.groupBox1.Controls.Add(this.PositionDeclinationTrackBar);
      this.groupBox1.Controls.Add(this.PositionZBox);
      this.groupBox1.Controls.Add(this.PositionRightAssensionTrackBar);
      this.groupBox1.Controls.Add(this.PositionYBox);
      this.groupBox1.Controls.Add(this.PositionXBox);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.DistanceBox);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(386, 163);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Position";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(6, 42);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(64, 13);
      this.label11.TabIndex = 13;
      this.label11.Text = "Distance to:";
      // 
      // DistanceToBox
      // 
      this.DistanceToBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.DistanceToBox.FormattingEnabled = true;
      this.DistanceToBox.Location = new System.Drawing.Point(90, 39);
      this.DistanceToBox.Name = "DistanceToBox";
      this.DistanceToBox.Size = new System.Drawing.Size(100, 21);
      this.DistanceToBox.TabIndex = 12;
      // 
      // PositionDeclinationTrackBar
      // 
      this.PositionDeclinationTrackBar.AllowOutOfBounds = true;
      this.PositionDeclinationTrackBar.ForceInteger = false;
      this.PositionDeclinationTrackBar.FourthPower = false;
      this.PositionDeclinationTrackBar.Location = new System.Drawing.Point(3, 128);
      this.PositionDeclinationTrackBar.Maximum = 90D;
      this.PositionDeclinationTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.PositionDeclinationTrackBar.Minimum = -90D;
      this.PositionDeclinationTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.PositionDeclinationTrackBar.Name = "PositionDeclinationTrackBar";
      this.PositionDeclinationTrackBar.Quadratic = false;
      this.PositionDeclinationTrackBar.Size = new System.Drawing.Size(375, 25);
      this.PositionDeclinationTrackBar.TabIndex = 15;
      this.PositionDeclinationTrackBar.Title = "Declination";
      this.PositionDeclinationTrackBar.Value = 0D;
      // 
      // PositionZBox
      // 
      this.PositionZBox.Location = new System.Drawing.Point(278, 13);
      this.PositionZBox.Name = "PositionZBox";
      this.PositionZBox.Size = new System.Drawing.Size(100, 20);
      this.PositionZBox.TabIndex = 5;
      this.PositionZBox.Text = "0";
      // 
      // PositionRightAssensionTrackBar
      // 
      this.PositionRightAssensionTrackBar.AllowOutOfBounds = true;
      this.PositionRightAssensionTrackBar.ForceInteger = false;
      this.PositionRightAssensionTrackBar.FourthPower = false;
      this.PositionRightAssensionTrackBar.Location = new System.Drawing.Point(3, 97);
      this.PositionRightAssensionTrackBar.Maximum = 360D;
      this.PositionRightAssensionTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.PositionRightAssensionTrackBar.Minimum = 0D;
      this.PositionRightAssensionTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.PositionRightAssensionTrackBar.Name = "PositionRightAssensionTrackBar";
      this.PositionRightAssensionTrackBar.Quadratic = false;
      this.PositionRightAssensionTrackBar.Size = new System.Drawing.Size(375, 25);
      this.PositionRightAssensionTrackBar.TabIndex = 14;
      this.PositionRightAssensionTrackBar.Title = "Right Ascension";
      this.PositionRightAssensionTrackBar.Value = 0D;
      // 
      // PositionYBox
      // 
      this.PositionYBox.Location = new System.Drawing.Point(152, 13);
      this.PositionYBox.Name = "PositionYBox";
      this.PositionYBox.Size = new System.Drawing.Size(100, 20);
      this.PositionYBox.TabIndex = 4;
      this.PositionYBox.Text = "0";
      // 
      // PositionXBox
      // 
      this.PositionXBox.Location = new System.Drawing.Point(26, 13);
      this.PositionXBox.Name = "PositionXBox";
      this.PositionXBox.Size = new System.Drawing.Size(100, 20);
      this.PositionXBox.TabIndex = 3;
      this.PositionXBox.Text = "149600000";
      // 
      // DistanceBox
      // 
      this.DistanceBox.AllowOutOfBounds = true;
      this.DistanceBox.ForceInteger = false;
      this.DistanceBox.FourthPower = true;
      this.DistanceBox.Location = new System.Drawing.Point(3, 66);
      this.DistanceBox.Maximum = 300000000D;
      this.DistanceBox.MaximumSize = new System.Drawing.Size(10000, 25);
      this.DistanceBox.Minimum = 0D;
      this.DistanceBox.MinimumSize = new System.Drawing.Size(0, 25);
      this.DistanceBox.Name = "DistanceBox";
      this.DistanceBox.Quadratic = false;
      this.DistanceBox.Size = new System.Drawing.Size(375, 25);
      this.DistanceBox.TabIndex = 11;
      this.DistanceBox.Title = "Distance (km)";
      this.DistanceBox.Value = 10000000D;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.VelocityDeclinationTrackBar);
      this.groupBox2.Controls.Add(this.VelocityZBox);
      this.groupBox2.Controls.Add(this.VelocityRightAscensionTrackBar);
      this.groupBox2.Controls.Add(this.VelocityYBox);
      this.groupBox2.Controls.Add(this.SpeedTrackBar);
      this.groupBox2.Controls.Add(this.VelocityXBox);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Location = new System.Drawing.Point(12, 181);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(386, 133);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Velocity";
      // 
      // VelocityDeclinationTrackBar
      // 
      this.VelocityDeclinationTrackBar.AllowOutOfBounds = true;
      this.VelocityDeclinationTrackBar.ForceInteger = false;
      this.VelocityDeclinationTrackBar.FourthPower = false;
      this.VelocityDeclinationTrackBar.Location = new System.Drawing.Point(3, 101);
      this.VelocityDeclinationTrackBar.Maximum = 90D;
      this.VelocityDeclinationTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.VelocityDeclinationTrackBar.Minimum = -90D;
      this.VelocityDeclinationTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.VelocityDeclinationTrackBar.Name = "VelocityDeclinationTrackBar";
      this.VelocityDeclinationTrackBar.Quadratic = false;
      this.VelocityDeclinationTrackBar.Size = new System.Drawing.Size(375, 25);
      this.VelocityDeclinationTrackBar.TabIndex = 18;
      this.VelocityDeclinationTrackBar.Title = "Declination";
      this.VelocityDeclinationTrackBar.Value = 0D;
      // 
      // VelocityZBox
      // 
      this.VelocityZBox.Location = new System.Drawing.Point(278, 13);
      this.VelocityZBox.Name = "VelocityZBox";
      this.VelocityZBox.Size = new System.Drawing.Size(100, 20);
      this.VelocityZBox.TabIndex = 5;
      this.VelocityZBox.Text = "0.0";
      // 
      // VelocityRightAscensionTrackBar
      // 
      this.VelocityRightAscensionTrackBar.AllowOutOfBounds = true;
      this.VelocityRightAscensionTrackBar.ForceInteger = false;
      this.VelocityRightAscensionTrackBar.FourthPower = false;
      this.VelocityRightAscensionTrackBar.Location = new System.Drawing.Point(3, 70);
      this.VelocityRightAscensionTrackBar.Maximum = 360D;
      this.VelocityRightAscensionTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.VelocityRightAscensionTrackBar.Minimum = 0D;
      this.VelocityRightAscensionTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.VelocityRightAscensionTrackBar.Name = "VelocityRightAscensionTrackBar";
      this.VelocityRightAscensionTrackBar.Quadratic = false;
      this.VelocityRightAscensionTrackBar.Size = new System.Drawing.Size(375, 25);
      this.VelocityRightAscensionTrackBar.TabIndex = 17;
      this.VelocityRightAscensionTrackBar.Title = "Right Ascension";
      this.VelocityRightAscensionTrackBar.Value = 0D;
      // 
      // VelocityYBox
      // 
      this.VelocityYBox.Location = new System.Drawing.Point(152, 13);
      this.VelocityYBox.Name = "VelocityYBox";
      this.VelocityYBox.Size = new System.Drawing.Size(100, 20);
      this.VelocityYBox.TabIndex = 4;
      this.VelocityYBox.Text = "30.0";
      // 
      // SpeedTrackBar
      // 
      this.SpeedTrackBar.AllowOutOfBounds = true;
      this.SpeedTrackBar.ForceInteger = false;
      this.SpeedTrackBar.FourthPower = false;
      this.SpeedTrackBar.Location = new System.Drawing.Point(3, 39);
      this.SpeedTrackBar.Maximum = 300D;
      this.SpeedTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.SpeedTrackBar.Minimum = 0D;
      this.SpeedTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.SpeedTrackBar.Name = "SpeedTrackBar";
      this.SpeedTrackBar.Quadratic = false;
      this.SpeedTrackBar.Size = new System.Drawing.Size(375, 25);
      this.SpeedTrackBar.TabIndex = 16;
      this.SpeedTrackBar.Title = "Speed (km/s)";
      this.SpeedTrackBar.Value = 30D;
      // 
      // VelocityXBox
      // 
      this.VelocityXBox.Location = new System.Drawing.Point(26, 13);
      this.VelocityXBox.Name = "VelocityXBox";
      this.VelocityXBox.Size = new System.Drawing.Size(100, 20);
      this.VelocityXBox.TabIndex = 3;
      this.VelocityXBox.Text = "0.0";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 16);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(14, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "X";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(132, 16);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(14, 13);
      this.label5.TabIndex = 1;
      this.label5.Text = "Y";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(258, 16);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(14, 13);
      this.label6.TabIndex = 2;
      this.label6.Text = "Z";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.label7);
      this.groupBox3.Controls.Add(this.InitialRadiusBox);
      this.groupBox3.Controls.Add(this.DetailLevelTrackBar);
      this.groupBox3.Controls.Add(this.label10);
      this.groupBox3.Controls.Add(this.StepsBox);
      this.groupBox3.Controls.Add(this.SpeedStepBox);
      this.groupBox3.Controls.Add(this.MinimumSpeedBox);
      this.groupBox3.Controls.Add(this.label8);
      this.groupBox3.Controls.Add(this.label9);
      this.groupBox3.Location = new System.Drawing.Point(12, 320);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(386, 117);
      this.groupBox3.TabIndex = 8;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Explosion properties";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(199, 87);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(67, 13);
      this.label7.TabIndex = 10;
      this.label7.Text = "Initial Radius";
      // 
      // InitialRadiusBox
      // 
      this.InitialRadiusBox.Location = new System.Drawing.Point(285, 84);
      this.InitialRadiusBox.Name = "InitialRadiusBox";
      this.InitialRadiusBox.Size = new System.Drawing.Size(100, 20);
      this.InitialRadiusBox.TabIndex = 9;
      this.InitialRadiusBox.Text = "1.0";
      // 
      // DetailLevelTrackBar
      // 
      this.DetailLevelTrackBar.AllowOutOfBounds = true;
      this.DetailLevelTrackBar.ForceInteger = true;
      this.DetailLevelTrackBar.FourthPower = false;
      this.DetailLevelTrackBar.Location = new System.Drawing.Point(6, 19);
      this.DetailLevelTrackBar.Maximum = 9D;
      this.DetailLevelTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.DetailLevelTrackBar.Minimum = 0D;
      this.DetailLevelTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.DetailLevelTrackBar.Name = "DetailLevelTrackBar";
      this.DetailLevelTrackBar.Quadratic = false;
      this.DetailLevelTrackBar.Size = new System.Drawing.Size(290, 25);
      this.DetailLevelTrackBar.TabIndex = 8;
      this.DetailLevelTrackBar.Title = "Detail Level";
      this.DetailLevelTrackBar.Value = 2D;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(199, 61);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(34, 13);
      this.label10.TabIndex = 7;
      this.label10.Text = "Steps";
      // 
      // StepsBox
      // 
      this.StepsBox.Location = new System.Drawing.Point(285, 58);
      this.StepsBox.Name = "StepsBox";
      this.StepsBox.Size = new System.Drawing.Size(100, 20);
      this.StepsBox.TabIndex = 6;
      this.StepsBox.Text = "4";
      // 
      // SpeedStepBox
      // 
      this.SpeedStepBox.Location = new System.Drawing.Point(93, 84);
      this.SpeedStepBox.Name = "SpeedStepBox";
      this.SpeedStepBox.Size = new System.Drawing.Size(100, 20);
      this.SpeedStepBox.TabIndex = 5;
      this.SpeedStepBox.Text = "1.0";
      // 
      // MinimumSpeedBox
      // 
      this.MinimumSpeedBox.Location = new System.Drawing.Point(93, 58);
      this.MinimumSpeedBox.Name = "MinimumSpeedBox";
      this.MinimumSpeedBox.Size = new System.Drawing.Size(100, 20);
      this.MinimumSpeedBox.TabIndex = 4;
      this.MinimumSpeedBox.Text = "1.0";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(7, 61);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(80, 13);
      this.label8.TabIndex = 1;
      this.label8.Text = "Minimum speed";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(7, 87);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(61, 13);
      this.label9.TabIndex = 2;
      this.label9.Text = "Speed step";
      // 
      // OKButton
      // 
      this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.OKButton.Location = new System.Drawing.Point(236, 443);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 9;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // Cancel_Button
      // 
      this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Cancel_Button.Location = new System.Drawing.Point(323, 443);
      this.Cancel_Button.Name = "Cancel_Button";
      this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
      this.Cancel_Button.TabIndex = 10;
      this.Cancel_Button.Text = "Cancel";
      this.Cancel_Button.UseVisualStyleBackColor = true;
      // 
      // MeteoriteInitializationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(405, 471);
      this.Controls.Add(this.Cancel_Button);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "MeteoriteInitializationForm";
      this.Text = "Intialize Meteor Shower";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox PositionZBox;
    private System.Windows.Forms.TextBox PositionYBox;
    private System.Windows.Forms.TextBox PositionXBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox VelocityZBox;
    private System.Windows.Forms.TextBox VelocityYBox;
    private System.Windows.Forms.TextBox VelocityXBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox StepsBox;
    private System.Windows.Forms.TextBox SpeedStepBox;
    private System.Windows.Forms.TextBox MinimumSpeedBox;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button Cancel_Button;
    private TextBoxTrackBar DetailLevelTrackBar;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox InitialRadiusBox;
    private TextBoxTrackBar DistanceBox;
    private System.Windows.Forms.ComboBox DistanceToBox;
    private System.Windows.Forms.Label label11;
    private TextBoxTrackBar PositionRightAssensionTrackBar;
    private TextBoxTrackBar PositionDeclinationTrackBar;
    private TextBoxTrackBar VelocityDeclinationTrackBar;
    private TextBoxTrackBar VelocityRightAscensionTrackBar;
    private TextBoxTrackBar SpeedTrackBar;
  }
}