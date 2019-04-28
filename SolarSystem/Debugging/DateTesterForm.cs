using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  public partial class DateTesterForm : Form
  {
    public DateTesterForm()
    {
      InitializeComponent();
      Test(); 
    }
    
    private void Test()
    {
      try
      {
        int day = Convert.ToInt32(DayBox.Text);
        int month = Convert.ToInt32(MonthBox.Text);
        long year = Convert.ToInt64(YearBox.Text);

        string[] time = TimeBox.Text.Split(':');
        int hour =0;
        int minute =0;
        int second =0;
        double milliSecond =0; 

        if (time.Length >0)
        {
          hour = Convert.ToInt32(time[0]);
        }
        if (time.Length >1)
        {
          minute = Convert.ToInt32(time[1]);
        }
        if (time.Length >2)
        {
          double secondDouble = Convert.ToDouble(time[2]);
          second = Convert.ToInt32(Math.Floor(secondDouble));
          milliSecond = (secondDouble - second) * 1000; 
        }

        HistoricDateTime dateTime = new HistoricDateTime(day, month, year, hour, minute, second, milliSecond);
        Display(dateTime);
      }
      catch
      {
        ValueBox.Text = DateStringBox.Text = ToStringBox.Text = "Error";
      }

    }

    private void Display(HistoricDateTime dateTime)
    {
      ValueBox.Text = dateTime.TotalDays.ToString();
      DateStringBox.Text = dateTime.ToDateString(); 
      ToStringBox.Text = dateTime.ToString();
      try
      {
        HistoricDateTime viaString = new HistoricDateTime(dateTime.ToString());
        ViaStringTestBox.Text = viaString.TotalDays.ToString();
      }
      catch (Exception ex)
      {
        ViaStringTestBox.Text = ex.Message;
      }
    }

    private void YearBox_TextChanged(object sender, EventArgs e)
    {
      Test();
    }

    private void MonthBox_TextChanged(object sender, EventArgs e)
    {
      Test();
    }

    private void DayBox_TextChanged(object sender, EventArgs e)
    {
      Test();
    }

    private void TimeBox_TextChanged(object sender, EventArgs e)
    {
      Test();
    }

    private void ValueBox_Leave(object sender, EventArgs e)
    {
      try
      {
        Display(new HistoricDateTime(Convert.ToDouble(ValueBox.Text)));
      }
      catch
      {

      }
    }

  }
}
