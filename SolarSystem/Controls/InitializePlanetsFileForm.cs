using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SolarSystem.Controls
{
  public partial class InitializePlanetsFileForm : Form
  {
    public string SourceFile = ""; 

    public InitializePlanetsFileForm()
    {
      InitializeComponent();
      try
      {
        foreach(string file in Directory.GetFiles(@"Resource\CSV"))
        {
          if (Path.GetExtension(file).ToLower() == ".csv")
            SourceFileBox.Items.Add(file); 
        }
      }
      catch
      {

      }
      if (SourceFileBox.Items.Count > 0)
        SourceFileBox.SelectedIndex = 0; 
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (SourceFileBox.SelectedIndex <SourceFileBox.Items.Count && SourceFileBox.SelectedIndex>=0)
      {
        SourceFile = (string) SourceFileBox.Items[SourceFileBox.SelectedIndex];
      }
      DialogResult = DialogResult.OK;
    }
  }
}
