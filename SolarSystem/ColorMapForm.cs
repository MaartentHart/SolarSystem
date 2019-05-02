//Copyright Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  public partial class ColorMapForm : Form
  {
    private ColorDialog colorDialog = new ColorDialog();
    private Color copyColor = Color.Black;
    
    public ColorMap ColorMap { get; set; }

    public ColorMapForm()
    {
      InitializeComponent();
      SetColorMap(new ColorMap());
    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\Resource";
        ofd.Filter = "*.cmap|*.cmap";
        if (ofd.ShowDialog()!=DialogResult.OK)
          return;

        ColorMap colorMap = new ColorMap(ofd.FileName, true);
        SetColorMap(colorMap);
      }
    }

    private void SetColorMap(ColorMap colorMap)
    {
      GridView.Rows.Clear();
      GridView.Rows.Add("", "");
      foreach (ColorMapBand band in colorMap.Bands)
        GridView.Rows.Add(band.StartValue.ToString(), "");
      
      GridView.Rows.Add(colorMap.EndValue.ToString(), "");
      for (int i=0; i<GridView.Rows.Count-1;i++)
        GridView.Rows[i].Cells[1].Value = GridView.Rows[i + 1].Cells[0].Value;

      for (int i = 0; i < colorMap.Bands.Count; i++)
      {
        PaintCell(i + 1, 0, colorMap.Bands[i].StartColor);
        PaintCell(i + 1, 1, colorMap.Bands[i].EndColor);
      }
      PaintCell(0, 0, colorMap.StartColor);
      PaintCell(0, 1, colorMap.StartColor);
      PaintCell(colorMap.Bands.Count+1, 0, colorMap.EndColor);
      PaintCell(colorMap.Bands.Count+1, 1, colorMap.EndColor);

      ColorMap = colorMap; 
    }

    private void PaintCell(int rowIndex, int columnIndex, ColorFloat color)
    {
      try
      {
        GridView.Rows[rowIndex].Cells[columnIndex].Style.BackColor = color.Color;
        if (color.Average < 0.5)
          GridView.Rows[rowIndex].Cells[columnIndex].Style.ForeColor = Color.White;
        else
          GridView.Rows[rowIndex].Cells[columnIndex].Style.ForeColor = Color.Black;
      }
      catch
      {

      }
    }

    private void GridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == 0 && e.ColumnIndex == 0)
        GridView.Rows[0].Cells[0].Value = "";
      else if (e.ColumnIndex == 1 && e.RowIndex == GridView.RowCount - 1)
        GridView.Rows[e.RowIndex].Cells[1].Value = "";
      else if (e.ColumnIndex == 0)
        GridView.Rows[e.RowIndex - 1].Cells[1].Value = GridView.Rows[e.RowIndex].Cells[0].Value;
      else
        GridView.Rows[e.RowIndex + 1].Cells[0].Value = GridView.Rows[e.RowIndex].Cells[1].Value; 
    }

    private void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == 0 && e.RowIndex == 0)
        return;
      if (e.RowIndex >= GridView.RowCount - 1 && e.ColumnIndex == 1)
        return;


      if (colorDialog.ShowDialog() != DialogResult.OK)
        return;
      PaintCell(e.RowIndex, e.ColumnIndex, new ColorFloat(colorDialog.Color));

    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
      try
      {
        ColorMap colorMap = new ColorMap
        {
          StartColor = new ColorFloat(GridView.Rows[0].Cells[1].Style.BackColor),
          EndColor = new ColorFloat(GridView.Rows[GridView.RowCount - 2].Cells[0].Style.BackColor),
          EndValue = Convert.ToDouble(GridView.Rows[GridView.RowCount - 2].Cells[0].Value)
        };

        for (int i = 1; i < GridView.RowCount - 2; i++)
        {
          colorMap.Bands.Add(new ColorMapBand(
            new ColorFloat(GridView.Rows[i].Cells[0].Style.BackColor),
            new ColorFloat(GridView.Rows[i].Cells[1].Style.BackColor),
            Convert.ToDouble(GridView.Rows[i].Cells[0].Value)
            ));
        }

        using (SaveFileDialog sfd = new SaveFileDialog())
        {
          sfd.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\Resource";
          sfd.Filter = "*.cmap|*.cmap";
          if (sfd.ShowDialog() != DialogResult.OK)
            return;
          colorMap.Save(sfd.FileName); 
        }
      }
      catch
      {
        MessageBox.Show("Failed to save color map.", "Error");
      }
    }

    private void InsertRowButton_Click(object sender, EventArgs e)
    {
      int index = GridView.CurrentCell.RowIndex;
      string currentValue = GridView.Rows[index].Cells[0].Value.ToString();
      GridView.Rows.Insert(GridView.CurrentCell.RowIndex, currentValue,currentValue); 
    }

    private void CopyColorButton_Click(object sender, EventArgs e)
    {
      copyColor = GridView.CurrentCell.Style.BackColor; 
    }

    private void ColorMapForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      colorDialog.Dispose(); 
    }

    private void PasteColorButton_Click(object sender, EventArgs e)
    {
      try
      {
        PaintCell(GridView.CurrentCell.RowIndex, GridView.CurrentCell.ColumnIndex, new ColorFloat(copyColor));
      }
      catch
      {

      }
    }

  }
}
