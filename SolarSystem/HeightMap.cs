//Copyright Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  public class HeightMap
  {
    public bool Valid { get; private set; } = false;
    public double[] Heights { get; set; }

    public HeightMap(string fileName, bool messageNotExist = true)
    {
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

    public void Load(string fileName, bool messageNotExist = true)
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
            return;
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
        }
        catch (Exception ex)
        {
          MessageBox.Show("Error loading heightmap " + fileName + "\n" + ex.Message);
          Valid = false;
        }
      }
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
