//Copyright Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  /// <summary>
  /// Date time with 0 = J2000 (UCT 12:00 1-1-2000) and a much larger range than standard DateTime. 
  /// Dates should be formatted day-month-year. 
  /// No timezones. 
  /// 
  /// There is a leap year every 4 years, adding a 29th february
  /// There is no leap year if the year is divisible by 100
  /// There is a leap year if the year is divisible by 400
  /// There is no year 0. If the year is lower than 1, 1 is subtracted.
  /// This means that -5, -9, -13 etc. are leap years. 
  /// </summary>
  public class HistoricDateTime
  {
    /// <summary>
    /// 365 days * 400 years + 100 leap days - 3 canceled leap days.  
    /// </summary>
    /// 
    public const int FourCenturyDays = 146097;
    /// <summary>
    /// 100 * 365 days + 24 leap days. 
    /// </summary>
    public const int CenturyDays = 36524;
    /// <summary>
    /// 4 * 365 + 1 days. 
    /// </summary>
    public const int FourYearDays = 1461;
    public const int YearDays = 365;
    /// <summary>
    /// The day 01-03-2000 (the nearest 400 year cycle cut position) 
    /// </summary>
    public const int CycleCutDay = 60;// 1-3-2000 (1 march 2000).  

    public const double J2000TwelveHourShift = 0.5;

    public double TotalDays { get; set; }

    /// <summary>
    /// TotalDays is the main variable that is stored. 
    /// The amount of days since 01-01-2000 00:00:00
    /// </summary>
    public double TotalDays0000 {
      get => TotalDays + J2000TwelveHourShift;
      set => TotalDays = value - J2000TwelveHourShift; }

    /// <summary>
    /// The amount of seconds since 01-01-2000 00:00:00
    /// </summary>
    public double TotalSeconds
    {
      get => TotalDays0000 * 86400;
      set => TotalDays0000 = value / 86400;
    }

    public long TotalDaysInt => Convert.ToInt64(Math.Floor(TotalDays0000));
    public double TimePart => TotalDays0000 - TotalDaysInt;
    public double DecimalHours => Math.Round((TimePart * 24),9);
    public double DecimalMinutes => Math.Round((DecimalHours - Hours) * 60,6);
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

    private long FourCenturyCycles => FloorDiv((TotalDaysInt - CycleCutDay), FourCenturyDays) + 5;
    private int DaysInFourCenturyCycle => Convert.ToInt32(Mod((TotalDaysInt - CycleCutDay), FourCenturyDays));
    private int DaysInCenturyCycle => Mod(DaysInFourCenturyCycle, CenturyDays);
    private int CenturiesInFourCenturyCycle => FloorDiv((DaysInFourCenturyCycle - DaysInCenturyCycle), CenturyDays);
    private int LeapYearsInCentury => FloorDiv(DaysInCenturyCycle, FourYearDays);
    private int YearsInFourYearCycle => FloorDiv((DaysInCenturyCycle - LeapYearsInCentury * FourYearDays), YearDays);
    private int Last01MarStart => DaysInCenturyCycle - LeapYearsInCentury * FourYearDays - YearsInFourYearCycle * YearDays;
    private bool Is400YearException => DaysInFourCenturyCycle == FourCenturyDays - 1;
    private bool Is29Feb => Is400YearException || YearsInFourYearCycle == 4;

    private long YearAllow0
    {
      get
      {
        int add = 0;
        if (Month <= 2)
          add += 1;
        if (Is400YearException)
          add -= 1;
        if (YearsInFourYearCycle == 4)
          add -= 1;
        return FourCenturyCycles * 400 + CenturiesInFourCenturyCycle * 100 + 
          LeapYearsInCentury * 4 + YearsInFourYearCycle + add;
      }
    }

    public long Year
    {
      get
      {
        long result = YearAllow0;
        if (result < 1)
          result -= 1;
        return result;
      }
    }

    public int Month
    {
      get
      {
        if (Is29Feb)
          return 2;

        int days = Last01MarStart;
        if (days >= 337)
          return 2;
        if (days >= 306)
          return 1;
        if (days >= 275)
          return 12;
        if (days >= 245)
          return 11;
        if (days >= 214)
          return 10;
        if (days >= 184)
          return 9;
        if (days >= 153)
          return 8;
        if (days >= 122)
          return 7;
        if (days >= 92)
          return 6;
        if (days >= 61)
          return 5;
        if (days >= 31)
          return 4;
        return 3;
      }
    }

    public int Day
    {
      get
      {
        if (Is29Feb)
          return 29;

        int days = Last01MarStart;
        if (days >= 337)
          return days-336;
        if (days >= 306)
          return days-305;
        if (days >= 275)
          return days-274;
        if (days >= 245)
          return days-244;
        if (days >= 214)
          return days-213;
        if (days >= 184)
          return days-183;
        if (days >= 153)
          return days-152;
        if (days >= 122)
          return days-121;
        if (days >= 92)
          return days-91;
        if (days >= 61)
          return days-60;
        if (days >= 31)
          return days-30;
        return days+1;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="daysSinceJ2000">days since 1-1-2000 12:00</param>
    public HistoricDateTime(double daysSinceJ2000)
    {
      TotalDays = daysSinceJ2000;
    }

    public HistoricDateTime(int day = 1, int month = 1, long year = 2000, int hours = 0, int minutes = 0, double seconds = 0, double milliseconds = 0)
    {
      Set(day, month, year, hours, minutes, seconds, milliseconds); 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateString">String formatted as "1 January 2000 AD 00:00:00.0000". Use BC instead of AD for negative years. Note: the year "0" does not exist. </param>
    public HistoricDateTime(string dateString)
    {
      string[] vals = dateString.Split(' ');
      int day = Convert.ToInt32(vals[0]);
      int month = TextMonth(vals[1]);
      long year = Convert.ToInt32(vals[2]);
      if (vals[3].ToLower() == "bc")
        year = -year;

      string[] time = vals[4].Split(':');
      int hours = Convert.ToInt32(time[0]);
      int minutes = Convert.ToInt32(time[1]);
      string[] secondsSplit = time[2].Split('.');
      double seconds = Convert.ToInt32(secondsSplit[0]);
      if (secondsSplit.Length > 1)
        seconds += Convert.ToDouble("0." + secondsSplit[1]);
      Set(day, month, year, hours, minutes, seconds);
    }

    private void Set(int day = 1, int month = 1, long year = 2000, int hours = 0, int minutes = 0, double seconds = 0, double milliseconds = 0)
    {
      //resolving the year. 
      if (year < 0)
        year += 1;
      year -= 2000;

      int years400 = Convert.ToInt32(Mod(year, 400)); 
      long fourCenturyCycles = (year-years400) / 400;
      int years100 = Mod(years400, 100);
      int centuries = (years400-years100) / 100;
      int years4 = Mod(years100, 4);
      int leapYears = (years100-years4) / 4;

      long daysByYears = fourCenturyCycles * FourCenturyDays 
        + centuries * CenturyDays 
        + leapYears * FourYearDays 
        + years4 * YearDays;

      bool isLeapYear = false;
      if (years400 == 0)
        isLeapYear = true;
      else if (years100 == 0)
        isLeapYear = false;
      else if (years4 == 0)
        isLeapYear = true; 

      //resolving months
      int daysByMonth = 0;
      switch (month)
      {
        case 2: daysByMonth = 31; break;
        case 3: daysByMonth = 59; break;
        case 4: daysByMonth = 90; break;
        case 5: daysByMonth = 120; break;
        case 6: daysByMonth = 151; break;
        case 7: daysByMonth = 181; break;
        case 8: daysByMonth = 212; break;
        case 9: daysByMonth = 243; break;
        case 10: daysByMonth = 273; break;
        case 11: daysByMonth = 304; break;
        case 12: daysByMonth = 334; break;
      }

      //the total amount of days. 
      long daysTotal = daysByYears + daysByMonth + day;
      if (isLeapYear && month < 3)
        daysTotal -= 1;

      double time = hours / 24.0 + minutes / 1440.0 + seconds / 86400.0 + milliseconds / 86400000;

      TotalDays0000 = daysTotal + time; 
    }

    public HistoricDateTime(DateTime dateTime)
     : this(dateTime.Day,dateTime.Month,dateTime.Year,dateTime.Hour,dateTime.Minute,dateTime.Second,dateTime.Millisecond)
    { }

    public static HistoricDateTime ByTime(int hours = 0, int minutes = 0, int seconds = 0, double milliseconds = 0)
    {
      return new HistoricDateTime(0, 0, 0, hours, minutes, seconds, milliseconds);
    }

    public static HistoricDateTime BySeconds(double seconds)
    {
      return new HistoricDateTime(seconds / 86400);
    }
    
    public static string MonthText(int month)
    {
      switch (month)
      {
        case 1: return "January";
        case 2: return "February";
        case 3: return "March";
        case 4: return "April";
        case 5: return "May";
        case 6: return "June";
        case 7: return "July";
        case 8: return "August";
        case 9: return "September";
        case 10: return "October";
        case 11: return "November";
        case 12: return "December";
      }
      throw new Exception(month.ToString() + " is not a valid month number. (Range: 1-12)");
    }

    public static int TextMonth(string text)
    {
      text = text.ToLower();
      switch(text)
      {
        case "january": return 1;
        case "february": return 2;
        case "march": return 3;
        case "april": return 4;
        case "may": return 5;
        case "june": return 6;
        case "july": return 7;
        case "august": return 8;
        case "september": return 9;
        case "october": return 10;
        case "november": return 11;
        case "december": return 12;
      }
      throw new Exception(text.ToString() + " is not a valid month.");
    }

    public string TwoDigits(string value)
    {
      if (value.Length == 1)
        return "0" + value;
      return value; 
    }

    public string ToDateString()
    {
      string year = Year.ToString();
      string month = TwoDigits(Month.ToString());
      string day = TwoDigits(Day.ToString());
      return day + "-" + month + "-" + year; 
    }

    public string ToBCADDateString()
    {
      long yearVal = Year;
      string year = Convert.ToInt64(Math.Abs(yearVal)).ToString() +
        (yearVal > 0 ? " AD" : " BC");
      string month = TwoDigits(Month.ToString());
      string day = TwoDigits(Day.ToString());
      return day + "-" + month + "-" + year;
    }

    public string ToPrettyDateString()
    {
      long yearVal = Year; 
      string year = Convert.ToInt64(Math.Abs(yearVal)).ToString() +
        (yearVal > 0 ? " AD" : " BC");
      string month = MonthText(Month); 
      string day = TwoDigits(Day.ToString());
      return day + " " + month + " " + year;
    }

    public string ToTimeString()
    {
      string hours = TwoDigits(Hours.ToString());
      string minutes = TwoDigits(Minutes.ToString());
      string seconds = Math.Round((Seconds + Milliseconds / 1000),5).ToString();
      if (Seconds < 10)
        seconds = "0" + seconds;
      return hours + ":" + minutes + ":" + seconds;
    }

    public string ToRoundedTimeString()
    {
      string hours = TwoDigits(Hours.ToString());
      string minutes = TwoDigits(Minutes.ToString());
      string seconds = Math.Round((Seconds + Milliseconds / 1000), 0).ToString();
      if (Seconds < 10)
        seconds = "0" + seconds;
      return hours + ":" + minutes + ":" + seconds;
    }

    public override string ToString()
    {
      return ToPrettyDateString() + " " + ToTimeString(); 
    }

    
    private static int Mod(int numerator, int denominator)
    {
      int mod = numerator % denominator;
      return mod < 0 ? mod + denominator : mod;
    }

    private static long Mod(long numerator, long denominator)
    {
      long mod = numerator % denominator;
      return mod < 0 ? mod + denominator : mod;
    }

    private static int FloorDiv(int numerator, int denominator)
    {
      return Convert.ToInt32(Math.Floor(((double)numerator) / denominator));
    }

    private static long FloorDiv(long numerator, long denominator)
    {
      return Convert.ToInt64(Math.Floor(((double)numerator) / denominator));
    }
  }
}
