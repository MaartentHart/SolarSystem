using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public struct Point3D
  {
    public double x;
    public double y;
    public double z;

    public double MagnitudeSquared
    {
      get
      {
        return x * x + y * y + z * z;
      }
    }

    public double Magnitude
    {
      get
      {
        return Math.Sqrt(MagnitudeSquared);
      }
    }

    public Point3D Normal
    {
      get
      {
        if (x == 0 && y == 0 && z == 0)
          return new Point3D(1, 0, 0);
        return this / Magnitude;
      }
    }

    public Point3D(double x=0, double y=0, double z=0)
    {
      this.x = x;
      this.y = y;
      this.z = z;
    }

    public Point3D(Point3D other)
    {
      x = other.x;
      y = other.y;
      z = other.z; 
    }

    public static Point3D operator -(Point3D A)
    {
      return new Point3D(-A.x, -A.y, -A.z);
    }

    public static bool operator ==(Point3D A, Point3D B)
    {
      return A.x == B.x && A.y == B.y && A.z == B.z;
    }

    public static bool operator !=(Point3D A, Point3D B)
    {
      return A.x != B.x || A.y != B.y || A.z != B.z;
    }

    public static Point3D operator +(Point3D A, Point3D B)
    {
      return new Point3D(A.x + B.x, A.y + B.y, A.z + B.z);
    }

    public static Point3D operator -(Point3D A, Point3D B)
    {
      return new Point3D(A.x - B.x, A.y - B.y, A.z - B.z);
    }

    public static Point3D operator *(Point3D A, double B)
    {
      return new Point3D(A.x * B, A.y * B, A.z * B);
    }

    public static Point3D operator /(Point3D A, double B)
    {
      return new Point3D(A.x / B, A.y / B, A.z / B);
    }

    public static double operator *(Point3D A, Point3D B)
    {
      return A.x * B.x + A.y * B.y + A.z * B.z;
    }

    public void Normalize()
    {
      this /= Magnitude; 
    }

    public Point3D Cross(Point3D other)
    {
      return new Point3D(y * other.z - z * other.y, z * other.x - x * other.z, x * other.y - y * other.x);
    }

    public double Dot(Point3D other)
    {
      return x * other.x + y * other.y + z * other.z; 
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Point3D))
      {
        return false;
      }

      var d = (Point3D)obj;
      return x == d.x &&
             y == d.y &&
             z == d.z;
    }

    public override int GetHashCode()
    {
      var hashCode = 373119288;
      hashCode = hashCode * -1521134295 + x.GetHashCode();
      hashCode = hashCode * -1521134295 + y.GetHashCode();
      hashCode = hashCode * -1521134295 + z.GetHashCode();
      return hashCode;
    }
  }

  public struct Rotation
  {
    public double axisTilt;
    public double axisDirection;
    public double aroundAxis;

    public bool Active => axisTilt != 0 || axisDirection != 0 || aroundAxis != 0;
    /// <summary>
    /// Rotation in radians. 
    /// </summary>
    /// <param name="axisTilt">The planet inclination</param>
    /// <param name="axisDirection">The planet inclination orientation</param>
    /// <param name="aroundAxis">The rotation of the planet around its axis.</param>
    public Rotation(double axisTilt = 0, double axisDirection = 0, double aroundAxis = 0)
    {
      this.axisTilt = axisTilt;
      this.axisDirection = axisDirection;
      this.aroundAxis = aroundAxis;
    }
  }

  public class Translation
  {
    public Point3D Position { get; set; } = new Point3D();
    public Point3D Scale { get; set; } = new Point3D(1,1,1);
    public Rotation Rotation { get; set; } = new Rotation();
    public bool Active => Position.x != 0 || Position.y != 0 || Position.z != 0;
    public bool ScaleActive => Scale.x != 1 || Scale.y != 1 || Scale.z != 1;
  }
}
