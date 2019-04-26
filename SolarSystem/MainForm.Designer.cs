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
      this.AddMoonTestButton = new System.Windows.Forms.ToolStripButton();
      this.GlView = new SolarSystem.GlView();
      this.AddMarsTestButton = new System.Windows.Forms.ToolStripButton();
      this.AddSunTestButton = new System.Windows.Forms.ToolStripButton();
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
      this.SceneContentBox.Size = new System.Drawing.Size(142, 274);
      this.SceneContentBox.TabIndex = 16;
      this.SceneContentBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SceneContentBox_ItemCheck);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorMapButton,
            this.AddMoonTestButton,
            this.AddMarsTestButton,
            this.AddSunTestButton});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(623, 25);
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
      // GlView
      // 
      this.GlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlView.Location = new System.Drawing.Point(160, 28);
      this.GlView.Name = "GlView";
      this.GlView.Size = new System.Drawing.Size(451, 340);
      this.GlView.TabIndex = 10;
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
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(623, 380);
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
  }
}

