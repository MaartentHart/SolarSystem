//Copyright (C) Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class TextureCache
  {
    bool useAlternative = false; 
    private IntPtr alternativeColorArray; 
    int VerticesCount { get; }
    int TileWidth { get; }
    int TileSize { get; }
    public Planet Planet { get; }

    public IntPtr AlternativeColorArray
    {
      get => alternativeColorArray;
      set
      {
        useAlternative = true;
        alternativeColorArray = value; 
      }
    }

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
      try
      {
        if (Load())
          return true;
      }
      catch
      {

      }
      return false; 
    }

    /// <summary>
    /// Creates a zipfile, containing 11 png's, which are the tiles of the texture on the geodesic grid
    /// The last png only contains the 2 polar pixels. 
    /// </summary>
    /// <param name="fileName"></param>
    public void Save(string fileName = "")
    {
      if (fileName == "")
        fileName = FileName;

      string directory = Path.GetDirectoryName(fileName); 

      if (!Directory.Exists(directory))
        Directory.CreateDirectory(directory);

      if (File.Exists(fileName))
        File.Delete(fileName); 

      using (ZipArchive archive = ZipFile.Open(fileName,ZipArchiveMode.Create))
      {
        for (int i = 0; i < 11; i++)
        {
          using (Bitmap bitmap = GetTile(i))
          using (MemoryStream source = new MemoryStream())
          {
            bitmap.Save(source, ImageFormat.Png);

            string entryName = i.ToString() + ".png";
            ZipArchiveEntry entry = archive.CreateEntry(entryName);
            using (Stream target = entry.Open())
            {
              byte[] png = source.ToArray();
              target.Write(png, 0, png.Length);
            }
          }
        }
      } 
    }

    /// <summary>
    /// Loads a zipfile, containing 11 png's, which are the tiles of the texture on the geodesic grid
    /// The last png only contains the 2 polar pixels. 
    /// </summary>
    /// <param name="fileName">The filename of the file to open, or empty to load the default cache.</param>
    public bool Load(string fileName = "", bool noThrow = false)
    {
      try
      {
        if (fileName == "")
          fileName = FileName;
        if (!File.Exists(fileName))
        {
          if (!noThrow)
            throw new Exception("File does not exist:\n" + fileName);
          return false;
        }

        Planet.InitializeColors(); 

        bool ok = true;
        using (ZipArchive archive = ZipFile.Open(fileName, ZipArchiveMode.Read))
        {
          for (int i = 0; i < 11; i++)
          {
            string entryName = i.ToString() + ".png";

            ZipArchiveEntry entry = archive.GetEntry(entryName);

            if (entry == null)
            {
              ok = false;
              continue;
            }
            using (Stream source = entry.Open())
            using (Bitmap bitmap = (Bitmap)Image.FromStream(source))
            {
              PaintTile(bitmap, i);
            }
          }
        }
        return ok;
      }
      catch
      {
        if (!noThrow)
          throw; 
        return false; 
      }
    }

    /// <summary>
    /// Gets a bitmap of the texture. 
    /// </summary>
    /// <param name="index">The index of the geodesic grid tiles (0-9) or the 2 polar pixels (10)</param>
    /// <returns></returns>
    public Bitmap GetTile(int index)
    {
      if (index < 11 && index>=0)
      {
        int width = TileWidth;
        int height = TileWidth;
        int size = TileSize;
        
        //the polar pixel tile. 
        if (index == 10)
        {
          width = 2;
          height = 1;
          size = 2; 
        }

        Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        IntPtr ptr = data.Scan0;

        unsafe
        {
          byte* t = (byte*)ptr.ToPointer();
          IntPtr planetColors = Planet.GetColors();
          if (useAlternative)
            planetColors = alternativeColorArray; 
          float* s = (float*)planetColors.ToPointer();
          s += TileSize * index * 4;

          for (int i = 0; i < size; i++, t += 4, s += 4)
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

    public void PaintTile(Bitmap bitmap, int index)
    {
      if (index >= 11 || index < 0)
        throw new IndexOutOfRangeException("Index must be between 0 and 10.");

      if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
        throw new Exception("Wrong pixelformat. Must be 32bpp ARGB");

      int width = TileWidth;
      int height = TileWidth;
      int size = TileSize;
      
      //the polar pixel tile. 
      if (index == 10)
      {
        if (bitmap.Height*bitmap.Width!=2)
          throw new Exception("Image has wrong dimensions to be used as a tile for this object.");

        width = bitmap.Width;
        height = bitmap.Height;
        size = 2;
      }

      if (bitmap.Width != width || bitmap.Height != height)
        throw new Exception("Image has wrong dimensions to be used as a tile for this object.");


      BitmapData data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      IntPtr ptr = data.Scan0;

      unsafe
      {
        byte* s = (byte*)ptr.ToPointer();
        IntPtr planetColors = Planet.GetColors();

        float* t = (float*)planetColors.ToPointer();
        t += TileSize * index * 4;

        for (int i = 0; i < size; i++, t += 4, s += 4)
        {
          t[0] = s[2] / 255.0f;
          t[1] = s[1] / 255.0f;
          t[2] = s[0] / 255.0f;
          t[3] = s[3] / 255.0f;
        }
      }
      bitmap.UnlockBits(data);
    }
  }
}
