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
    private static readonly HistoricDateTime vernalEquinox = new HistoricDateTime("20 March 2000 AD 07:35:00");
    private static Point3D earthPositionAtVernalEquinox = new Point3D();
    private static Quaternion quaternion;

    public static Point3D EarthPositionAtVernalEquinox => earthPositionAtVernalEquinox;
    public static HistoricDateTime VernalEquinox => vernalEquinox;

    public static Quaternion Quaternion => quaternion; 

    public EquatorialCoordinateSystem(Planet earth)
    {
      CoreDll.EarthPositionAt(vernalEquinox.TotalDays, ref earthPositionAtVernalEquinox);
      double earthAxisTilt = CoreDll.EarthAxisTilt();
      if (earthAxisTilt == 0)
        //just set it here. 
        earthAxisTilt = 23.44;
      quaternion = new Quaternion(earthPositionAtVernalEquinox, earthAxisTilt);
    }
  }
}
