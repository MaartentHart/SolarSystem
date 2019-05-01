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
        //just set it here. 
        earthAxisTilt = 23.44;
      SystemRotation = new Quaternion(earthPositionAtVernalEquinox, earthAxisTilt);
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
      double xy = Math.Sin(rotationUp);
      Point3D baseDirection = new Point3D(Math.Cos(direction) * xy, Math.Sin(direction) * xy, Math.Cos(rotationUp));
      return SystemRotation.Rotate(baseDirection); 
    }
  }
}
