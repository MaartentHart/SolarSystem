//Copyright Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  /// <summary>
  /// https://en.wikipedia.org/wiki/Declination
  /// </summary>
  public class EquatorialCoordinateSystem
  {
    /// <summary>
    /// The vernal equinox in the year 2000. 
    /// </summary>
    public static HistoricDateTime VernalEquinox2000 { get; } = new HistoricDateTime("20 March 2000 AD 07:35:00");

    private Point3D earthPositionAtVernalEquinox = new Point3D();
    public Point3D EarthPositionAtVernalEquinox => earthPositionAtVernalEquinox;

    public Quaternion SystemRotation { get; }
    public Point3D Origin { get; }

    public static EquatorialCoordinateSystem Main { get; private set; }

    public EquatorialCoordinateSystem(Planet earth, HistoricDateTime vernalEquinox = null)
    {
      if (vernalEquinox == null)
        vernalEquinox = VernalEquinox2000; 

      CoreDll.EarthPositionAt(VernalEquinox2000.TotalDays, ref earthPositionAtVernalEquinox);
      double earthAxisTilt = CoreDll.EarthAxisTilt();
      if (earthAxisTilt == 0)
        earthAxisTilt = 23.44;

      Origin = -earthPositionAtVernalEquinox.Normal;

      Point3D triadXAxis = Origin;
      double yaw = OpenGL.Angle.ToDegrees(Math.Atan2(triadXAxis.y, triadXAxis.x));
      double pitch = OpenGL.Angle.ToDegrees(-Math.Sin(triadXAxis.z));
      double roll = earthAxisTilt;
      
      SystemRotation = new EulerAngles(roll,pitch,yaw).Quaternion;
      
      if (Main == null)
        Main = this; 
    }

    /// <summary>
    /// https://en.wikipedia.org/wiki/Declination
    /// </summary>
    /// <param name="rightAscension"></param>
    /// <param name="declination"></param>
    /// <returns>The normal vector of the pointing direction.</returns>
    public Point3D EquatorialCoordinate(double rightAscension, double declination)
    {
      double direction = OpenGL.Angle.ToRadians(rightAscension);
      double rotationUp = OpenGL.Angle.ToRadians(declination);
      double xy = Math.Cos(rotationUp);
      Point3D baseDirection = new Point3D(Math.Cos(direction) * xy, Math.Sin(direction) * xy, Math.Sin(rotationUp));
      Point3D rotated = SystemRotation.Rotate(baseDirection);
      return rotated; 
    }

    public Quaternion PlanetQuaternion(double rightAscension, double declination)
    {
      Point3D axis = EquatorialCoordinate(rightAscension, declination);
      if (double.IsNaN(rightAscension) || double.IsNaN(declination))
        axis = new Point3D(0, 0, 1);

      double yaw = (axis.x == 0 && axis.y == 0) ? 0 : Math.Atan2(axis.y, axis.x);
      double pitch = Math.Acos(axis.z);
      double roll = 0; 

      return new Quaternion(yaw,pitch,roll); 
    }

    public double DirectionRightAscension(Point3D point)
    {
      point = point.Normal;
      Point3D unRotated = SystemRotation.RotateReverse(point);
      double xy = Math.Sqrt(1 - unRotated.z * unRotated.z);
      double directionRad = Math.Acos(unRotated.x / xy);
      double direction =OpenGL.Angle.ToDegrees(directionRad);
      if (direction < 0)
        direction += 360;
      return direction; 
    }

    public double DirectionDeclination(Point3D point)
    {
      point = point.Normal;
      Point3D unRotated = SystemRotation.RotateReverse(point);
      double declinationRad = Math.Asin(unRotated.z);
      return OpenGL.Angle.ToDegrees(declinationRad);     
    }

  }
}
