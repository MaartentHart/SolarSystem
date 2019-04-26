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
        Heights = new double[verticesCount];
      else if (Heights.Length != verticesCount)
        MessageBox.Show("Height map length mismathces the geodesic grid generation.");
    }

    public void Load(string fileName, bool messageNotExist = true)
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
    }
  }
}
