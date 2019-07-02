namespace SolarSystem.Controls
{
  partial class ImpactListForm
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
      this.ImpactGridView = new System.Windows.Forms.DataGridView();
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.AutoUpdateBox = new System.Windows.Forms.CheckBox();
      this.UpdateButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.ImpactGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // ImpactGridView
      // 
      this.ImpactGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ImpactGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ImpactGridView.Location = new System.Drawing.Point(12, 12);
      this.ImpactGridView.Name = "ImpactGridView";
      this.ImpactGridView.Size = new System.Drawing.Size(776, 455);
      this.ImpactGridView.TabIndex = 0;
      // 
      // UpdateTimer
      // 
      this.UpdateTimer.Interval = 1000;
      this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
      // 
      // AutoUpdateBox
      // 
      this.AutoUpdateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.AutoUpdateBox.AutoSize = true;
      this.AutoUpdateBox.Location = new System.Drawing.Point(12, 473);
      this.AutoUpdateBox.Name = "AutoUpdateBox";
      this.AutoUpdateBox.Size = new System.Drawing.Size(86, 17);
      this.AutoUpdateBox.TabIndex = 1;
      this.AutoUpdateBox.Text = "Auto Update";
      this.AutoUpdateBox.UseVisualStyleBackColor = true;
      this.AutoUpdateBox.CheckedChanged += new System.EventHandler(this.AutoUpdateBox_CheckedChanged);
      // 
      // UpdateButton
      // 
      this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.UpdateButton.Location = new System.Drawing.Point(713, 469);
      this.UpdateButton.Name = "UpdateButton";
      this.UpdateButton.Size = new System.Drawing.Size(75, 23);
      this.UpdateButton.TabIndex = 2;
      this.UpdateButton.Text = "Update";
      this.UpdateButton.UseVisualStyleBackColor = true;
      this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
      // 
      // ImpactListForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 502);
      this.Controls.Add(this.UpdateButton);
      this.Controls.Add(this.AutoUpdateBox);
      this.Controls.Add(this.ImpactGridView);
      this.Name = "ImpactListForm";
      this.Text = "Impact List";
      ((System.ComponentModel.ISupportInitialize)(this.ImpactGridView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView ImpactGridView;
    private System.Windows.Forms.Timer UpdateTimer;
    private System.Windows.Forms.CheckBox AutoUpdateBox;
    private System.Windows.Forms.Button UpdateButton;
  }
}