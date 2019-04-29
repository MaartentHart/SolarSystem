using OpenGL;
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

    public static Point3D operator *(Point3D A, Point3D B)
    {
      return new Point3D(A.x * B.x, A.y * B.y, A.z * B.z);
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
  
}
