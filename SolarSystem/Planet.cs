using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  /// <summary>
  /// The renderable class of the planet. 
  /// </summary>
  public class Planet
  {
    public CRenderableObject CRenderableObject { get; set; } = new CRenderableObject(); 
  }
}
