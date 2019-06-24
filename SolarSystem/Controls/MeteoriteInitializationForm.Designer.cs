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
      this.PositionZBox = new System.Windows.Forms.TextBox();
      this.PositionYBox = new System.Windows.Forms.TextBox();
      this.PositionXBox = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.VelocityZBox = new System.Windows.Forms.TextBox();
      this.VelocityYBox = new System.Windows.Forms.TextBox();
      this.VelocityXBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.ExplosionTypeTabControl = new System.Windows.Forms.TabControl();
      this.SphericalTab = new System.Windows.Forms.TabPage();
      this.label7 = new System.Windows.Forms.Label();
      this.InitialRadiusBox = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.MinimumSpeedBox = new System.Windows.Forms.TextBox();
      this.StepsBox = new System.Windows.Forms.TextBox();
      this.SpeedStepBox = new System.Windows.Forms.TextBox();
      this.SheetTab = new System.Windows.Forms.TabPage();
      this.SpacingBox = new System.Windows.Forms.TextBox();
      this.ArrayLengthBox = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.AddButton = new System.Windows.Forms.Button();
      this.DetailLevelTrackBar = new SolarSystem.TextBoxTrackBar();
      this.SheetDeclinationTrackbar = new SolarSystem.TextBoxTrackBar();
      this.SheetRightAscensionTrackBar = new SolarSystem.TextBoxTrackBar();
      this.VelocityDeclinationTrackBar = new SolarSystem.TextBoxTrackBar();
      this.VelocityRightAscensionTrackBar = new SolarSystem.TextBoxTrackBar();
      this.SpeedTrackBar = new SolarSystem.TextBoxTrackBar();
      this.PositionDeclinationTrackBar = new SolarSystem.TextBoxTrackBar();
      this.PositionRightAscensionTrackBar = new SolarSystem.TextBoxTrackBar();
      this.DistanceTrackBar = new SolarSystem.TextBoxTrackBar();
      this.label14 = new System.Windows.Forms.Label();
      this.VelocityRelativeToBox = new System.Windows.Forms.ComboBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.ExplosionTypeTabControl.SuspendLayout();
      this.SphericalTab.SuspendLayout();
      this.SheetTab.SuspendLayout();
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
      this.groupBox1.Controls.Add(this.PositionRightAscensionTrackBar);
      this.groupBox1.Controls.Add(this.PositionYBox);
      this.groupBox1.Controls.Add(this.PositionXBox);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.DistanceTrackBar);
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
      this.DistanceToBox.SelectedIndexChanged += new System.EventHandler(this.DistanceToBox_SelectedIndexChanged);
      // 
      // PositionZBox
      // 
      this.PositionZBox.Location = new System.Drawing.Point(278, 13);
      this.PositionZBox.Name = "PositionZBox";
      this.PositionZBox.Size = new System.Drawing.Size(100, 20);
      this.PositionZBox.TabIndex = 5;
      this.PositionZBox.Text = "0";
      this.PositionZBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PositionBox_KeyDown);
      this.PositionZBox.Leave += new System.EventHandler(this.PositionBox_Leave);
      // 
      // PositionYBox
      // 
      this.PositionYBox.Location = new System.Drawing.Point(152, 13);
      this.PositionYBox.Name = "PositionYBox";
      this.PositionYBox.Size = new System.Drawing.Size(100, 20);
      this.PositionYBox.TabIndex = 4;
      this.PositionYBox.Text = "0";
      this.PositionYBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PositionBox_KeyDown);
      this.PositionYBox.Leave += new System.EventHandler(this.PositionBox_Leave);
      // 
      // PositionXBox
      // 
      this.PositionXBox.Location = new System.Drawing.Point(26, 13);
      this.PositionXBox.Name = "PositionXBox";
      this.PositionXBox.Size = new System.Drawing.Size(100, 20);
      this.PositionXBox.TabIndex = 3;
      this.PositionXBox.Text = "149600000";
      this.PositionXBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PositionBox_KeyDown);
      this.PositionXBox.Leave += new System.EventHandler(this.PositionBox_Leave);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label14);
      this.groupBox2.Controls.Add(this.VelocityRelativeToBox);
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
      this.groupBox2.Size = new System.Drawing.Size(386, 162);
      this.groupBox2.TabIndex = 7;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Velocity";
      // 
      // VelocityZBox
      // 
      this.VelocityZBox.Location = new System.Drawing.Point(278, 13);
      this.VelocityZBox.Name = "VelocityZBox";
      this.VelocityZBox.Size = new System.Drawing.Size(100, 20);
      this.VelocityZBox.TabIndex = 5;
      this.VelocityZBox.Text = "0.0";
      this.VelocityZBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VelocityBox_KeyDown);
      this.VelocityZBox.Leave += new System.EventHandler(this.VelocityBox_Leave);
      // 
      // VelocityYBox
      // 
      this.VelocityYBox.Location = new System.Drawing.Point(152, 13);
      this.VelocityYBox.Name = "VelocityYBox";
      this.VelocityYBox.Size = new System.Drawing.Size(100, 20);
      this.VelocityYBox.TabIndex = 4;
      this.VelocityYBox.Text = "30.0";
      this.VelocityYBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VelocityBox_KeyDown);
      this.VelocityYBox.Leave += new System.EventHandler(this.VelocityBox_Leave);
      // 
      // VelocityXBox
      // 
      this.VelocityXBox.Location = new System.Drawing.Point(26, 13);
      this.VelocityXBox.Name = "VelocityXBox";
      this.VelocityXBox.Size = new System.Drawing.Size(100, 20);
      this.VelocityXBox.TabIndex = 3;
      this.VelocityXBox.Text = "0.0";
      this.VelocityXBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VelocityBox_KeyDown);
      this.VelocityXBox.Leave += new System.EventHandler(this.VelocityBox_Leave);
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
      this.groupBox3.Controls.Add(this.ExplosionTypeTabControl);
      this.groupBox3.Location = new System.Drawing.Point(12, 349);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(386, 153);
      this.groupBox3.TabIndex = 8;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Meteor Shower properties";
      // 
      // ExplosionTypeTabControl
      // 
      this.ExplosionTypeTabControl.Controls.Add(this.SphericalTab);
      this.ExplosionTypeTabControl.Controls.Add(this.SheetTab);
      this.ExplosionTypeTabControl.Location = new System.Drawing.Point(9, 20);
      this.ExplosionTypeTabControl.Name = "ExplosionTypeTabControl";
      this.ExplosionTypeTabControl.SelectedIndex = 0;
      this.ExplosionTypeTabControl.Size = new System.Drawing.Size(373, 124);
      this.ExplosionTypeTabControl.TabIndex = 10;
      this.ExplosionTypeTabControl.SelectedIndexChanged += new System.EventHandler(this.ExplosionTypeTabControl_SelectedIndexChanged);
      // 
      // SphericalTab
      // 
      this.SphericalTab.Controls.Add(this.label7);
      this.SphericalTab.Controls.Add(this.DetailLevelTrackBar);
      this.SphericalTab.Controls.Add(this.InitialRadiusBox);
      this.SphericalTab.Controls.Add(this.label9);
      this.SphericalTab.Controls.Add(this.label8);
      this.SphericalTab.Controls.Add(this.label10);
      this.SphericalTab.Controls.Add(this.MinimumSpeedBox);
      this.SphericalTab.Controls.Add(this.StepsBox);
      this.SphericalTab.Controls.Add(this.SpeedStepBox);
      this.SphericalTab.Location = new System.Drawing.Point(4, 22);
      this.SphericalTab.Name = "SphericalTab";
      this.SphericalTab.Padding = new System.Windows.Forms.Padding(3);
      this.SphericalTab.Size = new System.Drawing.Size(365, 98);
      this.SphericalTab.TabIndex = 0;
      this.SphericalTab.Text = "Spherical";
      this.SphericalTab.UseVisualStyleBackColor = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(199, 67);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(67, 13);
      this.label7.TabIndex = 10;
      this.label7.Text = "Initial Radius";
      // 
      // InitialRadiusBox
      // 
      this.InitialRadiusBox.Location = new System.Drawing.Point(268, 64);
      this.InitialRadiusBox.Name = "InitialRadiusBox";
      this.InitialRadiusBox.Size = new System.Drawing.Size(95, 20);
      this.InitialRadiusBox.TabIndex = 9;
      this.InitialRadiusBox.Text = "1.0";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(7, 67);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(61, 13);
      this.label9.TabIndex = 2;
      this.label9.Text = "Speed step";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(7, 41);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(80, 13);
      this.label8.TabIndex = 1;
      this.label8.Text = "Minimum speed";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(199, 41);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(34, 13);
      this.label10.TabIndex = 7;
      this.label10.Text = "Steps";
      // 
      // MinimumSpeedBox
      // 
      this.MinimumSpeedBox.Location = new System.Drawing.Point(93, 38);
      this.MinimumSpeedBox.Name = "MinimumSpeedBox";
      this.MinimumSpeedBox.Size = new System.Drawing.Size(100, 20);
      this.MinimumSpeedBox.TabIndex = 4;
      this.MinimumSpeedBox.Text = "1.0";
      // 
      // StepsBox
      // 
      this.StepsBox.Location = new System.Drawing.Point(268, 38);
      this.StepsBox.Name = "StepsBox";
      this.StepsBox.Size = new System.Drawing.Size(95, 20);
      this.StepsBox.TabIndex = 6;
      this.StepsBox.Text = "4";
      // 
      // SpeedStepBox
      // 
      this.SpeedStepBox.Location = new System.Drawing.Point(93, 64);
      this.SpeedStepBox.Name = "SpeedStepBox";
      this.SpeedStepBox.Size = new System.Drawing.Size(100, 20);
      this.SpeedStepBox.TabIndex = 5;
      this.SpeedStepBox.Text = "1.0";
      // 
      // SheetTab
      // 
      this.SheetTab.Controls.Add(this.SheetDeclinationTrackbar);
      this.SheetTab.Controls.Add(this.SpacingBox);
      this.SheetTab.Controls.Add(this.ArrayLengthBox);
      this.SheetTab.Controls.Add(this.label13);
      this.SheetTab.Controls.Add(this.label12);
      this.SheetTab.Controls.Add(this.SheetRightAscensionTrackBar);
      this.SheetTab.Location = new System.Drawing.Point(4, 22);
      this.SheetTab.Name = "SheetTab";
      this.SheetTab.Padding = new System.Windows.Forms.Padding(3);
      this.SheetTab.Size = new System.Drawing.Size(365, 98);
      this.SheetTab.TabIndex = 1;
      this.SheetTab.Text = "Sheet";
      this.SheetTab.UseVisualStyleBackColor = true;
      // 
      // SpacingBox
      // 
      this.SpacingBox.Location = new System.Drawing.Point(262, 10);
      this.SpacingBox.Name = "SpacingBox";
      this.SpacingBox.Size = new System.Drawing.Size(100, 20);
      this.SpacingBox.TabIndex = 6;
      this.SpacingBox.Text = "200";
      this.SpacingBox.TextChanged += new System.EventHandler(this.SheetChanged);
      this.SpacingBox.Leave += new System.EventHandler(this.SpacingBox_Leave);
      // 
      // ArrayLengthBox
      // 
      this.ArrayLengthBox.Location = new System.Drawing.Point(82, 10);
      this.ArrayLengthBox.Name = "ArrayLengthBox";
      this.ArrayLengthBox.Size = new System.Drawing.Size(100, 20);
      this.ArrayLengthBox.TabIndex = 5;
      this.ArrayLengthBox.Text = "100";
      this.ArrayLengthBox.TextChanged += new System.EventHandler(this.SheetChanged);
      this.ArrayLengthBox.Leave += new System.EventHandler(this.ArrayLengthBox_Leave);
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(188, 13);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(49, 13);
      this.label13.TabIndex = 1;
      this.label13.Text = "Spacing:";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(6, 13);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(70, 13);
      this.label12.TabIndex = 0;
      this.label12.Text = "Array Length:";
      // 
      // AddButton
      // 
      this.AddButton.Location = new System.Drawing.Point(323, 508);
      this.AddButton.Name = "AddButton";
      this.AddButton.Size = new System.Drawing.Size(75, 23);
      this.AddButton.TabIndex = 9;
      this.AddButton.Text = "Add";
      this.AddButton.UseVisualStyleBackColor = true;
      this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // DetailLevelTrackBar
      // 
      this.DetailLevelTrackBar.AllowOutOfBounds = true;
      this.DetailLevelTrackBar.ForceInteger = true;
      this.DetailLevelTrackBar.FourthPower = false;
      this.DetailLevelTrackBar.Location = new System.Drawing.Point(6, 7);
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
      // SheetDeclinationTrackbar
      // 
      this.SheetDeclinationTrackbar.AllowOutOfBounds = true;
      this.SheetDeclinationTrackbar.ForceInteger = false;
      this.SheetDeclinationTrackbar.FourthPower = false;
      this.SheetDeclinationTrackbar.Location = new System.Drawing.Point(3, 67);
      this.SheetDeclinationTrackbar.Maximum = 90D;
      this.SheetDeclinationTrackbar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.SheetDeclinationTrackbar.Minimum = -90D;
      this.SheetDeclinationTrackbar.MinimumSize = new System.Drawing.Size(0, 25);
      this.SheetDeclinationTrackbar.Name = "SheetDeclinationTrackbar";
      this.SheetDeclinationTrackbar.Quadratic = false;
      this.SheetDeclinationTrackbar.Size = new System.Drawing.Size(356, 25);
      this.SheetDeclinationTrackbar.TabIndex = 20;
      this.SheetDeclinationTrackbar.Title = "Declination";
      this.SheetDeclinationTrackbar.Value = 0D;
      this.SheetDeclinationTrackbar.ValueChanged += new System.EventHandler(this.SheetChanged);
      // 
      // SheetRightAscensionTrackBar
      // 
      this.SheetRightAscensionTrackBar.AllowOutOfBounds = true;
      this.SheetRightAscensionTrackBar.ForceInteger = false;
      this.SheetRightAscensionTrackBar.FourthPower = false;
      this.SheetRightAscensionTrackBar.Location = new System.Drawing.Point(3, 36);
      this.SheetRightAscensionTrackBar.Maximum = 360D;
      this.SheetRightAscensionTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.SheetRightAscensionTrackBar.Minimum = 0D;
      this.SheetRightAscensionTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.SheetRightAscensionTrackBar.Name = "SheetRightAscensionTrackBar";
      this.SheetRightAscensionTrackBar.Quadratic = false;
      this.SheetRightAscensionTrackBar.Size = new System.Drawing.Size(356, 25);
      this.SheetRightAscensionTrackBar.TabIndex = 19;
      this.SheetRightAscensionTrackBar.Title = "Right Ascension";
      this.SheetRightAscensionTrackBar.Value = 0D;
      this.SheetRightAscensionTrackBar.ValueChanged += new System.EventHandler(this.SheetChanged);
      // 
      // VelocityDeclinationTrackBar
      // 
      this.VelocityDeclinationTrackBar.AllowOutOfBounds = true;
      this.VelocityDeclinationTrackBar.ForceInteger = false;
      this.VelocityDeclinationTrackBar.FourthPower = false;
      this.VelocityDeclinationTrackBar.Location = new System.Drawing.Point(3, 128);
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
      // VelocityRightAscensionTrackBar
      // 
      this.VelocityRightAscensionTrackBar.AllowOutOfBounds = true;
      this.VelocityRightAscensionTrackBar.ForceInteger = false;
      this.VelocityRightAscensionTrackBar.FourthPower = false;
      this.VelocityRightAscensionTrackBar.Location = new System.Drawing.Point(3, 97);
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
      // SpeedTrackBar
      // 
      this.SpeedTrackBar.AllowOutOfBounds = true;
      this.SpeedTrackBar.ForceInteger = false;
      this.SpeedTrackBar.FourthPower = false;
      this.SpeedTrackBar.Location = new System.Drawing.Point(3, 66);
      this.SpeedTrackBar.Maximum = 300D;
      this.SpeedTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.SpeedTrackBar.Minimum = 0D;
      this.SpeedTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.SpeedTrackBar.Name = "SpeedTrackBar";
      this.SpeedTrackBar.Quadratic = false;
      this.SpeedTrackBar.Size = new System.Drawing.Size(375, 25);
      this.SpeedTrackBar.TabIndex = 16;
      this.SpeedTrackBar.Title = "Speed (km/s)";
      this.SpeedTrackBar.Value = 2D;
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
      // PositionRightAscensionTrackBar
      // 
      this.PositionRightAscensionTrackBar.AllowOutOfBounds = true;
      this.PositionRightAscensionTrackBar.ForceInteger = false;
      this.PositionRightAscensionTrackBar.FourthPower = false;
      this.PositionRightAscensionTrackBar.Location = new System.Drawing.Point(3, 97);
      this.PositionRightAscensionTrackBar.Maximum = 360D;
      this.PositionRightAscensionTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.PositionRightAscensionTrackBar.Minimum = 0D;
      this.PositionRightAscensionTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.PositionRightAscensionTrackBar.Name = "PositionRightAscensionTrackBar";
      this.PositionRightAscensionTrackBar.Quadratic = false;
      this.PositionRightAscensionTrackBar.Size = new System.Drawing.Size(375, 25);
      this.PositionRightAscensionTrackBar.TabIndex = 14;
      this.PositionRightAscensionTrackBar.Title = "Right Ascension";
      this.PositionRightAscensionTrackBar.Value = 0D;
      // 
      // DistanceTrackBar
      // 
      this.DistanceTrackBar.AllowOutOfBounds = true;
      this.DistanceTrackBar.ForceInteger = false;
      this.DistanceTrackBar.FourthPower = true;
      this.DistanceTrackBar.Location = new System.Drawing.Point(3, 66);
      this.DistanceTrackBar.Maximum = 300000000D;
      this.DistanceTrackBar.MaximumSize = new System.Drawing.Size(10000, 25);
      this.DistanceTrackBar.Minimum = 0D;
      this.DistanceTrackBar.MinimumSize = new System.Drawing.Size(0, 25);
      this.DistanceTrackBar.Name = "DistanceTrackBar";
      this.DistanceTrackBar.Quadratic = false;
      this.DistanceTrackBar.Size = new System.Drawing.Size(375, 25);
      this.DistanceTrackBar.TabIndex = 11;
      this.DistanceTrackBar.Title = "Distance (km)";
      this.DistanceTrackBar.Value = 10000000D;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(6, 42);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(61, 13);
      this.label14.TabIndex = 17;
      this.label14.Text = "Relative to:";
      // 
      // VelocityRelativeToBox
      // 
      this.VelocityRelativeToBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.VelocityRelativeToBox.FormattingEnabled = true;
      this.VelocityRelativeToBox.Location = new System.Drawing.Point(90, 39);
      this.VelocityRelativeToBox.Name = "VelocityRelativeToBox";
      this.VelocityRelativeToBox.Size = new System.Drawing.Size(100, 21);
      this.VelocityRelativeToBox.TabIndex = 16;
      // 
      // MeteoriteInitializationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(405, 536);
      this.Controls.Add(this.AddButton);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "MeteoriteInitializationForm";
      this.Text = "Intialize Meteor Shower";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MeteoriteInitializationForm_FormClosed);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.ExplosionTypeTabControl.ResumeLayout(false);
      this.SphericalTab.ResumeLayout(false);
      this.SphericalTab.PerformLayout();
      this.SheetTab.ResumeLayout(false);
      this.SheetTab.PerformLayout();
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
    private System.Windows.Forms.Button AddButton;
    private TextBoxTrackBar DetailLevelTrackBar;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox InitialRadiusBox;
    private TextBoxTrackBar DistanceTrackBar;
    private System.Windows.Forms.ComboBox DistanceToBox;
    private System.Windows.Forms.Label label11;
    private TextBoxTrackBar PositionRightAscensionTrackBar;
    private TextBoxTrackBar PositionDeclinationTrackBar;
    private TextBoxTrackBar VelocityDeclinationTrackBar;
    private TextBoxTrackBar VelocityRightAscensionTrackBar;
    private TextBoxTrackBar SpeedTrackBar;
    private System.Windows.Forms.TabControl ExplosionTypeTabControl;
    private System.Windows.Forms.TabPage SphericalTab;
    private System.Windows.Forms.TabPage SheetTab;
    private System.Windows.Forms.TextBox SpacingBox;
    private System.Windows.Forms.TextBox ArrayLengthBox;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label12;
    private TextBoxTrackBar SheetDeclinationTrackbar;
    private TextBoxTrackBar SheetRightAscensionTrackBar;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.ComboBox VelocityRelativeToBox;
  }
}