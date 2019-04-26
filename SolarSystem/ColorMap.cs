using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  public class ColorMap
  {
    public ColorFloat StartColor { get; set; } = new ColorFloat();
    public ColorFloat EndColor { get; set; } = new ColorFloat();
    public double EndValue; 

    public List<ColorMapBand> Bands { get; } = new List<ColorMapBand>();

    public ColorMap()
    {

    }

    public ColorMap(string name)
    {
      string fileName = @"Resource\" + name + ".cmap";
      if (!File.Exists(fileName))
      {
        MessageBox.Show(fileName + " does not exist.", "Error opening color map.");
        return;
      }
      string[] lines = File.ReadAllLines(fileName);
      for (int i = 1; i < lines.Length; i++)
        Bands.Add(new ColorMapBand(lines[i]));
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
        Convert.ToSingle(values[1]) / 256,
        Convert.ToSingle(values[2]) / 256,
        Convert.ToSingle(values[3]) / 256
        );
      EndColor = new ColorFloat(
        Convert.ToSingle(values[4]) / 256,
        Convert.ToSingle(values[5]) / 256,
        Convert.ToSingle(values[6]) / 256
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
