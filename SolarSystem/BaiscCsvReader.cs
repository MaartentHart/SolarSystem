//Copyright (C) 2019 Maarten 't Hart
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class BasicCsvReader
  {
    private List<string[]> Table { get; } = new List<string[]>(); 
    private Dictionary<string, int> ColumnHeaders { get; }
    public int RowCount => Table.Count;

    public BasicCsvReader(string fileName)
    {
      try
      {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        string[] headers = lines[0].Split(';');

        for (int i=0; i<headers.Length;i++)
          ColumnHeaders[headers[i]] = i;      

        for (int i = 1; i<lines.Length;i++)
        {
          string[] values = lines[i].Split(';');
          if (values.Length != headers.Length)
            continue;
          Table.Add(values); 
        }
      }
      catch
      {

      }
    }

    public string GetString(string header, int row)
    {
      return Table[row][ColumnHeaders[header]];
    }

    public double GetDouble(string header, int row)
    {
      try
      {
        return Convert.ToDouble(GetString(header, row));
      }
      catch
      {
        return 0; 
      }
    }

    public bool GetBool(string header, int row)
    {
      try
      {
        return Convert.ToBoolean(GetString(header, row));
      }
      catch
      {
        return false;
      }
    }

    public float GetFloat(string header, int row)
    {
      try
      {
        return Convert.ToSingle(GetString(header, row));
      }
      catch
      {
        return 0;
      }
    }

    public int GetInt(string header, int row)
    {
      try
      {
        return Convert.ToInt32(GetString(header, row));
      }
      catch
      {
        return 0;
      }
    }
  }
}
