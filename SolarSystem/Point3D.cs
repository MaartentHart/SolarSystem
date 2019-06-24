//Copyright Maarten 't Hart 2019
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

    public bool HasNaN => double.IsNaN(x) || double.IsNaN(y) || double.IsNaN(z); 

    public Point3D(double x = 0, double y = 0, double z = 0)
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

    public static double[] ToVerticesArray(IEnumerable<Point3D> points)
    {
      double[] result = new double[points.Count() * 3];

      int target = 0;

      foreach (Point3D point in points)
      {
        result[target++] = point.x;
        result[target++] = point.y;
        result[target++] = point.z;
      }

      return result;
    }

    public static Point3D[] ToPointArray(IEnumerable<double> vertices)
    {
      int size = vertices.Count();

      if (size % 3 != 0)
        throw new Exception("Vertices array length must be a multiple of 3.");

      size /= 3;

      Point3D[] result = new Point3D[size];
      int i = 0;
      int j = 0;

      Point3D current = new Point3D();

      foreach (double vertex in vertices)
      {
        j++;
        if (j == 1)
          current.x = vertex;
        else if (j == 2)
          current.y = vertex;
        if (j == 3)
        {
          current.z = vertex;
          result[i++] = current;
          j = 0;
          current = new Point3D();
        }
      }

      return result;
    }
  } 
}
