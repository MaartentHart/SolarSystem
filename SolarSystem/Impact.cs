//Copyright (C) Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class Impact
  {
    private int id;

    public int planetID;
    public double speed;
    public double time;
    public Point3D vector;

    public int ID { get; }

    public Impact()
    {
      id = -1;
    }

    public Impact(int id)
    {
      GetById(id); 
    }

    private void GetById(int id)
    {
      this.id = id; 
      if (id < 0 || id >= CoreDll.GetImpactCount())
        throw new ArgumentOutOfRangeException("Invalid impact id.");
      CoreDll.GetImpact(id, ref planetID, ref speed, ref time, ref vector); 
    }

    internal void DrawOn(Planet planet)
    {
      Layer layer = planet.ValueLayer;
      if (layer == null)
        return;

      //using default values for now. 
      double radius = 100;
      double scaledRadius = radius / 6000;
      double maxValue = 1000;

      CoreDll.DrawImpactOn(id, planet.Generation, scaledRadius, maxValue, layer.Values);
      layer.Repaint = true; 
    }
  }
}
