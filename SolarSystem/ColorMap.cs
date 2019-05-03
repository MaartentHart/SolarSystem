//Copyright Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{

  public struct ColorFloat
  {
    public float R;
    public float G;
    public float B;
    public float A;

    public Color Color => Color.FromArgb(Convert.ToInt32(A * 255), Convert.ToInt32(R * 255), Convert.ToInt32(G * 255), Convert.ToInt32(B * 255));
    public float Average => (R + G + B) / 3;

    public ColorFloat(float r = 1.0f, float g = 1.0f, float b = 1.0f, float a = 1.0f)
    {
      A = a;
      R = r;
      G = g;
      B = b;
    }

    public ColorFloat(Color color)
    {
      R = color.R / 255f;
      G = color.G / 255f;
      B = color.B / 255f;
      A = 1.0f;
    }

    public static bool operator ==(ColorFloat a, ColorFloat b)
    {
      return a.A == b.A && a.B == b.B && a.G == b.G && a.R == b.R;
    }

    public static bool operator !=(ColorFloat a, ColorFloat b)
    {
      return a.A != b.A || a.B != b.B || a.G != b.G || a.R != b.R;
    }

    public override int GetHashCode()
    {
      var hashCode = -1749689076;
      hashCode = hashCode * -1521134295 + A.GetHashCode();
      hashCode = hashCode * -1521134295 + R.GetHashCode();
      hashCode = hashCode * -1521134295 + G.GetHashCode();
      hashCode = hashCode * -1521134295 + B.GetHashCode();
      return hashCode;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is ColorFloat))
      {
        return false;
      }

      var @float = (ColorFloat)obj;
      return A == @float.A &&
             R == @float.R &&
             G == @float.G &&
             B == @float.B;
    }

    public static ColorFloat Interpolate(float interpolation, ColorFloat colorA, ColorFloat colorB)
    {
      float inverse = 1 - interpolation;
      return new ColorFloat(
        colorA.R * interpolation + colorB.R * inverse,
        colorA.G * interpolation + colorB.G * inverse,
        colorA.B * interpolation + colorB.B * inverse,
        colorA.A * interpolation + colorB.A * inverse
        );
    }

    public string RGBString
    {
      get
      {
        Color color = Color;
        return color.R.ToString() + "\t" + color.G.ToString() + "\t" + color.B.ToString() + "\t";
      }
    }
  }

  public class ColorMap
  {
    
    public ColorFloat StartColor { get; set; } = new ColorFloat(1,1,1,1);
    public ColorFloat EndColor { get; set; } = new ColorFloat(1,1,1,1);
    public double EndValue; 

    public List<ColorMapBand> Bands { get; } = new List<ColorMapBand>();

    public ColorMap()
    {

    }

    public ColorMap(ColorFloat color)
    {
      StartColor = color;
      EndColor = color; 
    }

    public ColorMap(string name, bool isFullFileName = false)
    {
      try
      {
        string fileName = @"Resource\" + name + ".cmap";
        if (isFullFileName)
          fileName = name;
        if (!File.Exists(fileName))
        {
          MessageBox.Show(fileName + " does not exist.", "Error opening color map.");
          return;
        }
        string[] lines = File.ReadAllLines(fileName);
        for (int i = 1; i < lines.Length-1; i++)
          Bands.Add(new ColorMapBand(lines[i]));
        ColorMapBand last = new ColorMapBand(lines[lines.Length - 1]);
        StartColor = last.EndColor;
        EndColor = last.StartColor;
        EndValue = last.StartValue; 
      }
      catch
      {
        MessageBox.Show("Error loading colormap " + name); 
      }
    }

    public ColorFloat GetColor (double value)
    {
      if (Bands.Count == 0)
        return value >= EndValue ? EndColor : StartColor;

      if (value < Bands[0].StartValue)
        return StartColor;

      for (int i = 0; i < Bands.Count; i++)
      {
        double endValue = (i < Bands.Count - 1)? Bands[i + 1].StartValue : EndValue;
        if (value >= endValue)
          continue; 
        return Bands[i].GetColor(value, endValue); 
      }

      return EndColor;
    }

    public void Save(string fileName)
    {
      List<string> lines = new List<string>
      {
        "LowBound	Rstart	Gstart	Bstart	Rend	Gend	Bend"
      };

      foreach (ColorMapBand band in Bands)
        lines.Add(band.StartValue.ToString() + "\t" + band.StartColor.RGBString + band.EndColor.RGBString);

      lines.Add(EndValue.ToString() + "\t" + EndColor.RGBString + StartColor.RGBString);
      File.WriteAllLines(fileName,lines);
    }
  }

  public class ColorMapBand
  {
    public ColorFloat StartColor { get; set; } = new ColorFloat();
    public ColorFloat EndColor { get; set; } = new ColorFloat();
    public double StartValue { get; set; } = 0;

    public ColorMapBand(ColorFloat startColor, ColorFloat endColor, double startValue)
    {
      StartColor = startColor;
      EndColor = endColor;
      StartValue = startValue; 
    }

    public ColorMapBand(string line)
    {
      //LowBound	Rstart	Gstart	Bstart	Rend	Gend	Bend
      //-10000  128 0 128 128 0 255
      string[] values = line.Split('\t');
      StartValue = Convert.ToDouble(values[0]);
      StartColor = new ColorFloat(
        Convert.ToSingle(values[1]) / 255,
        Convert.ToSingle(values[2]) / 255,
        Convert.ToSingle(values[3]) / 255
        );
      EndColor = new ColorFloat(
        Convert.ToSingle(values[4]) / 255,
        Convert.ToSingle(values[5]) / 255,
        Convert.ToSingle(values[6]) / 255
        );
    }

    public ColorFloat GetColor(double value, double endValue)
    {
      if (value < StartValue)
        return StartColor;
      if (value > endValue)
        return EndColor;

      float interpolation = (float)((value - StartValue) / (endValue - StartValue));

      return ColorFloat.Interpolate(interpolation, EndColor, StartColor); 
    }
  }

}
