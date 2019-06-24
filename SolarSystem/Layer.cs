using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class Layer
  {
    private ColorMap colorMap; 
    private object locker = new object(); 
    private bool repaint = false;

    public Texture Texture { get; set; } 
    public string Name { get; }
    public double[] Values { get; set; }
    public bool Repaint
    {
      get
      {
        lock (locker)
        {
          bool ret = repaint;
          repaint = false;
          return ret;
        }
      }
      set
      {
        lock(locker)
          repaint = value; 
      }
    }

    public ColorMap ColorMap
    {
      get => colorMap;
      set
      {
        colorMap = value; 
        Repaint = true;
      }
    }

    public bool UseTexture => Texture != null; 

    public Layer(string name, double[] values = null)
    {
      Name = name;
      Values = values; 
    }
  }
}
