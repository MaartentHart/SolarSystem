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
      this.ColorMapButton = new System.Windows.Forms.ToolStripButton();
      this.PropertiesBoxButton = new System.Windows.Forms.ToolStripButton();
      this.AddMoonTestButton = new System.Windows.Forms.ToolStripButton();
      this.AddMarsTestButton = new System.Windows.Forms.ToolStripButton();
      this.AddSunTestButton = new System.Windows.Forms.ToolStripButton();
      this.TestImageButton = new System.Windows.Forms.ToolStripButton();
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
      this.TimeLockButton = new System.Windows.Forms.ToolStripButton();
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
      this.ExxagerationBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ExxagerationBar_MouseUp);
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
            this.ColorMapButton,
            this.PropertiesBoxButton,
            this.TimeLockButton,
            this.DayBox,
            this.MonthDropDown,
            this.YearBox,
            this.ADBCDropDown,
            this.TimeBox,
            this.AddMarsTestButton,
            this.AddSunTestButton,
            this.AddMoonTestButton,
            this.TestImageButton});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(624, 25);
      this.toolStrip1.TabIndex = 19;
      this.toolStrip1.Text = "toolStrip1";
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
      // AddMoonTestButton
      // 
      this.AddMoonTestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.AddMoonTestButton.Image = ((System.Drawing.Image)(resources.GetObject("AddMoonTestButton.Image")));
      this.AddMoonTestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.AddMoonTestButton.Name = "AddMoonTestButton";
      this.AddMoonTestButton.Size = new System.Drawing.Size(23, 22);
      this.AddMoonTestButton.Text = "Add Moon Test";
      this.AddMoonTestButton.Click += new System.EventHandler(this.AddMoonTestButton_Click);
      // 
      // AddMarsTestButton
      // 
      this.AddMarsTestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.AddMarsTestButton.Image = ((System.Drawing.Image)(resources.GetObject("AddMarsTestButton.Image")));
      this.AddMarsTestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.AddMarsTestButton.Name = "AddMarsTestButton";
      this.AddMarsTestButton.Size = new System.Drawing.Size(23, 22);
      this.AddMarsTestButton.Text = "Add Mars Test";
      this.AddMarsTestButton.Click += new System.EventHandler(this.AddMarsTestButton_Click);
      // 
      // AddSunTestButton
      // 
      this.AddSunTestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.AddSunTestButton.Image = ((System.Drawing.Image)(resources.GetObject("AddSunTestButton.Image")));
      this.AddSunTestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.AddSunTestButton.Name = "AddSunTestButton";
      this.AddSunTestButton.Size = new System.Drawing.Size(23, 22);
      this.AddSunTestButton.Text = "Add Sun Test";
      this.AddSunTestButton.Click += new System.EventHandler(this.AddSunTestButton_Click);
      // 
      // TestImageButton
      // 
      this.TestImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.TestImageButton.Image = ((System.Drawing.Image)(resources.GetObject("TestImageButton.Image")));
      this.TestImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.TestImageButton.Name = "TestImageButton";
      this.TestImageButton.Size = new System.Drawing.Size(23, 22);
      this.TestImageButton.Text = "TestImage";
      this.TestImageButton.Click += new System.EventHandler(this.TestImageButton_Click);
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
      this.januaryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.januaryToolStripMenuItem.Text = "January";
      this.januaryToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // februaryToolStripMenuItem
      // 
      this.februaryToolStripMenuItem.Name = "februaryToolStripMenuItem";
      this.februaryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.februaryToolStripMenuItem.Text = "February";
      this.februaryToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // marchToolStripMenuItem
      // 
      this.marchToolStripMenuItem.Name = "marchToolStripMenuItem";
      this.marchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.marchToolStripMenuItem.Text = "March";
      this.marchToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // aprilToolStripMenuItem
      // 
      this.aprilToolStripMenuItem.Name = "aprilToolStripMenuItem";
      this.aprilToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.aprilToolStripMenuItem.Text = "April";
      this.aprilToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // mayToolStripMenuItem
      // 
      this.mayToolStripMenuItem.Name = "mayToolStripMenuItem";
      this.mayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.mayToolStripMenuItem.Text = "May";
      this.mayToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // juneToolStripMenuItem
      // 
      this.juneToolStripMenuItem.Name = "juneToolStripMenuItem";
      this.juneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.juneToolStripMenuItem.Text = "June";
      this.juneToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // julyToolStripMenuItem
      // 
      this.julyToolStripMenuItem.Name = "julyToolStripMenuItem";
      this.julyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.julyToolStripMenuItem.Text = "July";
      this.julyToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // augustToolStripMenuItem
      // 
      this.augustToolStripMenuItem.Name = "augustToolStripMenuItem";
      this.augustToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.augustToolStripMenuItem.Text = "August";
      this.augustToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // septemberToolStripMenuItem
      // 
      this.septemberToolStripMenuItem.Name = "septemberToolStripMenuItem";
      this.septemberToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.septemberToolStripMenuItem.Text = "September";
      this.septemberToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // octoberToolStripMenuItem
      // 
      this.octoberToolStripMenuItem.Name = "octoberToolStripMenuItem";
      this.octoberToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.octoberToolStripMenuItem.Text = "October";
      this.octoberToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // novemberToolStripMenuItem
      // 
      this.novemberToolStripMenuItem.Name = "novemberToolStripMenuItem";
      this.novemberToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.novemberToolStripMenuItem.Text = "November";
      this.novemberToolStripMenuItem.Click += new System.EventHandler(this.MonthStripMenuItem_Click);
      // 
      // decemberToolStripMenuItem
      // 
      this.decemberToolStripMenuItem.Name = "decemberToolStripMenuItem";
      this.decemberToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
      this.TimeBox.Text = "00:00:00.000";
      this.TimeBox.Leave += new System.EventHandler(this.DateTimeBox_Leave);
      this.TimeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DayBox_KeyDown);
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
      // GlView
      // 
      this.GlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlView.Location = new System.Drawing.Point(160, 28);
      this.GlView.Name = "GlView";
      this.GlView.Size = new System.Drawing.Size(452, 401);
      this.GlView.TabIndex = 10;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 441);
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
    private System.Windows.Forms.ToolStripButton AddMoonTestButton;
    private System.Windows.Forms.ToolStripButton AddMarsTestButton;
    private System.Windows.Forms.ToolStripButton AddSunTestButton;
    private System.Windows.Forms.ToolStripButton TestImageButton;
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
  }
}

