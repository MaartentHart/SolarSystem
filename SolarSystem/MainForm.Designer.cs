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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.TestButton = new System.Windows.Forms.Button();
      this.OpenGLPanel = new System.Windows.Forms.Panel();
      this.TestEarthButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // TestButton
      // 
      this.TestButton.Location = new System.Drawing.Point(12, 12);
      this.TestButton.Name = "TestButton";
      this.TestButton.Size = new System.Drawing.Size(75, 23);
      this.TestButton.TabIndex = 0;
      this.TestButton.Text = "Test";
      this.TestButton.UseVisualStyleBackColor = true;
      this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
      // 
      // OpenGLPanel
      // 
      this.OpenGLPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.OpenGLPanel.Location = new System.Drawing.Point(12, 41);
      this.OpenGLPanel.Name = "OpenGLPanel";
      this.OpenGLPanel.Size = new System.Drawing.Size(479, 296);
      this.OpenGLPanel.TabIndex = 2;
      // 
      // TestEarthButton
      // 
      this.TestEarthButton.Location = new System.Drawing.Point(93, 12);
      this.TestEarthButton.Name = "TestEarthButton";
      this.TestEarthButton.Size = new System.Drawing.Size(75, 23);
      this.TestEarthButton.TabIndex = 3;
      this.TestEarthButton.Text = "Earth";
      this.TestEarthButton.UseVisualStyleBackColor = true;
      this.TestEarthButton.Click += new System.EventHandler(this.TestEarthButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(503, 349);
      this.Controls.Add(this.TestEarthButton);
      this.Controls.Add(this.OpenGLPanel);
      this.Controls.Add(this.TestButton);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Solar System Simulator";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button TestButton;
    private System.Windows.Forms.Panel OpenGLPanel;
    private System.Windows.Forms.Button TestEarthButton;
  }
}

