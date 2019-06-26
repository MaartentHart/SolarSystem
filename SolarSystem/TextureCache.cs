using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class TextureCache
  {
    int VerticesCount { get; }
    int TileWidth { get; }
    int TileSize { get; }
    public Planet Planet { get; }
    string FileName
    {
      get
      {
        if (Planet.ActiveLayer.UseTexture)
        {
          Texture texture = Planet.ActiveLayer.Texture;
          return "Cache\\" + texture.Name + texture.Extension + ".cache.zip";
        }
        return "Cache\\" + Planet.ActiveLayer.Name + ".cache.zip";
      }
    }

    public TextureCache(Planet planet)
    {
      Planet = planet;
      VerticesCount = CoreDll.GeodesicGridVerticesCount(planet.Generation);
      TileWidth = 1 << planet.Generation;
      TileSize = TileWidth * TileWidth;
    }

    public bool TryLoad()
    {
      return false;
    }

    public void Save()
    {
      if (!System.IO.Directory.Exists("Cache\\"))
        System.IO.Directory.CreateDirectory("Cache\\");

      for (int i = 0; i<11; i++)
      {
        Bitmap bitmap = GetTile(i);
        bitmap.Save("Cache\\" + i.ToString() + ".png", ImageFormat.Png);
        bitmap.Dispose(); 
      }

      throw new NotImplementedException(); 
    }

    public Bitmap GetTile(int index)
    {
      if (index < 10 && index>=0)
      {
        Bitmap bitmap = new Bitmap(TileWidth, TileWidth, PixelFormat.Format32bppArgb);

        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, TileWidth, TileWidth), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        IntPtr ptr = data.Scan0;

        unsafe
        {
          byte* t = (byte*)ptr.ToPointer();
          IntPtr planetColors = Planet.GetColors();

          float* s = (float*)planetColors.ToPointer();
          s += TileSize * index * 4;

          for (int i = 0; i < TileSize; i++, t += 4, s += 4)
          {
            t[2] = (byte)(s[0] * 255);
            t[1] = (byte)(s[1] * 255);
            t[0] = (byte)(s[2] * 255);
            t[3] = (byte)(s[3] * 255);
          }
        }
        bitmap.UnlockBits(data);
        return bitmap;
      }
      if (index == 10)
      {
        Bitmap bitmap = new Bitmap(1, 2, PixelFormat.Format32bppArgb);

        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, 1, 2), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        IntPtr ptr = data.Scan0;

        unsafe
        {
          byte* t = (byte*)ptr.ToPointer();
          IntPtr planetColors = Planet.GetColors();

          float* s = (float*)planetColors.ToPointer();
          s += TileSize * index * 4;

          for (int i = 0; i < 2; i++, t += 4, s += 4)
          {
            t[2] = (byte)(s[0] * 255);
            t[1] = (byte)(s[1] * 255);
            t[0] = (byte)(s[2] * 255);
            t[3] = (byte)(s[3] * 255);
          }
        }
        bitmap.UnlockBits(data);
        return bitmap;
      }
      return null; 
    }

  }
}
