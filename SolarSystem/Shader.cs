using OpenGL;
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

    public StringBuilder infolog = new StringBuilder(1024);
    public int infologLength; 
    static public List<string> notFoundShaderList = new List<string>();

    private uint Program { get; set; }

    /// <summary>
    /// The uniform locations of the given uniforms.
    /// </summary>
    public Dictionary<string, int> Uniforms { get; } = new Dictionary<string, int>();

    /// <summary>
    /// The attribute locations of the given attributes. 
    /// </summary>
    public Dictionary<string, int> Attributes { get; } = new Dictionary<string, int>();

    /// <summary>
    ///call the constructor in the ContextCreated event.
    /// </summary>
    /// <param name="vertexShaderName">the vertex shader name x in Shaders\x.glsl</param>
    /// <param name="fragmentShaderName">the fragment shader name x in Shaders\x.glsl</param>
    public Shader(string vertexShaderName, string fragmentShaderName, List<string> uniformNames = null, List<string> attributeNames = null)
    {
      if (uniformNames == null)
        uniformNames = new List<string>();
      if (attributeNames == null)
        attributeNames = new List<string>(); 

      infolog.EnsureCapacity(1024);
      uint vertexShader = Gl.CreateShader(ShaderType.VertexShader);
      Gl.ShaderSource(vertexShader, Load(vertexShaderName));
      Gl.CompileShader(vertexShader);
      Gl.GetShader(vertexShader, ShaderParameterName.CompileStatus, out int compiled);
      if (compiled == 0)
      {
        Gl.GetShaderInfoLog(vertexShader, 1024, out infologLength, infolog);
      }

      // Fragment shader
      uint fragmentShader = Gl.CreateShader(ShaderType.FragmentShader);
      Gl.ShaderSource(fragmentShader, Load(fragmentShaderName));
      Gl.CompileShader(fragmentShader);
      Gl.GetShader(fragmentShader, ShaderParameterName.CompileStatus, out compiled);
      if (compiled == 0)
      {
        Gl.GetShaderInfoLog(fragmentShader, 1024, out infologLength, infolog);
      }

      Program = Gl.CreateProgram();
      Gl.AttachShader(Program, vertexShader);
      Gl.AttachShader(Program, fragmentShader);
      Gl.LinkProgram(Program);

      Gl.GetProgram(Program, ProgramProperty.LinkStatus, out int linked);

      if (linked == 0)
      {
        Gl.GetProgramInfoLog(Program, 1024, out infologLength, infolog);
      }

      foreach (string uniformName in uniformNames)
      {
        int location = Gl.GetUniformLocation(Program, uniformName);
        Uniforms[uniformName] = location; 
      }

      foreach (string attributeName in attributeNames)
      {
        int location = Gl.GetAttribLocation(Program, attributeName);
        Attributes[attributeName] = location; 
      }
    }

    /// <summary>
    /// Call this on the event ContextDestroying
    /// </summary>
    public void Destroy()
    {
      if (Program != 0)
        Gl.DeleteProgram(Program);
      Program = 0; 
    }

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

    /// <summary>
    /// Call this directly after the Gl.Viewport / Gl.Clear calls.  
    /// </summary>
    public void Render()
    {
      Gl.UseProgram(Program); 
    }

  }
}
