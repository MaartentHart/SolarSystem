using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class BoundingBox
  {
    public Point3D Minimum { get; set; } = new Point3D(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
    public Point3D Maximum { get; set; } = new Point3D(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

    public BoundingBox()
    {}
    
    public BoundingBox(Point3D center, double radius)
    {
      Point3D radiusPoint = new Point3D(radius, radius, radius);
      Minimum = center - radiusPoint;
      Maximum = center + radiusPoint;
    }

    public bool IsInside(Point3D point)
    {
      return !(point.x < Minimum.x || point.y < Minimum.y || point.z < Minimum.z
        || point.x > Maximum.x || point.y > Maximum.y || point.z > Maximum.z);
    }
  }
}
