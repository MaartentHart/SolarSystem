using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  public class Shader
  {
    static public List<string> notFoundShaderList = new List<string>();
    
    static public string[] Load(string ShaderName)
    {
      string fileName = @"Shaders\" + ShaderName + ".glsl";

      if (!File.Exists(fileName))
      {
        if (!notFoundShaderList.Contains(ShaderName))
        {
          MessageBox.Show("Cannot find shader " + fileName);
          notFoundShaderList.Add(ShaderName);
        }
        return new string[0];
      }

      return File.ReadAllLines(fileName); 
    }
  }
}
