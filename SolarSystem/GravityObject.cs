using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class GravityObject
  {
    public Point3D[] Points { get; set; } = new Point3D[0];
    public Point3D[] Velocities { get; set; } = new Point3D[0]; 

    public void AddToSimulation()
    {
      if (Points.Length != Velocities.Length)
        throw new Exception("Points and Velocities arrays must be of same length!");

      //note: this may go wrong because of the garbage collector changing the address of Points and Velocities. 
      CoreDll.AddFallingObject(Points, Velocities, Points.Length);
    }

  }
}
