//Copyright Maarten 't Hart 2019
using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{

  public interface IRotation
  {
    bool Active { get; }
    void GlRotate();
    Point3D Rotate(Point3D point);
    Point3D[] Rotate(Point3D[] points);
    Point3D RotateReverse(Point3D point); 
    Point3D[] RotateReverse(Point3D[] points);

    Quaternion ToQuaternion(); 
  }  

  /// <summary>
  /// Euler angles
  /// </summary>
  public class EulerAngles: IRotation
  {
    public double yaw;
    public double pitch;
    public double roll;

    public double X
    {
      get => roll;
      set => roll = value; 
    }
    public double Y
    {
      get => pitch;
      set => pitch = value;
    }
    public double Z
    {
      get => yaw;
      set => yaw = value;
    }

    public Quaternion Quaternion => new Quaternion(this);

    public bool Active => yaw!=0 || pitch !=0 || roll !=0;

    public EulerAngles(Point3D angles)
      : this(angles.x, angles.y, angles.z)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x">roll</param>
    /// <param name="y">pitch</param>
    /// <param name="z">yaw</param>
    public EulerAngles(double x = 0, double y = 0, double z =0)
    {
      roll = x;
      pitch = y;
      yaw = z;
    }

    public EulerAngles(Quaternion q)
    {
      //https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
      // roll (x-axis rotation)
      double sinr_cosp = +2.0 * (q.w * q.x + q.y * q.z);
      double cosr_cosp = +1.0 - 2.0 * (q.x * q.x + q.y * q.y);
      roll = Math.Atan2(sinr_cosp, cosr_cosp);

      // pitch (y-axis rotation)
      double sinp = +2.0 * (q.w * q.y - q.z * q.x);
      if (Math.Abs(sinp) >= 1)
        pitch = sinp > 0 ? Math.PI / 2: -Math.PI /2; // use 90 degrees if out of range
      else
        pitch = Math.Asin(sinp);

      // yaw (z-axis rotation)
      double siny_cosp = +2.0 * (q.w * q.z + q.x * q.y);
      double cosy_cosp = +1.0 - 2.0 * (q.y * q.y + q.z * q.z);
      yaw = Math.Atan2(siny_cosp, cosy_cosp);

      roll = Angle.ToDegrees(roll);
      pitch = Angle.ToDegrees(pitch);
      yaw = Angle.ToDegrees(yaw); 
    }

    public void GlRotate()
    {
      Test(); 
      Quaternion.GlRotate(); 
    }

    private void Test()
    {
      Quaternion quaternion = Quaternion;
      EulerAngles test = new EulerAngles(quaternion); 
    }

    public Point3D Rotate(Point3D point) => Quaternion.Rotate(point);

    public Point3D[] Rotate(Point3D[] points) => Quaternion.Rotate(points);

    public Point3D RotateReverse(Point3D point) => Quaternion.RotateReverse(point);

    public Point3D[] RotateReverse(Point3D[] points) => Quaternion.RotateReverse(points); 

    public Quaternion ToQuaternion()
    {
      return Quaternion;
    }
    /*
    ///////////////////////////////////////////////////////////////////////////////
    // convert Euler angles(x,y,z) to axes(left, up, forward)
    // Each column of the rotation matrix represents left, up and forward axis.
    // The order of rotation is Roll->Yaw->Pitch (Rx*Ry*Rz)
    // Rx: rotation about X-axis, pitch
    // Ry: rotation about Y-axis, yaw(heading)
    // Rz: rotation about Z-axis, roll
    //    Rx           Ry          Rz
    // |1  0   0| | Cy  0 Sy| |Cz -Sz 0|   | CyCz        -CySz         Sy  |
    // |0 Cx -Sx|*|  0  1  0|*|Sz  Cz 0| = | SxSyCz+CxSz -SxSySz+CxCz -SxCy|
    // |0 Sx  Cx| |-Sy  0 Cy| | 0   0 1|   |-CxSyCz+SxSz  CxSySz+SxCz  CxCy|
    ///////////////////////////////////////////////////////////////////////////////
    public Triad ToTriad()
    {
      Point3D angles = new Point3D(pitch, yaw, roll); 

      //http://www.songho.ca/opengl/gl_anglestoaxes.html
      double sx, sy, sz, cx, cy, cz, theta;

      // rotation angle about X-axis (pitch)
      theta = Degrees.Deg2Rad(angles.x);
      sx = Math.Sin(theta);
      cx = Math.Cos(theta);

      // rotation angle about Y-axis (yaw)
      theta = Degrees.Deg2Rad(angles.y);
      sy = Math.Sin(theta);
      cy = Math.Cos(theta);

      // rotation angle about Z-axis (roll)
      theta = Degrees.Deg2Rad(angles.z);
      sz = Math.Sin(theta);
      cz = Math.Cos(theta);

      Point3D left;
      Point3D up;
      Point3D forward;

      // determine left axis
      left.x = cy* cz;
      left.y = sx* sy*cz + cx* sz;
      left.z = -cx* sy*cz + sx* sz;

      // determine up axis
      up.x = -cy* sz;
      up.y = -sx* sy*sz + cx* cz;
      up.z = cx* sy*sz + sx* cz;

      // determine forward axis
      forward.x = sy;
      forward.y = -sx* cy;
      forward.z = cx* cy;

      return new Triad(forward, left, up); 
    }*/
  }
  /*
  public struct CelestialRotation : IRotation
  {
    public double axisTilt;
    public double axisDirection;
    public double aroundAxis;

    public bool Active => axisTilt != 0 || axisDirection != 0 || aroundAxis != 0;
    /// <summary>
    /// Rotation in degrees. 
    /// </summary>
    /// <param name="axisTilt">The planet inclination</param>
    /// <param name="axisDirection">The planet inclination orientation</param>
    /// <param name="aroundAxis">The rotation of the planet around its axis.</param>
    public CelestialRotation(double axisTilt = 0, double axisDirection = 0, double aroundAxis = 0)
    {
      this.axisTilt = axisTilt;
      this.axisDirection = axisDirection;
      this.aroundAxis = aroundAxis;
    }

    public void GlRotate()
    {
      double sinA = Math.Sin(axisTilt);
      Gl.Rotate(axisDirection, 0, 0, 1);
      Gl.Rotate(axisTilt, 1, 0, 0);
      Gl.Rotate(aroundAxis, 0, 0, 1);
    }
  }*/

  public class Quaternion : IRotation
  {
    public double w, x, y, z;

    public double I
    {
      get => x;
      set => x = value;
    }
    public double J
    {
      get => y;
      set => y = value;
    }
    public double K
    {
      get => z;
      set => z = value;
    }
    public Point3D Vector => new Point3D(x, y, z); 

    //w = cos(theta / 2)
    //https://answers.unity.com/questions/147712/what-is-affected-by-the-w-in-quaternionxyzw.html
    public double Rotation => Math.Acos(w) * 2;

    public bool Active => true;

    public Quaternion Reverse => new Quaternion(-x, -y, -z, w); 

    //https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
    public Quaternion( double yaw, double pitch, double roll) // yaw (Z), pitch (Y), roll (X)
    {
      // Abbreviations for the various angular functions
      double cy = Math.Cos(yaw * 0.5);
      double sy = Math.Sin(yaw * 0.5);
      double cp = Math.Cos(pitch * 0.5);
      double sp = Math.Sin(pitch * 0.5);
      double cr = Math.Cos(roll * 0.5);
      double sr = Math.Sin(roll * 0.5);

      w = cy * cp * cr + sy * sp * sr;
      x = cy * cp * sr - sy * sp * cr;
      y = sy * cp * sr + cy * sp * cr;
      z = sy * cp * cr - cy * sp * sr;
    }

    public Quaternion(double x, double y, double z, double w)
    {
      this.x = x;
      this.y = y;
      this.z = z;
      this.w = w; 
    }

    public Quaternion()
    {
      x = y = w = 0; 
      z = 1;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector">the axis to rotate about.</param>
    /// <param name="rotation">rotation in degrees</param>
    public Quaternion(Point3D vector, double rotation)
    {
      //https://www.euclideanspace.com/maths/geometry/rotations/conversions/angleToQuaternion/index.htm
      vector.Normalize(); 
      rotation = Angle.Normalize360(rotation);
      if (rotation < 0)
        rotation += 360;
      double angle = Angle.ToRadians(rotation);
      double s = Math.Sin(angle / 2);
      x = vector.x * s;
      y = vector.y * s;
      z = vector.z * s;
      w = Math.Cos(angle / 2);
    }

    public Quaternion(EulerAngles rotation)
      :this (Angle.ToRadians(rotation.yaw), Angle.ToRadians(rotation.pitch), Angle.ToRadians(rotation.roll))
    { }

    /// <summary>
    /// Apply OpenGL rotation.
    /// </summary>
    public void GlRotate()
    {
      if (!Active)
        return; 
      Gl.Rotate(Angle.ToDegrees(Rotation), x, y, z); 
    }

    /// <summary>
    /// Rotate a vertex by the qurrent quaternion. 
    /// </summary>
    /// <param name="point">The point tot rotate</param>
    /// <returns>The rotated point</returns>
    public Point3D Rotate(Point3D point)
    {
      //https://gamedev.stackexchange.com/questions/28395/rotating-vector3-by-a-quaternion
      return Vector * 2.0 * Vector.Dot(point) + point * (w * w - Vector.Dot(Vector)) + Vector.Cross(point) * 2.0 * w;
    }

    /// <summary>
    /// Rotate a vertex by the qurrent quaternion. 
    /// </summary>
    /// <param name="point">The points tot rotate</param>
    /// <returns>The rotated points</returns>
    public Point3D[] Rotate(Point3D[] points)
    {
      int size = points.Length; 
      Point3D[] result = new Point3D[size];

      for (int i = 0; i < size; i++)
        result[i] = Rotate(points[i]);

      return result; 
    }

    public Point3D RotateReverse(Point3D point)
    {
      return Reverse.Rotate(point);
    }

    public Point3D[] RotateReverse(Point3D[] points)
    {
      return Reverse.Rotate(points); 
    }

    public Quaternion Rotate(Quaternion quaternion)
    {
      Point3D rotated = Rotate(quaternion.Vector);
      return new Quaternion(rotated.x, rotated.y, rotated.z, quaternion.w);
    }

    public Quaternion ToQuaternion()
    {
      return this; 
    }
  }

  public class DoubleRotation : IRotation
  {
    public IRotation SystemRotation { get; set; }
    public IRotation LocalRotation { get; set; }

    public Quaternion SystemRotationQ => SystemRotation.ToQuaternion();
    public Quaternion LocalRotationQ => LocalRotation.ToQuaternion(); 

    public bool Active { get; set; } = true; 

    public void GlRotate()
    {
      if (!Active)
        return;

      Gl.Rotate(Angle.ToDegrees(SystemRotationQ.Rotation), SystemRotationQ.x, SystemRotationQ.y, SystemRotationQ.z);
      Gl.Rotate(Angle.ToDegrees(LocalRotationQ.Rotation), LocalRotationQ.x, LocalRotationQ.y, LocalRotationQ.z);
    }

    public DoubleRotation(Quaternion systemRotation = null, Quaternion localRotation = null)
    {
      if (systemRotation == null)
        systemRotation = new Quaternion();
      if (localRotation == null)
        localRotation = new Quaternion();

      SystemRotation = systemRotation;
      LocalRotation = localRotation; 
    }

    public Point3D Rotate(Point3D point)
    {
      return SystemRotation.Rotate(LocalRotation.Rotate(point));
    }

    public Point3D[] Rotate(Point3D[] points)
    {
      return SystemRotation.Rotate(LocalRotation.Rotate(points)); 
    }

    public Point3D RotateReverse(Point3D point)
    {
      return SystemRotation.RotateReverse(LocalRotation.RotateReverse(point));
    }

    public Point3D[] RotateReverse(Point3D[] points)
    {
      return LocalRotation.RotateReverse(SystemRotation.RotateReverse(points));
    }
    
    public Quaternion ToQuaternion()
    {
      //http://www.ncsa.illinois.edu/People/kindr/emtc/quaternions/quaternion.c++
      Quaternion a = SystemRotationQ;
      Quaternion q = LocalRotationQ; 

      return new Quaternion(       
       a.w * q.x + a.x * q.w + a.y * q.z - a.z * q.y,
       a.w * q.y + a.y * q.w + a.z * q.x - a.x * q.z,
       a.w * q.z + a.z * q.w + a.x * q.y - a.y * q.x,
       a.w * q.w - a.x * q.x - a.y * q.y - a.z * q.z
       );
    }
  }

}
