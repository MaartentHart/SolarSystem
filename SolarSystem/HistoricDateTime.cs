using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  /// <summary>
  /// Date time with 0 = J2000 (UMT 0:00 1-1-2000) and a much larger range than standard DateTime. 
  /// No timezones. 
  /// </summary>
  public class HistoricDateTime
  { 
    /// <summary>
    /// 365 days * 400 years + 100 leap days - 3 canceled leap days.  
    /// </summary>
    public const int DaysPer400YearCycle = 146097;
    public const int CycleCutDay = 60;// 1-3-2000 (1 march 2000).  
    public const int LeapYearCycle = 1461;
    public const int LeapYearCancelCycle = 36524;

    public double TotalDays { get; set; }
    public double TotalSeconds
    {
      get => TotalDays * 86400;
      set => TotalDays = value / 86400; 
    }

    public long TotalDaysInt => Convert.ToInt64(Math.Floor(TotalDays));
    public double TimePart => TotalDays - TotalDaysInt;
    public double DecimalHours => TimePart * 24;
    public double DecimalMinutes => (DecimalHours - Hours)*60;
    public double DecimalSeconds => (DecimalMinutes - Minutes) * 60;
    public double Milliseconds => (DecimalSeconds - Seconds) * 1000; 

    public int Hours
    {
      get
      {
        return Convert.ToInt32(Math.Floor(DecimalHours));
      }
    }

    public int Minutes
    {
      get
      {
        return Convert.ToInt32(Math.Floor(DecimalMinutes));
      }
    }

    public int Seconds
    {
      get
      {
        return Convert.ToInt32(Math.Floor(DecimalSeconds));
      }
    }

    public long Cycle400
    {
      get
      {
        return (TotalDaysInt - InCycle400) / DaysPer400YearCycle + 5; //5 cycles since 01-03-0000.  
      }
    }

    public long InCycle400
    {
      get
      {
        return (TotalDaysInt - CycleCutDay) % DaysPer400YearCycle;
      }
    }

    public int Year
    {
      get
      {
        throw new NotImplementedException(); 
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="daysSinceJ2000">days since 1-1-2000</param>
    public HistoricDateTime(double daysSinceJ2000)
    {
      TotalDays = daysSinceJ2000; 
    }

  }
}
