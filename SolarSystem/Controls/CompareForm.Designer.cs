namespace SolarSystem.Controls
{
  partial class CompareForm
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
      SolarSystem.Camera camera1 = new SolarSystem.Camera();
      SolarSystem.Scene scene1 = new SolarSystem.Scene();
      SolarSystem.Camera camera2 = new SolarSystem.Camera();
      SolarSystem.Scene scene2 = new SolarSystem.Scene();
      this.Planet1Box = new System.Windows.Forms.ComboBox();
      this.Planet2Box = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.TabelLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.GlLeft = new SolarSystem.GlControlExtended();
      this.GlRight = new SolarSystem.GlControlExtended();
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.TabelLayoutPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // Planet1Box
      // 
      this.Planet1Box.FormattingEnabled = true;
      this.Planet1Box.Location = new System.Drawing.Point(67, 12);
      this.Planet1Box.Name = "Planet1Box";
      this.Planet1Box.Size = new System.Drawing.Size(121, 21);
      this.Planet1Box.TabIndex = 1;
      this.Planet1Box.SelectedIndexChanged += new System.EventHandler(this.Planet1Box_SelectedIndexChanged);
      // 
      // Planet2Box
      // 
      this.Planet2Box.FormattingEnabled = true;
      this.Planet2Box.Location = new System.Drawing.Point(249, 12);
      this.Planet2Box.Name = "Planet2Box";
      this.Planet2Box.Size = new System.Drawing.Size(121, 21);
      this.Planet2Box.TabIndex = 2;
      this.Planet2Box.SelectedIndexChanged += new System.EventHandler(this.Planet2Box_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Planet 1:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(194, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(49, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Planet 2:";
      // 
      // TabelLayoutPanel
      // 
      this.TabelLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TabelLayoutPanel.ColumnCount = 2;
      this.TabelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TabelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TabelLayoutPanel.Controls.Add(this.GlLeft, 0, 0);
      this.TabelLayoutPanel.Controls.Add(this.GlRight, 1, 0);
      this.TabelLayoutPanel.Location = new System.Drawing.Point(15, 39);
      this.TabelLayoutPanel.Name = "TabelLayoutPanel";
      this.TabelLayoutPanel.RowCount = 1;
      this.TabelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TabelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TabelLayoutPanel.Size = new System.Drawing.Size(1048, 500);
      this.TabelLayoutPanel.TabIndex = 6;
      // 
      // GlLeft
      // 
      this.GlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      camera1.Changed = true;
      camera1.FieldOfView = 25D;
      camera1.IgnoreObjectPositions = false;
      camera1.LockDistance = true;
      camera1.ViewDistance = 10D;
      camera1.ViewRadius = 10D;
      this.GlLeft.Camera = camera1;
      this.GlLeft.ColorBits = ((uint)(24u));
      this.GlLeft.DepthBits = ((uint)(24u));
      this.GlLeft.Location = new System.Drawing.Point(3, 3);
      this.GlLeft.MultisampleBits = ((uint)(0u));
      this.GlLeft.Name = "GlLeft";
      scene1.Changed = true;
      scene1.Exxageration = 0D;
      scene1.MaximumDisplayGeneration = 9;
      scene1.PointSize = 3F;
      scene1.SunLight = null;
      this.GlLeft.Scene = scene1;
      this.GlLeft.Size = new System.Drawing.Size(518, 494);
      this.GlLeft.StencilBits = ((uint)(0u));
      this.GlLeft.TabIndex = 0;
      // 
      // GlRight
      // 
      this.GlRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      camera2.Changed = true;
      camera2.FieldOfView = 25D;
      camera2.IgnoreObjectPositions = false;
      camera2.LockDistance = true;
      camera2.ViewDistance = 10D;
      camera2.ViewRadius = 10D;
      this.GlRight.Camera = camera2;
      this.GlRight.ColorBits = ((uint)(24u));
      this.GlRight.DepthBits = ((uint)(24u));
      this.GlRight.Location = new System.Drawing.Point(527, 3);
      this.GlRight.MultisampleBits = ((uint)(0u));
      this.GlRight.Name = "GlRight";
      scene2.Changed = true;
      scene2.Exxageration = 0D;
      scene2.MaximumDisplayGeneration = 9;
      scene2.PointSize = 3F;
      scene2.SunLight = null;
      this.GlRight.Scene = scene2;
      this.GlRight.Size = new System.Drawing.Size(518, 494);
      this.GlRight.StencilBits = ((uint)(0u));
      this.GlRight.TabIndex = 1;
      // 
      // UpdateTimer
      // 
      this.UpdateTimer.Enabled = true;
      this.UpdateTimer.Interval = 1;
      this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
      // 
      // CompareForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1075, 551);
      this.Controls.Add(this.TabelLayoutPanel);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.Planet2Box);
      this.Controls.Add(this.Planet1Box);
      this.Name = "CompareForm";
      this.Text = "Compare";
      this.TabelLayoutPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ComboBox Planet1Box;
    private System.Windows.Forms.ComboBox Planet2Box;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TableLayoutPanel TabelLayoutPanel;
    private GlControlExtended GlLeft;
    private GlControlExtended GlRight;
    private System.Windows.Forms.Timer UpdateTimer;
  }
}