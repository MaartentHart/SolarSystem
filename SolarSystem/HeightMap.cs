//Copyright Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SolarSystem
{
  public class HeightMap
  {
    public bool Valid { get; private set; } = false;
    public double[] Heights { get; set; }

    public Planet Parent { get;  } 

    public HeightMap(string fileName, Planet planet, bool messageNotExist = true)
    {
      Parent = planet; 
      Load(fileName, messageNotExist);
    }

    public HeightMap(SolarSystemPlanet planet, int generation)
    {
      Load(@"Resource\" + planet.ToString() + ".map", false);

      int verticesCount = CoreDll.GeodesicGridVerticesCount(generation);

      if (Heights.Length == 0)
        Valid = false;
      else if (Heights.Length != verticesCount)
        Valid = false;
    }

    public bool Load(string fileName, bool messageNotExist = true)
    {
      string extension = Path.GetExtension(fileName).ToLower();
      if (extension == ".map")
      {
        try
        {
          if (!File.Exists(fileName))
          {
            Heights = new double[0];
            if (messageNotExist)
              MessageBox.Show(fileName + " does not exist.", "Error.");
            return false;
          }

          FileInfo fileInfo = new FileInfo(fileName);
          long arrayLength = fileInfo.Length / 8;
          Heights = new double[arrayLength];

          using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
          {
            for (int i = 0; i < arrayLength; i++)
            {
              Heights[i] = reader.ReadDouble();
            }
          }
          Valid = true;
          return true; 
        }
        catch (Exception ex)
        {
          MessageBox.Show("Error loading heightmap " + fileName + "\n" + ex.Message);
          Valid = false;
          return false; 
        }
      }
      else if (extension == ".tif")
      {
        return LoadFromTif(fileName);
      }
      else
      {
        throw new Exception("File type " + extension + " not supported.");
      }

    }

    private bool LoadFromTif(string fileName)
    {
      byte[] bytes;
      int size;
      int bytesPerPixel = 2;
      int width;
      int height;

      using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
      {
        var tiffDecoder = new TiffBitmapDecoder(
            stream,
            BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreImageCache,
            BitmapCacheOption.None);
        
        var firstFrame = tiffDecoder.Frames[0];

        PixelFormat pixelFormat = firstFrame.Format;

        if (pixelFormat!=PixelFormats.Gray16)
        {
          MessageBox.Show("Only PixelFormat Gray16 is supported. This image has "+pixelFormat.ToString());
          return false; 
        }

        var convertedBitmap = new FormatConvertedBitmap(firstFrame, PixelFormats.Gray16, null, 0);
        width = convertedBitmap.PixelWidth;
        height = convertedBitmap.PixelHeight;
        //MessageBox.Show("Width: " + width.ToString() + "\nHeight: " + height.ToString());
        size = width * height;

        bytes = new byte[size * bytesPerPixel];
        convertedBitmap.CopyPixels(bytes, width * bytesPerPixel, 0);
      }
      Int16[] ints = new Int16[size];
      Buffer.BlockCopy(bytes, 0, ints, 0, size * bytesPerPixel);
      bytes = null;
      unsafe
      {
        int verticesCount = CoreDll.GeodesicGridVerticesCount(Parent.Generation);
        IntPtr vertices = CoreDll.GeodesicGridVertices(Parent.Generation);

        Point3D* vertex = (Point3D*)vertices.ToPointer();
        Heights = new double[verticesCount]; 

        for (int i = 0; i < verticesCount; i++,  vertex++)
          Heights[i] = Convert.ToDouble(GetHeight(ints, width, height, *vertex));
      }
      Valid = true;
      return true; 
    }

    
    private Int16 GetHeight(Int16[] ints, int width, int height, Point3D vertex)
    {
      TextureVertex textureVertex = new TextureVertex(vertex);
      int px = textureVertex.Px(width);
      int py = textureVertex.Py(height);
      int index = py * width + px;
      return ints[index]; 
    }

    public void Save(string fileName)
    {
      if (!Valid)
        return;

      int arrayLength = Heights.Length;
      using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(fileName)))
        for (int i = 0; i < arrayLength; i++)
          writer.Write(Heights[i]);
    }
  }
}
