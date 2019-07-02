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
  public partial class ImpactListForm : Form
  {
    private int ImpactCount { get; set; } = -1;

    public ImpactListForm()
    {
      InitializeComponent();
      ShowImpacts();
    }

    private void ShowImpacts()
    {
      int impactCount = CoreDll.GetImpactCount();
      if (impactCount == ImpactCount)
        return;
     

      ImpactCount = impactCount;

      int planetID = 0;
      double speed = 0;
      double time = 0;
      Point3D position = new Point3D();

      Dictionary<int, string> planetNames = new Dictionary<int, string>(); 

      using (DataTable dataTable = new DataTable())
      {
        DataColumn idColumn = dataTable.Columns.Add("id",typeof(int));
        DataColumn planetColumn = dataTable.Columns.Add("Planet",typeof(string));
        DataColumn speedColumn = dataTable.Columns.Add("Speed",typeof(double));
        DataColumn timeColumn = dataTable.Columns.Add("Time", typeof(string));
        DataColumn latColumn = dataTable.Columns.Add("Latitude",typeof(double));
        DataColumn longColumn = dataTable.Columns.Add("Longitude",typeof(double));

        for (int i = 0; i < impactCount; i++)
        {
          CoreDll.GetImpact(i, ref planetID, ref speed, ref time, ref position);
          string planet = "";
          if (!planetNames.TryGetValue(planetID, out planet))
            planetNames[planetID] = planet = MainForm.GetPlanetName(planetID);
          HistoricDateTime historicDateTime = new HistoricDateTime(time);
          string timeString = historicDateTime.ToBCADDateString() + " " + historicDateTime.ToTimeString();
          double latitude = Math.Asin(position.z) / Math.PI * 180;
          double longitude = Math.Atan2(position.y, position.x) / Math.PI * 180;

          dataTable.Rows.Add(new object[] { i, planet, speed, timeString, latitude, longitude }); 
        }

        ImpactGridView.DataSource = dataTable;
      }
    }

    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
      ShowImpacts(); 
    }

    private void AutoUpdateBox_CheckedChanged(object sender, EventArgs e)
    {
      UpdateTimer.Enabled = AutoUpdateBox.Checked; 
    }

    private void UpdateButton_Click(object sender, EventArgs e)
    {
      ShowImpacts(); 
    }
  }
}
