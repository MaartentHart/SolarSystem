using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  /*
  public class Triad
  {   
    public Point3D forward;
    public Point3D left;
    public Point3D up;

    public Triad()
    {
      forward = new Point3D(1, 0, 0);
      left = new Point3D(0, 1, 0);
      up = new Point3D(0, 0, 1);
    }

    public Triad(Point3D forward, Point3D left, Point3D up)
    {
      this.forward = forward;
      this.left = left;
      this.up = up; 
    }

    public Triad (Point3D forward, Point3D worldUp)
    {
      //verify...
      this.forward = forward.Normal;
      left = forward.Cross(worldUp).Normal;
      up = left.Cross(this.forward).Normal;
    }

  }*/


  public class TriadGeometry
  {
    public static Mesh GenerateArrow()
    {
      Mesh arrow = new Mesh()
      {
        Name = "Arrow",
        vertices = new double[]
        {
          0,0.05, 0,
          0.5,0.05,0,
          0.4,0.15,0,
          0.8,0,0,
          0.4,-0.15,0,
          0.5,-0.05,0,
          0,-0.05,0,
        },
        indices = new int[]
        {
          6,0,1,
          6,1,5,
          5,1,3,
          1,2,3,
          3,4,5,
        },
        Transparent = true
      };
      return arrow;
    }

    readonly Mesh XTriangle = new Mesh()
    {
      Name = "x",
      vertices = new double[]
      {
        0,0.1,0,
        1,0,0,
        0,-.1,0
      },
      indices = new int[]
      {
        0,1,2
      },
      colors = new float[]
      {
        1,0,0,0.5f,
        1,0,0,0.5f,
        1,0,0,0.5f
      },
      Transparent = true
    };
    readonly Mesh YTriangle = new Mesh()
    {
      Name = "y",
      vertices = new double[]
      {
            0,0,0.1,
            0,1,0,
            0,0,-.1
      },
          indices = new int[]
      {
            0,1,2
      },
          colors = new float[]
      {
            0,1,0,0.5f,
            0,1,0,0.5f,
            0,1,0,0.5f
      },
      Transparent = true
    };
    readonly Mesh ZTriangle = new Mesh()
    {
      Name = "z",
      vertices = new double[]
      {
                0.1,0,0,
                0,0,1,
                -.1,0,0
      },
          indices = new int[]
      {
                0,1,2
      },
          colors = new float[]
      {
                0,0,1,0.5f,
                0,0,1,0.5f,
                0,0,1,0.5f
      },
      Transparent = true
    };

    public Mesh Arrows { get; } = new Mesh()
    {
      Name = "Triad"
    };

    public TriadGeometry()
    {
      //Arrows.Children.Add(XTriangle);
      //Arrows.Children.Add(YTriangle);
      //Arrows.Children.Add(ZTriangle);

      
      Mesh[] arrow = new Mesh[6];
      for (int i = 0; i < 6; i++)
        arrow[i] = GenerateArrow(); 

      arrow[0].SetColor(new ColorFloat(1, 0, 0, 0.5f));
      arrow[1].SetColor(new ColorFloat(1, 0, 0, 0.5f));
      arrow[2].SetColor(new ColorFloat(0, 1, 0, 0.5f));
      arrow[3].SetColor(new ColorFloat(0, 1, 0, 0.5f));
      arrow[4].SetColor(new ColorFloat(0, 0, 1, 0.5f));
      arrow[5].SetColor(new ColorFloat(0, 0, 1, 0.5f));

      arrow[1].Transform.Rotation = new EulerAngles(270, 0, 0);
      arrow[2].Transform.Rotation = new EulerAngles(90, 0, 90);
      arrow[3].Transform.Rotation = new EulerAngles(0, 0, 90);
      arrow[4].Transform.Rotation = new EulerAngles(270, 270, 0);
      arrow[5].Transform.Rotation = new EulerAngles(180, 270, 0); 

      Arrows.Children.AddRange(arrow); 
          
    }
  }
}
