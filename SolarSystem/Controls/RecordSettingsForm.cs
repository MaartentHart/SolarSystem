using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem.Controls
{
  public partial class RecordSettingsForm : Form
  {
    public bool addTimeStamp; 
    public int height; 
    public int width; 
    public double timeStep;
    public string folderName; 

    public RecordSettingsForm()
    {
      InitializeComponent();
      TimeStepTypeBox.SelectedIndex = 1; 
    }

    private void BrowseFolderButton_Click(object sender, EventArgs e)
    {
      using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
      {
        folderBrowserDialog.SelectedPath = FolderBox.Text;
        if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
          return;
        FolderBox.Text = folderBrowserDialog.SelectedPath; 
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel; 
    }

    private void RecordButton_Click(object sender, EventArgs e)
    {
      try
      {
        addTimeStamp = AddTimeStampBox.Checked;
        width = Convert.ToInt32(WidthBox.Text);
        height = Convert.ToInt32(HeightBox.Text);
        timeStep = Convert.ToDouble(TimeStepBox.Text);
        if ((string)TimeStepTypeBox.SelectedItem == "Seconds")
          timeStep /= 86400;
        if ((string)TimeStepTypeBox.SelectedItem == "Minutes")
          timeStep /= 1440;
        if ((string)TimeStepTypeBox.SelectedItem == "Hours")
          timeStep /= 24;
        folderName = FolderBox.Text;
        if (!folderName.EndsWith("\\"))
          folderName += "\\";

        if (System.IO.Directory.Exists(folderName))
        {
          if (System.IO.Directory.GetFiles(folderName).Length > 1)
            if (MessageBox.Show("Directory already contains files, and may be overwritten.", "Continue?", MessageBoxButtons.OKCancel) != DialogResult.OK)
              return;
        }
        else
          System.IO.Directory.CreateDirectory(folderName);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Invalid input.\n"+ex.Message, "Error");
        return; 
      }
      DialogResult = DialogResult.OK; 
    }
  }
}
