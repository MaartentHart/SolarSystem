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

    public EquatorialCoordinateSystem(Planet earth, HistoricDateTime vernalEquinox = null)
    {
      if (vernalEquinox == null)
        vernalEquinox = VernalEquinox2000; 

      CoreDll.EarthPositionAt(VernalEquinox2000.TotalDays, ref earthPositionAtVernalEquinox);
      double earthAxisTilt = CoreDll.EarthAxisTilt();
      if (earthAxisTilt == 0)
        earthAxisTilt = 23.44;

      Point3D triadXAxis = earthPositionAtVernalEquinox.Normal;
      double yaw = OpenGL.Angle.ToDegrees(Math.Atan2(triadXAxis.y, triadXAxis.x));
      double pitch = OpenGL.Angle.ToDegrees(-Math.Sin(triadXAxis.z));
      double roll = earthAxisTilt;
      
      SystemRotation = new EulerAngles(roll,pitch,yaw).Quaternion;
      Origin = earthPositionAtVernalEquinox.Normal; 
    }

    /// <summary>
    /// https://en.wikipedia.org/wiki/Declination
    /// </summary>
    /// <param name="rightAscention"></param>
    /// <param name="declination"></param>
    /// <returns>The normal vector of the pointing direction.</returns>
    public Point3D EquatorialCoordinate(double rightAscention, double declination)
    {
      double direction = OpenGL.Angle.ToRadians(rightAscention);
      double rotationUp = OpenGL.Angle.ToRadians(declination);
      double xy = Math.Cos(rotationUp);
      Point3D baseDirection = new Point3D(Math.Cos(direction) * xy, Math.Sin(direction) * xy, Math.Sin(rotationUp));
      Point3D rotated = SystemRotation.Rotate(baseDirection);
      return rotated; 
    }

    public Quaternion PlanetQuaternion(double rightAscention, double declination)
    {
      Point3D up = new Point3D(0, 0, 1); 
      Point3D axis = EquatorialCoordinate(rightAscention, declination);
      if (double.IsNaN(rightAscention) || double.IsNaN(declination))
        axis = new Point3D(0, 0, 1); 
      return new Quaternion((up+axis)/2,180); 

    }

  }
}
