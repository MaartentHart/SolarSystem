using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public enum SolarSystemPlanet
  {
    [StringValue("Sun")] Sun,
    [StringValue("Mercury")] Mercury,
    [StringValue("Venus")] Venus,
    [StringValue("Earth")] Earth,
    [StringValue("Mars")] Mars,
    [StringValue("Jupiter")] Jupiter,
    [StringValue("Saturn")] Saturn,
    [StringValue("Uranus")] Uranus,
    [StringValue("Neptune")] Neptune,
    [StringValue("Pluto")] Pluto,
    [StringValue("Moon")] Moon,
  }

  /// <summary>
  /// The renderable class of the planet. 
  /// </summary>
  public class Planet
  {
    public SolarSystemPlanet PlanetEnum { get; } 
    public CRenderableObject RenderableObject { get; } = new CRenderableObject();

    public Planet(SolarSystemPlanet planet)
    {
      PlanetEnum = planet;
      RenderableObject.HeightMap = new HeightMap(planet); 
    }

    public override string ToString()
    {
      return PlanetEnum.ToString(); 
    }
  }
}
