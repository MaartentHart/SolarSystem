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
      TextureVertex textureVertex = new TextureVertex(vertex, rotation); 

      int px = textureVertex.Px(bitmap.Width);
      int py = textureVertex.Py(bitmap.Height); 

      Color color = bitmap.GetPixel(px, py);

      return new ColorFloat(color); 

    }
  }

  public class TextureVertex
  {
    public double rotation = 0; 
    public double x;
    public double y;

    public int Px(int width)
    {
      int px = (int)(x * width);
      if (px >= width)
        px = 0;
      return px; 
    }

    public int Py(int height)
    {
      int py = (int)(y * height);
      if (py >= height)
        py = height - 1;
      return py;
    }

    public TextureVertex(Point3D vertex, double rotation = 0, bool invertZ = false)
    {
      if (invertZ)
        vertex.z = -vertex.z;
      y = (1 - (Math.Asin(vertex.z) + Math.PI / 2) / Math.PI);
      x = (Math.Atan2(vertex.y, vertex.x) + Math.PI) / (Math.PI * 2);
      x += rotation;
      while (x >= 1)
        x -= 1;
      while (x < 0)
        x += 1;
    }
  }
}
