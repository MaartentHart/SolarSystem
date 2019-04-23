using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class Shader
  {
    static public string[] Load(string FileName)
    {
      return File.ReadAllLines(FileName); 
    }
  }
}
