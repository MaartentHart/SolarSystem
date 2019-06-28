//Copyright (C) Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; 

namespace SolarSystem
{
  public class Texture
  {
    private double rotation; 
    private Image image;
    private Bitmap bitmap;

    public double Rotation => rotation; 

    public string FileName { get; set; }

    public string Name => System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetFileName(FileName));
    public string Extension => System.IO.Path.GetExtension(FileName); 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName">The texture filename</param>
    /// <param name="rotation">The shift of the cylinder x-position in degrees</param>
    public Texture (string fileName, double rotation = 0)
    {
      this.rotation = rotation / 360;
      FileName = fileName; 
    }

    public void Apply(IntPtr target, int generation)
    {
      try
      {
        using (image = Image.FromFile(FileName))
          using (bitmap = image as Bitmap)
          unsafe
          {
            int verticesCount = CoreDll.GeodesicGridVerticesCount(generation);
            IntPtr vertices = CoreDll.GeodesicGridVertices(generation);

            ColorFloat* color = (ColorFloat*)target.ToPointer();
            Point3D* vertex = (Point3D*)vertices.ToPointer();

            for (int i = 0; i < verticesCount; i++, color++, vertex++)
              *color = GetColor(*vertex);
          }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error applying texture " + FileName + "\n" + ex.Message, "Error");
      }
    }

    private ColorFloat GetColor(Point3D vertex)
    {
      double y = (1-(Math.Asin(vertex.z) + Math.PI/2)/Math.PI);
      double x = (Math.Atan2(vertex.y, vertex.x) + Math.PI)/(Math.PI*2);

      x += rotation;
      if (x >= 1)
        x -= 1;
      if (x < 0)
        x += 1; 

      int px = (int)(x * bitmap.Width);
      int py = (int)(y * bitmap.Height);

      if (px >= bitmap.Width)
        px = 0;
      if (py >= bitmap.Height)
        py = bitmap.Height - 1;

      Color color = bitmap.GetPixel(px, py);

      return new ColorFloat(color); 

    }
  }
}
