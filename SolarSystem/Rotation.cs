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
    void Rotate(); 
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
        pitch = CoreDll.CopySign(Math.PI / 2, sinp); // use 90 degrees if out of range
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

    public void Rotate()
    {
      Test(); 
      Quaternion.Rotate(); 
    }

    private void Test()
    {
      Quaternion quaternion = Quaternion;
      EulerAngles test = new EulerAngles(quaternion); 
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

    public void Rotate()
    {
      double sinA = Math.Sin(axisTilt);
      Gl.Rotate(axisDirection, 0, 0, 1);
      Gl.Rotate(axisTilt, 1, 0, 0);
      Gl.Rotate(aroundAxis, 0, 0, 1);
    }
  }

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

    //w = cos(theta / 2)
    //https://answers.unity.com/questions/147712/what-is-affected-by-the-w-in-quaternionxyzw.html
    public double Rotation => Math.Acos(w) * 2;

    public bool Active => true;

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="rotation">rotation in degrees</param>
    public Quaternion(Point3D vector, double rotation)
    {
      w = Math.Cos(Angle.ToRadians(rotation) / 2);
      vector = vector.Normal;
      x = vector.x;
      y = vector.y;
      z = vector.z; 
    }

    public Quaternion(EulerAngles rotation)
      :this (Angle.ToRadians(rotation.yaw), Angle.ToRadians(rotation.pitch), Angle.ToRadians(rotation.roll))
    { }

    public void Rotate()
    {
      Gl.Rotate(Angle.ToDegrees(Rotation), x, y, z); 
    }
  }
}
