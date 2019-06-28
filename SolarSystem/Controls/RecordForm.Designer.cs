namespace SolarSystem.Controls
{
  partial class RecordForm
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
      this.FolderBox = new System.Windows.Forms.TextBox();
      this.BrowseFolderButton = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.HeightBox = new System.Windows.Forms.TextBox();
      this.WidthBox = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.AddTimeStampBox = new System.Windows.Forms.CheckBox();
      this.RecordButton = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.TimeStepBox = new System.Windows.Forms.TextBox();
      this.CancelButton2 = new System.Windows.Forms.Button();
      this.TimeStepTypeBox = new System.Windows.Forms.ComboBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Output Folder:";
      // 
      // FolderBox
      // 
      this.FolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.FolderBox.Location = new System.Drawing.Point(92, 6);
      this.FolderBox.Name = "FolderBox";
      this.FolderBox.Size = new System.Drawing.Size(199, 20);
      this.FolderBox.TabIndex = 1;
      this.FolderBox.Text = "D:\\Record\\";
      // 
      // BrowseFolderButton
      // 
      this.BrowseFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BrowseFolderButton.Location = new System.Drawing.Point(297, 4);
      this.BrowseFolderButton.Name = "BrowseFolderButton";
      this.BrowseFolderButton.Size = new System.Drawing.Size(75, 23);
      this.BrowseFolderButton.TabIndex = 2;
      this.BrowseFolderButton.Text = "Browse";
      this.BrowseFolderButton.UseVisualStyleBackColor = true;
      this.BrowseFolderButton.Click += new System.EventHandler(this.BrowseFolderButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.HeightBox);
      this.groupBox1.Controls.Add(this.WidthBox);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Location = new System.Drawing.Point(12, 32);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(358, 47);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Resolution";
      // 
      // HeightBox
      // 
      this.HeightBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.HeightBox.Location = new System.Drawing.Point(228, 17);
      this.HeightBox.Name = "HeightBox";
      this.HeightBox.Size = new System.Drawing.Size(124, 20);
      this.HeightBox.TabIndex = 3;
      this.HeightBox.Text = "1080";
      // 
      // WidthBox
      // 
      this.WidthBox.Location = new System.Drawing.Point(51, 17);
      this.WidthBox.Name = "WidthBox";
      this.WidthBox.Size = new System.Drawing.Size(124, 20);
      this.WidthBox.TabIndex = 2;
      this.WidthBox.Text = "1920";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(181, 20);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Height:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 20);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(38, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Width:";
      // 
      // AddTimeStampBox
      // 
      this.AddTimeStampBox.AutoSize = true;
      this.AddTimeStampBox.Checked = true;
      this.AddTimeStampBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.AddTimeStampBox.Location = new System.Drawing.Point(12, 111);
      this.AddTimeStampBox.Name = "AddTimeStampBox";
      this.AddTimeStampBox.Size = new System.Drawing.Size(104, 17);
      this.AddTimeStampBox.TabIndex = 5;
      this.AddTimeStampBox.Text = "Add Time Stamp";
      this.AddTimeStampBox.UseVisualStyleBackColor = true;
      // 
      // RecordButton
      // 
      this.RecordButton.Location = new System.Drawing.Point(297, 112);
      this.RecordButton.Name = "RecordButton";
      this.RecordButton.Size = new System.Drawing.Size(75, 23);
      this.RecordButton.TabIndex = 6;
      this.RecordButton.Text = "Record";
      this.RecordButton.UseVisualStyleBackColor = true;
      this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(10, 88);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(58, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Time Step:";
      // 
      // TimeStepBox
      // 
      this.TimeStepBox.Location = new System.Drawing.Point(74, 85);
      this.TimeStepBox.Name = "TimeStepBox";
      this.TimeStepBox.Size = new System.Drawing.Size(100, 20);
      this.TimeStepBox.TabIndex = 7;
      this.TimeStepBox.Text = "1";
      // 
      // CancelButton2
      // 
      this.CancelButton2.Location = new System.Drawing.Point(216, 112);
      this.CancelButton2.Name = "CancelButton2";
      this.CancelButton2.Size = new System.Drawing.Size(75, 23);
      this.CancelButton2.TabIndex = 8;
      this.CancelButton2.Text = "Cancel";
      this.CancelButton2.UseVisualStyleBackColor = true;
      this.CancelButton2.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // TimeStepTypeBox
      // 
      this.TimeStepTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.TimeStepTypeBox.FormattingEnabled = true;
      this.TimeStepTypeBox.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours",
            "Days"});
      this.TimeStepTypeBox.Location = new System.Drawing.Point(180, 85);
      this.TimeStepTypeBox.Name = "TimeStepTypeBox";
      this.TimeStepTypeBox.Size = new System.Drawing.Size(121, 21);
      this.TimeStepTypeBox.TabIndex = 9;
      // 
      // RecordForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(384, 143);
      this.Controls.Add(this.TimeStepTypeBox);
      this.Controls.Add(this.CancelButton2);
      this.Controls.Add(this.TimeStepBox);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.RecordButton);
      this.Controls.Add(this.AddTimeStampBox);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.BrowseFolderButton);
      this.Controls.Add(this.FolderBox);
      this.Controls.Add(this.label1);
      this.Name = "RecordForm";
      this.Text = "Record Settings";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox FolderBox;
    private System.Windows.Forms.Button BrowseFolderButton;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox HeightBox;
    private System.Windows.Forms.TextBox WidthBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox AddTimeStampBox;
    private System.Windows.Forms.Button RecordButton;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox TimeStepBox;
    private System.Windows.Forms.Button CancelButton2;
    private System.Windows.Forms.ComboBox TimeStepTypeBox;
  }
}