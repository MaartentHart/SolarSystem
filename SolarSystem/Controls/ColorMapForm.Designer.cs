namespace SolarSystem
{
  partial class ColorMapForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorMapForm));
      this.GridView = new System.Windows.Forms.DataGridView();
      this.StartColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EndColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.LoadButton = new System.Windows.Forms.ToolStripButton();
      this.SaveButton = new System.Windows.Forms.ToolStripButton();
      this.InsertRowButton = new System.Windows.Forms.ToolStripButton();
      this.CopyColorButton = new System.Windows.Forms.ToolStripButton();
      this.PasteColorButton = new System.Windows.Forms.ToolStripButton();
      this.CancelButton1 = new System.Windows.Forms.Button();
      this.OKButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // GridView
      // 
      this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartColumn,
            this.EndColumn});
      this.GridView.Location = new System.Drawing.Point(12, 31);
      this.GridView.Name = "GridView";
      this.GridView.Size = new System.Drawing.Size(243, 258);
      this.GridView.TabIndex = 0;
      this.GridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellDoubleClick);
      this.GridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellEndEdit);
      // 
      // StartColumn
      // 
      this.StartColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.StartColumn.HeaderText = "Start";
      this.StartColumn.Name = "StartColumn";
      this.StartColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // EndColumn
      // 
      this.EndColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.EndColumn.HeaderText = "End";
      this.EndColumn.Name = "EndColumn";
      this.EndColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadButton,
            this.SaveButton,
            this.InsertRowButton,
            this.CopyColorButton,
            this.PasteColorButton});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(268, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // LoadButton
      // 
      this.LoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.LoadButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadButton.Image")));
      this.LoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.LoadButton.Name = "LoadButton";
      this.LoadButton.Size = new System.Drawing.Size(23, 22);
      this.LoadButton.Text = "Load";
      this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
      // 
      // SaveButton
      // 
      this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
      this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.SaveButton.Name = "SaveButton";
      this.SaveButton.Size = new System.Drawing.Size(23, 22);
      this.SaveButton.Text = "Save";
      this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // InsertRowButton
      // 
      this.InsertRowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.InsertRowButton.Image = ((System.Drawing.Image)(resources.GetObject("InsertRowButton.Image")));
      this.InsertRowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.InsertRowButton.Name = "InsertRowButton";
      this.InsertRowButton.Size = new System.Drawing.Size(23, 22);
      this.InsertRowButton.Text = "Insert Row";
      this.InsertRowButton.Click += new System.EventHandler(this.InsertRowButton_Click);
      // 
      // CopyColorButton
      // 
      this.CopyColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.CopyColorButton.Image = ((System.Drawing.Image)(resources.GetObject("CopyColorButton.Image")));
      this.CopyColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.CopyColorButton.Name = "CopyColorButton";
      this.CopyColorButton.Size = new System.Drawing.Size(23, 22);
      this.CopyColorButton.Text = "Copy Color";
      this.CopyColorButton.Click += new System.EventHandler(this.CopyColorButton_Click);
      // 
      // PasteColorButton
      // 
      this.PasteColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.PasteColorButton.Image = ((System.Drawing.Image)(resources.GetObject("PasteColorButton.Image")));
      this.PasteColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.PasteColorButton.Name = "PasteColorButton";
      this.PasteColorButton.Size = new System.Drawing.Size(23, 22);
      this.PasteColorButton.Text = "Paste Color";
      this.PasteColorButton.Click += new System.EventHandler(this.PasteColorButton_Click);
      // 
      // CancelButton1
      // 
      this.CancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CancelButton1.Location = new System.Drawing.Point(180, 295);
      this.CancelButton1.Name = "CancelButton1";
      this.CancelButton1.Size = new System.Drawing.Size(75, 23);
      this.CancelButton1.TabIndex = 2;
      this.CancelButton1.Text = "Cancel";
      this.CancelButton1.UseVisualStyleBackColor = true;
      // 
      // OKButton
      // 
      this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.OKButton.Location = new System.Drawing.Point(99, 295);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 3;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      // 
      // ColorMapForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(268, 330);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.CancelButton1);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.GridView);
      this.Name = "ColorMapForm";
      this.Text = "ColorMapForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorMapForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ColorMapForm_FormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView GridView;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton LoadButton;
    private System.Windows.Forms.ToolStripButton SaveButton;
    private System.Windows.Forms.DataGridViewTextBoxColumn StartColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn EndColumn;
    private System.Windows.Forms.ToolStripButton InsertRowButton;
    private System.Windows.Forms.ToolStripButton CopyColorButton;
    private System.Windows.Forms.ToolStripButton PasteColorButton;
    private System.Windows.Forms.Button CancelButton1;
    private System.Windows.Forms.Button OKButton;
  }
}