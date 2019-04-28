namespace SolarSystem
{
  partial class DateTesterForm
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
      this.YearBox = new System.Windows.Forms.TextBox();
      this.MonthBox = new System.Windows.Forms.TextBox();
      this.DayBox = new System.Windows.Forms.TextBox();
      this.TimeBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.ValueBox = new System.Windows.Forms.TextBox();
      this.DateStringBox = new System.Windows.Forms.TextBox();
      this.ToStringBox = new System.Windows.Forms.TextBox();
      this.ViaStringTestBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Date input:";
      // 
      // YearBox
      // 
      this.YearBox.Location = new System.Drawing.Point(139, 6);
      this.YearBox.Name = "YearBox";
      this.YearBox.Size = new System.Drawing.Size(50, 20);
      this.YearBox.TabIndex = 3;
      this.YearBox.Text = "2000";
      this.YearBox.TextChanged += new System.EventHandler(this.YearBox_TextChanged);
      // 
      // MonthBox
      // 
      this.MonthBox.Location = new System.Drawing.Point(108, 6);
      this.MonthBox.Name = "MonthBox";
      this.MonthBox.Size = new System.Drawing.Size(25, 20);
      this.MonthBox.TabIndex = 2;
      this.MonthBox.Text = "1";
      this.MonthBox.TextChanged += new System.EventHandler(this.MonthBox_TextChanged);
      // 
      // DayBox
      // 
      this.DayBox.Location = new System.Drawing.Point(77, 6);
      this.DayBox.Name = "DayBox";
      this.DayBox.Size = new System.Drawing.Size(25, 20);
      this.DayBox.TabIndex = 1;
      this.DayBox.Text = "1";
      this.DayBox.TextChanged += new System.EventHandler(this.DayBox_TextChanged);
      // 
      // TimeBox
      // 
      this.TimeBox.Location = new System.Drawing.Point(227, 6);
      this.TimeBox.Name = "TimeBox";
      this.TimeBox.Size = new System.Drawing.Size(113, 20);
      this.TimeBox.TabIndex = 7;
      this.TimeBox.Text = "00:00:00";
      this.TimeBox.TextChanged += new System.EventHandler(this.TimeBox_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(195, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(30, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Time";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(13, 87);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(34, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Value";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(13, 35);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(60, 13);
      this.label6.TabIndex = 9;
      this.label6.Text = "DateString:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(13, 61);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(47, 13);
      this.label7.TabIndex = 10;
      this.label7.Text = "ToString";
      // 
      // ValueBox
      // 
      this.ValueBox.Location = new System.Drawing.Point(79, 84);
      this.ValueBox.Name = "ValueBox";
      this.ValueBox.Size = new System.Drawing.Size(263, 20);
      this.ValueBox.TabIndex = 11;
      this.ValueBox.Leave += new System.EventHandler(this.ValueBox_Leave);
      // 
      // DateStringBox
      // 
      this.DateStringBox.Location = new System.Drawing.Point(79, 32);
      this.DateStringBox.Name = "DateStringBox";
      this.DateStringBox.Size = new System.Drawing.Size(263, 20);
      this.DateStringBox.TabIndex = 12;
      // 
      // ToStringBox
      // 
      this.ToStringBox.Location = new System.Drawing.Point(79, 58);
      this.ToStringBox.Name = "ToStringBox";
      this.ToStringBox.Size = new System.Drawing.Size(263, 20);
      this.ToStringBox.TabIndex = 13;
      // 
      // ViaStringTestBox
      // 
      this.ViaStringTestBox.Location = new System.Drawing.Point(79, 110);
      this.ViaStringTestBox.Name = "ViaStringTestBox";
      this.ViaStringTestBox.Size = new System.Drawing.Size(263, 20);
      this.ViaStringTestBox.TabIndex = 15;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 113);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 13);
      this.label2.TabIndex = 14;
      this.label2.Text = "By string val";
      // 
      // DateTesterForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(354, 137);
      this.Controls.Add(this.ViaStringTestBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.ToStringBox);
      this.Controls.Add(this.DateStringBox);
      this.Controls.Add(this.ValueBox);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.TimeBox);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.DayBox);
      this.Controls.Add(this.MonthBox);
      this.Controls.Add(this.YearBox);
      this.Controls.Add(this.label1);
      this.Name = "DateTesterForm";
      this.Text = "DateTesterForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox YearBox;
    private System.Windows.Forms.TextBox MonthBox;
    private System.Windows.Forms.TextBox DayBox;
    private System.Windows.Forms.TextBox TimeBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox ValueBox;
    private System.Windows.Forms.TextBox DateStringBox;
    private System.Windows.Forms.TextBox ToStringBox;
    private System.Windows.Forms.TextBox ViaStringTestBox;
    private System.Windows.Forms.Label label2;
  }
}