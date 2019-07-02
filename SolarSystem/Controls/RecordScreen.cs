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
  public partial class RecordScreen : Form
  {
    private delegate void FocusMainForm(); 

    protected override bool ShowWithoutActivation
    {
      get { return true; }
    }

    public RecordScreen()
    {
      InitializeComponent();
    }

    private void FormKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Escape)
      {
        var d = new FocusMainForm(FocusMainFormFunction);
        Invoke(d);
      }
    }

    private void FocusMainFormFunction()
    {
      MainForm.Main.Hide();
      MainForm.Main.Show(); 
    }

  }
}
