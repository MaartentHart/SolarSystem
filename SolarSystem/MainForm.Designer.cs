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
      this.TriangleTestButton = new System.Windows.Forms.Button();
      this.SampleFormTestButton = new System.Windows.Forms.Button();
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.TargetTestButton = new System.Windows.Forms.Button();
      this.ExxagerationBar = new System.Windows.Forms.TrackBar();
      this.ExxagerationTextBox = new System.Windows.Forms.TextBox();
      this.ExxagerationGroupBox = new System.Windows.Forms.GroupBox();
      this.SceneContentBox = new System.Windows.Forms.CheckedListBox();
      this.GlView = new SolarSystem.GlView();
      this.TestColorButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.ExxagerationBar)).BeginInit();
      this.ExxagerationGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // TriangleTestButton
      // 
      this.TriangleTestButton.Location = new System.Drawing.Point(287, 12);
      this.TriangleTestButton.Name = "TriangleTestButton";
      this.TriangleTestButton.Size = new System.Drawing.Size(75, 23);
      this.TriangleTestButton.TabIndex = 5;
      this.TriangleTestButton.Text = "Tetrahedron";
      this.TriangleTestButton.UseVisualStyleBackColor = true;
      this.TriangleTestButton.Click += new System.EventHandler(this.TetrahedronTestButton_Click);
      // 
      // SampleFormTestButton
      // 
      this.SampleFormTestButton.Location = new System.Drawing.Point(368, 12);
      this.SampleFormTestButton.Name = "SampleFormTestButton";
      this.SampleFormTestButton.Size = new System.Drawing.Size(75, 23);
      this.SampleFormTestButton.TabIndex = 6;
      this.SampleFormTestButton.Text = "Sample Form";
      this.SampleFormTestButton.UseVisualStyleBackColor = true;
      this.SampleFormTestButton.Click += new System.EventHandler(this.SampleFormTestButton_Click);
      // 
      // UpdateTimer
      // 
      this.UpdateTimer.Enabled = true;
      this.UpdateTimer.Interval = 1;
      this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
      // 
      // TargetTestButton
      // 
      this.TargetTestButton.Location = new System.Drawing.Point(449, 12);
      this.TargetTestButton.Name = "TargetTestButton";
      this.TargetTestButton.Size = new System.Drawing.Size(75, 23);
      this.TargetTestButton.TabIndex = 8;
      this.TargetTestButton.Text = "Target";
      this.TargetTestButton.UseVisualStyleBackColor = true;
      this.TargetTestButton.Click += new System.EventHandler(this.TargetTestButton_Click);
      // 
      // ExxagerationBar
      // 
      this.ExxagerationBar.Location = new System.Drawing.Point(6, 19);
      this.ExxagerationBar.Maximum = 10000;
      this.ExxagerationBar.Name = "ExxagerationBar";
      this.ExxagerationBar.Size = new System.Drawing.Size(118, 45);
      this.ExxagerationBar.TabIndex = 13;
      this.ExxagerationBar.TickFrequency = 1000;
      this.ExxagerationBar.Value = 1000;
      this.ExxagerationBar.Scroll += new System.EventHandler(this.ExxagerationBar_Scroll);
      this.ExxagerationBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ExxagerationBar_MouseUp);
      // 
      // ExxagerationTextBox
      // 
      this.ExxagerationTextBox.Location = new System.Drawing.Point(130, 19);
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
      this.ExxagerationGroupBox.Location = new System.Drawing.Point(12, 12);
      this.ExxagerationGroupBox.Name = "ExxagerationGroupBox";
      this.ExxagerationGroupBox.Size = new System.Drawing.Size(171, 45);
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
      this.SceneContentBox.Size = new System.Drawing.Size(120, 229);
      this.SceneContentBox.TabIndex = 16;
      this.SceneContentBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SceneContentBox_ItemCheck);
      // 
      // GlView
      // 
      this.GlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlView.Location = new System.Drawing.Point(138, 79);
      this.GlView.Name = "GlView";
      this.GlView.Size = new System.Drawing.Size(473, 231);
      this.GlView.TabIndex = 10;
      // 
      // TestColorButton
      // 
      this.TestColorButton.Location = new System.Drawing.Point(206, 12);
      this.TestColorButton.Name = "TestColorButton";
      this.TestColorButton.Size = new System.Drawing.Size(75, 23);
      this.TestColorButton.TabIndex = 17;
      this.TestColorButton.Text = "Color";
      this.TestColorButton.UseVisualStyleBackColor = true;
      this.TestColorButton.Click += new System.EventHandler(this.TestColorButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(623, 322);
      this.Controls.Add(this.TestColorButton);
      this.Controls.Add(this.SceneContentBox);
      this.Controls.Add(this.ExxagerationGroupBox);
      this.Controls.Add(this.GlView);
      this.Controls.Add(this.TargetTestButton);
      this.Controls.Add(this.SampleFormTestButton);
      this.Controls.Add(this.TriangleTestButton);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Solar System Simulator";
      ((System.ComponentModel.ISupportInitialize)(this.ExxagerationBar)).EndInit();
      this.ExxagerationGroupBox.ResumeLayout(false);
      this.ExxagerationGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button TriangleTestButton;
    private System.Windows.Forms.Button SampleFormTestButton;
    private System.Windows.Forms.Timer UpdateTimer;
    private System.Windows.Forms.Button TargetTestButton;
    private GlView GlView;
    private System.Windows.Forms.TrackBar ExxagerationBar;
    private System.Windows.Forms.TextBox ExxagerationTextBox;
    private System.Windows.Forms.GroupBox ExxagerationGroupBox;
    private System.Windows.Forms.CheckedListBox SceneContentBox;
    private System.Windows.Forms.Button TestColorButton;
  }
}

