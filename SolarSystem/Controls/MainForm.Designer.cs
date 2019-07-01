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
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.ExxagerationBar = new System.Windows.Forms.TrackBar();
      this.ExxagerationTextBox = new System.Windows.Forms.TextBox();
      this.ExxagerationGroupBox = new System.Windows.Forms.GroupBox();
      this.SceneContentBox = new System.Windows.Forms.CheckedListBox();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
      this.LoadTextureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.InitializeMeteorShowerButton = new System.Windows.Forms.ToolStripButton();
      this.DeleteMeteorShowerButton = new System.Windows.Forms.ToolStripButton();
      this.ColorMapButton = new System.Windows.Forms.ToolStripButton();
      this.PropertiesBoxButton = new System.Windows.Forms.ToolStripButton();
      this.InitializePlanetsButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.TimeLockButton = new System.Windows.Forms.ToolStripButton();
      this.DayBox = new System.Windows.Forms.ToolStripTextBox();
      this.MonthDropDown = new System.Windows.Forms.ToolStripDropDownButton();
      this.januaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.februaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.marchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aprilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.juneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.julyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.augustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.septemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.octoberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.novemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.decemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.YearBox = new System.Windows.Forms.ToolStripTextBox();
      this.ADBCDropDown = new System.Windows.Forms.ToolStripDropDownButton();
      this.aDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.bCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.TimeBox = new System.Windows.Forms.ToolStripTextBox();
      this.PlayPauseButton = new System.Windows.Forms.ToolStripButton();
      this.TimeStepButton = new System.Windows.Forms.ToolStripButton();
      this.RecordButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.TimeStepBox = new System.Windows.Forms.ToolStripTextBox();
      this.TimeStepUnitButton = new System.Windows.Forms.ToolStripDropDownButton();
      this.SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.MinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.HoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.DaysToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      this.MaxRenderRatioBox = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
      this.QualityBox = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
      this.CalibrationBox = new System.Windows.Forms.ToolStripTextBox();
      this.DebugSaveImageButton = new System.Windows.Forms.ToolStripButton();
      this.TestSaveFrame = new System.Windows.Forms.ToolStripButton();
      this.GlView = new SolarSystem.GlView();
      ((System.ComponentModel.ISupportInitialize)(this.ExxagerationBar)).BeginInit();
      this.ExxagerationGroupBox.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // UpdateTimer
      // 
      this.UpdateTimer.Enabled = true;
      this.UpdateTimer.Interval = 1;
      this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
      // 
      // ExxagerationBar
      // 
      this.ExxagerationBar.Location = new System.Drawing.Point(6, 19);
      this.ExxagerationBar.Maximum = 10000;
      this.ExxagerationBar.Name = "ExxagerationBar";
      this.ExxagerationBar.Size = new System.Drawing.Size(84, 45);
      this.ExxagerationBar.TabIndex = 13;
      this.ExxagerationBar.TickFrequency = 1000;
      this.ExxagerationBar.Value = 1000;
      this.ExxagerationBar.Scroll += new System.EventHandler(this.ExxagerationBar_Scroll);
      // 
      // ExxagerationTextBox
      // 
      this.ExxagerationTextBox.Location = new System.Drawing.Point(96, 19);
      this.ExxagerationTextBox.Name = "ExxagerationTextBox";
      this.ExxagerationTextBox.Size = new System.Drawing.Size(32, 20);
      this.ExxagerationTextBox.TabIndex = 14;
      this.ExxagerationTextBox.Text = "1";
      this.ExxagerationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExxagerationTextBox_KeyDown);
      this.ExxagerationTextBox.Leave += new System.EventHandler(this.ExxagerationTextBox_Apply);
      // 
      // ExxagerationGroupBox
      // 
      this.ExxagerationGroupBox.Controls.Add(this.ExxagerationBar);
      this.ExxagerationGroupBox.Controls.Add(this.ExxagerationTextBox);
      this.ExxagerationGroupBox.Location = new System.Drawing.Point(12, 28);
      this.ExxagerationGroupBox.Name = "ExxagerationGroupBox";
      this.ExxagerationGroupBox.Size = new System.Drawing.Size(142, 45);
      this.ExxagerationGroupBox.TabIndex = 15;
      this.ExxagerationGroupBox.TabStop = false;
      this.ExxagerationGroupBox.Text = "Exxageration";
      // 
      // SceneContentBox
      // 
      this.SceneContentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.SceneContentBox.FormattingEnabled = true;
      this.SceneContentBox.Location = new System.Drawing.Point(12, 79);
      this.SceneContentBox.Name = "SceneContentBox";
      this.SceneContentBox.Size = new System.Drawing.Size(142, 349);
      this.SceneContentBox.TabIndex = 16;
      this.SceneContentBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SceneContentBox_ItemCheck);
      this.SceneContentBox.SelectedIndexChanged += new System.EventHandler(this.SceneContentBox_SelectedIndexChanged);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.InitializeMeteorShowerButton,
            this.DeleteMeteorShowerButton,
            this.ColorMapButton,
            this.PropertiesBoxButton,
            this.InitializePlanetsButton,
            this.toolStripSeparator1,
            this.TimeLockButton,
            this.DayBox,
            this.MonthDropDown,
            this.YearBox,
            this.ADBCDropDown,
            this.TimeBox,
            this.PlayPauseButton,
            this.TimeStepButton,
            this.RecordButton,
            this.toolStripLabel1,
            this.TimeStepBox,
            this.TimeStepUnitButton,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.MaxRenderRatioBox,
            this.toolStripLabel3,
            this.QualityBox,
            this.toolStripSeparator3,
            this.toolStripLabel4,
            this.CalibrationBox,
            this.DebugSaveImageButton,
            this.TestSaveFrame});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(1177, 25);
      this.toolStrip1.TabIndex = 19;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // toolStripDropDownButton1
      // 
      this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadTextureMenuItem,
            this.saveTextureToolStripMenuItem,
            this.clearCacheToolStripMenuItem});
      this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
      this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
      this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
      this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
      // 
      // LoadTextureMenuItem
      // 
      this.LoadTextureMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LoadTextureMenuItem.Image")));
      this.LoadTextureMenuItem.Name = "LoadTextureMenuItem";
      this.LoadTextureMenuItem.Size = new System.Drawing.Size(141, 22);
      this.LoadTextureMenuItem.Text = "Load Texture";
      this.LoadTextureMenuItem.Click += new System.EventHandler(this.LoadTextureMenuItem_Click);
      // 
      // saveTextureToolStripMenuItem
      // 
      this.saveTextureToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveTextureToolStripMenuItem.Image")));
      this.saveTextureToolStripMenuItem.Name = "saveTextureToolStripMenuItem";
      this.saveTextureToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
      this.saveTextureToolStripMenuItem.Text = "Save Texture";
      this.saveTextureToolStripMenuItem.Click += new System.EventHandler(this.SaveTextureToolStripMenuItem_Click);
      // 
      // clearCacheToolStripMenuItem
      // 
      this.clearCacheToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearCacheToolStripMenuItem.Image")));
      this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
      this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
      this.clearCacheToolStripMenuItem.Text = "Clear Cache";
      this.clearCacheToolStripMenuItem.Click += new System.EventHandler(this.ClearCacheToolStripMenuItem_Click);
      // 
      // InitializeMeteorShowerButton
      // 
      this.InitializeMeteorShowerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.InitializeMeteorShowerButton.Image = ((System.Drawing.Image)(resources.GetObject("InitializeMeteorShowerButton.Image")));
      this.InitializeMeteorShowerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.InitializeMeteorShowerButton.Name = "InitializeMeteorShowerButton";
      this.InitializeMeteorShowerButton.Size = new System.Drawing.Size(23, 22);
      this.InitializeMeteorShowerButton.Text = "Initialize Meteor Shower";
      this.InitializeMeteorShowerButton.Click += new System.EventHandler(this.InitializeMeteorShowerButton_Click);
      // 
      // DeleteMeteorShowerButton
      // 
      this.DeleteMeteorShowerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.DeleteMeteorShowerButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteMeteorShowerButton.Image")));
      this.DeleteMeteorShowerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.DeleteMeteorShowerButton.Name = "DeleteMeteorShowerButton";
      this.DeleteMeteorShowerButton.Size = new System.Drawing.Size(23, 22);
      this.DeleteMeteorShowerButton.Text = "Delete Meteor Showers";
      this.DeleteMeteorShowerButton.Click += new System.EventHandler(this.DeleteMeteorShowerButton_Click);
      // 
      // ColorMapButton
      // 
      this.ColorMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ColorMapButton.Image = ((System.Drawing.Image)(resources.GetObject("ColorMapButton.Image")));
      this.ColorMapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ColorMapButton.Name = "ColorMapButton";
      this.ColorMapButton.Size = new System.Drawing.Size(23, 22);
      this.ColorMapButton.Text = "Color Map";
      this.ColorMapButton.Click += new System.EventHandler(this.ColorMapEditorButton_Click);
      // 
      // PropertiesBoxButton
      // 
      this.PropertiesBoxButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.PropertiesBoxButton.Image = ((System.Drawing.Image)(resources.GetObject("PropertiesBoxButton.Image")));
      this.PropertiesBoxButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.PropertiesBoxButton.Name = "PropertiesBoxButton";
      this.PropertiesBoxButton.Size = new System.Drawing.Size(23, 22);
      this.PropertiesBoxButton.Text = "Properties";
      this.PropertiesBoxButton.Click += new System.EventHandler(this.PropertiesBoxButton_Click);
      // 
      // InitializePlanetsButton
      // 
      this.InitializePlanetsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.InitializePlanetsButton.Image = ((System.Drawing.Image)(resources.GetObject("InitializePlanetsButton.Image")));
      this.InitializePlanetsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.InitializePlanetsButton.Name = "InitializePlanetsButton";
      this.InitializePlanetsButton.Size = new System.Drawing.Size(23, 22);
      this.InitializePlanetsButton.Text = "Initialize Planets";
      this.InitializePlanetsButton.Visible = false;
      this.InitializePlanetsButton.Click += new System.EventHandler(this.InitializePlanets_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // TimeLockButton
      // 
      this.TimeLockButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.TimeLockButton.Image = global::SolarSystem.Properties.Resources.TimeIcon;
      this.TimeLockButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.TimeLockButton.Name = "TimeLockButton";
      this.TimeLockButton.Size = new System.Drawing.Size(23, 22);
      this.TimeLockButton.Text = "TimeLockButton";
      this.TimeLockButton.Click += new System.EventHandler(this.TimeLockButton_Click);
      // 
      // DayBox
      // 
      this.DayBox.Name = "DayBox";
      this.DayBox.Size = new System.Drawing.Size(20, 25);
      this.DayBox.Text = "01";
      this.DayBox.Leave += new System.EventHandler(this.DateTimeBox_Leave);
      this.DayBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DayBox_KeyDown);
      // 
      // MonthDropDown
      // 
      this.MonthDropDown.AutoSize = false;
      this.MonthDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.MonthDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.januaryToolStripMenuItem,
            this.februaryToolStripMenuItem,
            this.marchToolStripMenuItem,
            this.aprilToolStripMenuItem,
            this.mayToolStripMenuItem,
            this.juneToolStripMenuItem,
            this.julyToolStripMenuItem,
            this.augustToolStripMenuItem,
            this.septemberToolStripMenuItem,
            this.octoberToolStripMenuItem,
            this.novemberToolStripMenuItem,
            this.decemberToolStripMenuItem});
      this.MonthDropDown.Image = ((System.Drawing.Image)(resources.GetObject("MonthDropDown.Image")));
      this.MonthDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.MonthDropDown.Name = "MonthDropDown";
      this.MonthDropDown.Size = new System.Drawing.Size(80, 22);
      this.MonthDropDown.Text = "January";
      // 
      // januaryToolStripMenuItem
      // 
      this.januaryToolStripMenuItem.Name = "januaryToolStripMenuItem";
      this.januaryToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.januaryToolStripMenuItem.Text = "January";
      this.januaryToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // februaryToolStripMenuItem
      // 
      this.februaryToolStripMenuItem.Name = "februaryToolStripMenuItem";
      this.februaryToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.februaryToolStripMenuItem.Text = "February";
      this.februaryToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // marchToolStripMenuItem
      // 
      this.marchToolStripMenuItem.Name = "marchToolStripMenuItem";
      this.marchToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.marchToolStripMenuItem.Text = "March";
      this.marchToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // aprilToolStripMenuItem
      // 
      this.aprilToolStripMenuItem.Name = "aprilToolStripMenuItem";
      this.aprilToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.aprilToolStripMenuItem.Text = "April";
      this.aprilToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // mayToolStripMenuItem
      // 
      this.mayToolStripMenuItem.Name = "mayToolStripMenuItem";
      this.mayToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.mayToolStripMenuItem.Text = "May";
      this.mayToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // juneToolStripMenuItem
      // 
      this.juneToolStripMenuItem.Name = "juneToolStripMenuItem";
      this.juneToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.juneToolStripMenuItem.Text = "June";
      this.juneToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // julyToolStripMenuItem
      // 
      this.julyToolStripMenuItem.Name = "julyToolStripMenuItem";
      this.julyToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.julyToolStripMenuItem.Text = "July";
      this.julyToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // augustToolStripMenuItem
      // 
      this.augustToolStripMenuItem.Name = "augustToolStripMenuItem";
      this.augustToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.augustToolStripMenuItem.Text = "August";
      this.augustToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // septemberToolStripMenuItem
      // 
      this.septemberToolStripMenuItem.Name = "septemberToolStripMenuItem";
      this.septemberToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.septemberToolStripMenuItem.Text = "September";
      this.septemberToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // octoberToolStripMenuItem
      // 
      this.octoberToolStripMenuItem.Name = "octoberToolStripMenuItem";
      this.octoberToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.octoberToolStripMenuItem.Text = "October";
      this.octoberToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // novemberToolStripMenuItem
      // 
      this.novemberToolStripMenuItem.Name = "novemberToolStripMenuItem";
      this.novemberToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.novemberToolStripMenuItem.Text = "November";
      this.novemberToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // decemberToolStripMenuItem
      // 
      this.decemberToolStripMenuItem.Name = "decemberToolStripMenuItem";
      this.decemberToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
      this.decemberToolStripMenuItem.Text = "December";
      this.decemberToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // YearBox
      // 
      this.YearBox.Name = "YearBox";
      this.YearBox.Size = new System.Drawing.Size(40, 25);
      this.YearBox.Text = "2000";
      this.YearBox.Leave += new System.EventHandler(this.DateTimeBox_Leave);
      this.YearBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DayBox_KeyDown);
      // 
      // ADBCDropDown
      // 
      this.ADBCDropDown.AutoSize = false;
      this.ADBCDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ADBCDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDToolStripMenuItem,
            this.bCToolStripMenuItem});
      this.ADBCDropDown.Image = ((System.Drawing.Image)(resources.GetObject("ADBCDropDown.Image")));
      this.ADBCDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ADBCDropDown.Name = "ADBCDropDown";
      this.ADBCDropDown.Size = new System.Drawing.Size(36, 22);
      this.ADBCDropDown.Text = "AD";
      // 
      // aDToolStripMenuItem
      // 
      this.aDToolStripMenuItem.Name = "aDToolStripMenuItem";
      this.aDToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
      this.aDToolStripMenuItem.Text = "AD";
      this.aDToolStripMenuItem.Click += new System.EventHandler(this.ADBCToolStripMenuItem_Click);
      // 
      // bCToolStripMenuItem
      // 
      this.bCToolStripMenuItem.Name = "bCToolStripMenuItem";
      this.bCToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
      this.bCToolStripMenuItem.Text = "BC";
      this.bCToolStripMenuItem.Click += new System.EventHandler(this.ADBCToolStripMenuItem_Click);
      // 
      // TimeBox
      // 
      this.TimeBox.Name = "TimeBox";
      this.TimeBox.Size = new System.Drawing.Size(70, 25);
      this.TimeBox.Text = "12:00:00.000";
      this.TimeBox.Leave += new System.EventHandler(this.DateTimeBox_Leave);
      this.TimeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DayBox_KeyDown);
      // 
      // PlayPauseButton
      // 
      this.PlayPauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.PlayPauseButton.Image = global::SolarSystem.Properties.Resources.Play;
      this.PlayPauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.PlayPauseButton.Name = "PlayPauseButton";
      this.PlayPauseButton.Size = new System.Drawing.Size(23, 22);
      this.PlayPauseButton.Text = "Play/Pause";
      this.PlayPauseButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
      // 
      // TimeStepButton
      // 
      this.TimeStepButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.TimeStepButton.Image = ((System.Drawing.Image)(resources.GetObject("TimeStepButton.Image")));
      this.TimeStepButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.TimeStepButton.Name = "TimeStepButton";
      this.TimeStepButton.Size = new System.Drawing.Size(23, 22);
      this.TimeStepButton.Text = "Add Single Time Step";
      this.TimeStepButton.Click += new System.EventHandler(this.TimeStepButton_Click);
      // 
      // RecordButton
      // 
      this.RecordButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.RecordButton.Image = ((System.Drawing.Image)(resources.GetObject("RecordButton.Image")));
      this.RecordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.RecordButton.Name = "RecordButton";
      this.RecordButton.Size = new System.Drawing.Size(23, 22);
      this.RecordButton.Text = "Record";
      this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(62, 22);
      this.toolStripLabel1.Text = "Time step:";
      // 
      // TimeStepBox
      // 
      this.TimeStepBox.Name = "TimeStepBox";
      this.TimeStepBox.Size = new System.Drawing.Size(50, 25);
      this.TimeStepBox.Text = "1";
      this.TimeStepBox.Leave += new System.EventHandler(this.TimeStepBox_Leave);
      this.TimeStepBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimeStepBox_KeyDown);
      // 
      // TimeStepUnitButton
      // 
      this.TimeStepUnitButton.AutoSize = false;
      this.TimeStepUnitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.TimeStepUnitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SecondsToolStripMenuItem,
            this.MinutesToolStripMenuItem,
            this.HoursToolStripMenuItem,
            this.DaysToolStripMenuItem1});
      this.TimeStepUnitButton.Image = ((System.Drawing.Image)(resources.GetObject("TimeStepUnitButton.Image")));
      this.TimeStepUnitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.TimeStepUnitButton.Name = "TimeStepUnitButton";
      this.TimeStepUnitButton.Size = new System.Drawing.Size(64, 22);
      this.TimeStepUnitButton.Text = "Seconds";
      // 
      // SecondsToolStripMenuItem
      // 
      this.SecondsToolStripMenuItem.Name = "SecondsToolStripMenuItem";
      this.SecondsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
      this.SecondsToolStripMenuItem.Text = "Seconds";
      this.SecondsToolStripMenuItem.Click += new System.EventHandler(this.SetStepUnit);
      // 
      // MinutesToolStripMenuItem
      // 
      this.MinutesToolStripMenuItem.Name = "MinutesToolStripMenuItem";
      this.MinutesToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
      this.MinutesToolStripMenuItem.Text = "Minutes";
      this.MinutesToolStripMenuItem.Click += new System.EventHandler(this.SetStepUnit);
      // 
      // HoursToolStripMenuItem
      // 
      this.HoursToolStripMenuItem.Name = "HoursToolStripMenuItem";
      this.HoursToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
      this.HoursToolStripMenuItem.Text = "Hours";
      this.HoursToolStripMenuItem.Click += new System.EventHandler(this.SetStepUnit);
      // 
      // DaysToolStripMenuItem1
      // 
      this.DaysToolStripMenuItem1.Name = "DaysToolStripMenuItem1";
      this.DaysToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
      this.DaysToolStripMenuItem1.Text = "Days";
      this.DaysToolStripMenuItem1.Click += new System.EventHandler(this.SetStepUnit);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripLabel2
      // 
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new System.Drawing.Size(102, 22);
      this.toolStripLabel2.Text = "Max Render Ratio:";
      // 
      // MaxRenderRatioBox
      // 
      this.MaxRenderRatioBox.Name = "MaxRenderRatioBox";
      this.MaxRenderRatioBox.Size = new System.Drawing.Size(40, 25);
      this.MaxRenderRatioBox.Text = "1000";
      this.MaxRenderRatioBox.Click += new System.EventHandler(this.MaxRenderRatioBox_Click);
      // 
      // toolStripLabel3
      // 
      this.toolStripLabel3.Name = "toolStripLabel3";
      this.toolStripLabel3.Size = new System.Drawing.Size(48, 22);
      this.toolStripLabel3.Text = "Quality:";
      // 
      // QualityBox
      // 
      this.QualityBox.Name = "QualityBox";
      this.QualityBox.Size = new System.Drawing.Size(15, 25);
      this.QualityBox.Text = "9";
      this.QualityBox.ToolTipText = "Quality";
      this.QualityBox.Leave += new System.EventHandler(this.QualityBox_Leave);
      this.QualityBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QualityBox_KeyDown);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripLabel4
      // 
      this.toolStripLabel4.Name = "toolStripLabel4";
      this.toolStripLabel4.Size = new System.Drawing.Size(68, 22);
      this.toolStripLabel4.Text = "Calibration:";
      // 
      // CalibrationBox
      // 
      this.CalibrationBox.Name = "CalibrationBox";
      this.CalibrationBox.Size = new System.Drawing.Size(100, 25);
      this.CalibrationBox.TextChanged += new System.EventHandler(this.CalibrationBox_TextChanged);
      // 
      // DebugSaveImageButton
      // 
      this.DebugSaveImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.DebugSaveImageButton.Image = ((System.Drawing.Image)(resources.GetObject("DebugSaveImageButton.Image")));
      this.DebugSaveImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.DebugSaveImageButton.Name = "DebugSaveImageButton";
      this.DebugSaveImageButton.Size = new System.Drawing.Size(23, 22);
      this.DebugSaveImageButton.Text = "DebugSaveImage";
      this.DebugSaveImageButton.Click += new System.EventHandler(this.DebugSaveImageButton_Click);
      // 
      // TestSaveFrame
      // 
      this.TestSaveFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.TestSaveFrame.Image = ((System.Drawing.Image)(resources.GetObject("TestSaveFrame.Image")));
      this.TestSaveFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.TestSaveFrame.Name = "TestSaveFrame";
      this.TestSaveFrame.Size = new System.Drawing.Size(23, 22);
      this.TestSaveFrame.Text = "TestSaveFrame";
      this.TestSaveFrame.Click += new System.EventHandler(this.TestSaveFrame_Click);
      // 
      // GlView
      // 
      this.GlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlView.Location = new System.Drawing.Point(160, 28);
      this.GlView.Name = "GlView";
      this.GlView.Size = new System.Drawing.Size(1005, 414);
      this.GlView.TabIndex = 10;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1177, 454);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.SceneContentBox);
      this.Controls.Add(this.ExxagerationGroupBox);
      this.Controls.Add(this.GlView);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Solar System Simulator";
      ((System.ComponentModel.ISupportInitialize)(this.ExxagerationBar)).EndInit();
      this.ExxagerationGroupBox.ResumeLayout(false);
      this.ExxagerationGroupBox.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Timer UpdateTimer;
    private GlView GlView;
    private System.Windows.Forms.TrackBar ExxagerationBar;
    private System.Windows.Forms.TextBox ExxagerationTextBox;
    private System.Windows.Forms.GroupBox ExxagerationGroupBox;
    private System.Windows.Forms.CheckedListBox SceneContentBox;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton ColorMapButton;
    private System.Windows.Forms.ToolStripButton PropertiesBoxButton;
    private System.Windows.Forms.ToolStripTextBox DayBox;
    private System.Windows.Forms.ToolStripDropDownButton MonthDropDown;
    private System.Windows.Forms.ToolStripMenuItem januaryToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem februaryToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem marchToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aprilToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mayToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem juneToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem julyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem augustToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem septemberToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem octoberToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem novemberToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem decemberToolStripMenuItem;
    private System.Windows.Forms.ToolStripTextBox YearBox;
    private System.Windows.Forms.ToolStripDropDownButton ADBCDropDown;
    private System.Windows.Forms.ToolStripMenuItem aDToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem bCToolStripMenuItem;
    private System.Windows.Forms.ToolStripTextBox TimeBox;
    private System.Windows.Forms.ToolStripButton TimeLockButton;
    private System.Windows.Forms.ToolStripButton PlayPauseButton;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripTextBox TimeStepBox;
    private System.Windows.Forms.ToolStripDropDownButton TimeStepUnitButton;
    private System.Windows.Forms.ToolStripMenuItem SecondsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem MinutesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem HoursToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem DaysToolStripMenuItem1;
    private System.Windows.Forms.ToolStripButton InitializePlanetsButton;
    private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    private System.Windows.Forms.ToolStripTextBox MaxRenderRatioBox;
    private System.Windows.Forms.ToolStripButton TimeStepButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripLabel toolStripLabel3;
    private System.Windows.Forms.ToolStripTextBox QualityBox;
    private System.Windows.Forms.ToolStripButton InitializeMeteorShowerButton;
    private System.Windows.Forms.ToolStripLabel toolStripLabel4;
    private System.Windows.Forms.ToolStripTextBox CalibrationBox;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton DeleteMeteorShowerButton;
    private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
    private System.Windows.Forms.ToolStripMenuItem LoadTextureMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveTextureToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem clearCacheToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton RecordButton;
    private System.Windows.Forms.ToolStripButton DebugSaveImageButton;
    private System.Windows.Forms.ToolStripButton TestSaveFrame;
  }
}

