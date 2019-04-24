

// Copyright (C) 2016-2017 Luca Piccioni
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using OpenGL;

namespace HelloTriangle.ANGLE
{
  /// <summary>
  /// Hello triangle sample, using ANGLE for providing OpenGL ES on Windows OS.
  /// </summary>
  public partial class SampleForm : Form
  {
    SolarSystem.Shader shader;
    string uMVP = "uMVP";
    string aPosition = "aPosition";
    string aColor = "aColor";
    string aScale = "aScale"; 

    /// <summary>
    /// Construct a SampleForm.
    /// </summary>
    public SampleForm()
    {
      InitializeComponent();
    }

    private void SampleForm_Load(object sender, EventArgs e)
    {

    }

    private void RenderControl_ContextCreated(object sender, GlControlEventArgs e)
    {
      // Update Form caption
      Text = String.Format("Hello triangle with ANGLE (Version: {0})", Gl.GetString(StringName.Version));

      List<string> uniformNames = new List<string>();
      List<string> attributeNames = new List<string>();

      uniformNames.Add(uMVP);
      attributeNames.Add(aPosition);
      attributeNames.Add(aColor);
      attributeNames.Add(aScale); 

      //_Es2_Program_Location_uMVP = Gl.GetUniformLocation(_Es2_Program, "uMVP");
      //_Es2_Program_Location_aPosition = Gl.GetAttribLocation(_Es2_Program, "aPosition");
      //_Es2_Program_Location_aColor = Gl.GetAttribLocation(_Es2_Program, "aColor");
      
      shader = new SolarSystem.Shader("TestVec", "TestFrag", uniformNames, attributeNames);

      /*
      // Create resources
      StringBuilder infolog = new StringBuilder(1024);
      int infologLength;

      infolog.EnsureCapacity(1024);

      // Vertex shader
      uint vertexShader = Gl.CreateShader(ShaderType.VertexShader);
      Gl.ShaderSource(vertexShader, _Es2_ShaderVertexSource);
      Gl.CompileShader(vertexShader);
      Gl.GetShader(vertexShader, ShaderParameterName.CompileStatus, out int compiled);
      if (compiled == 0)
      {
        Gl.GetShaderInfoLog(vertexShader, 1024, out infologLength, infolog);
      }

      // Fragment shader
      uint fragmentShader = Gl.CreateShader(ShaderType.FragmentShader);
      Gl.ShaderSource(fragmentShader, _Es2_ShaderFragmentSource);
      Gl.CompileShader(fragmentShader);
      Gl.GetShader(fragmentShader, ShaderParameterName.CompileStatus, out compiled);
      if (compiled == 0)
      {
        Gl.GetShaderInfoLog(fragmentShader, 1024, out infologLength, infolog);
      }

      // Program
      _Es2_Program = Gl.CreateProgram();
      Gl.AttachShader(_Es2_Program, vertexShader);
      Gl.AttachShader(_Es2_Program, fragmentShader);
      Gl.LinkProgram(_Es2_Program);

      Gl.GetProgram(_Es2_Program, ProgramProperty.LinkStatus, out int linked);

      if (linked == 0)
      {
        Gl.GetProgramInfoLog(_Es2_Program, 1024, out infologLength, infolog);
      }

      _Es2_Program_Location_uMVP = Gl.GetUniformLocation(_Es2_Program, "uMVP");
      _Es2_Program_Location_aPosition = Gl.GetAttribLocation(_Es2_Program, "aPosition");
      _Es2_Program_Location_aColor = Gl.GetAttribLocation(_Es2_Program, "aColor");
      */  
  }

    private void RenderControl_Render(object sender, GlControlEventArgs e)
    {
      Control control = (Control)sender;

      Gl.Viewport(0, 0, control.Width, control.Height);
      Gl.Clear(ClearBufferMask.ColorBufferBit);

      shader.Render(); 
      //Gl.UseProgram(_Es2_Program);

      using (MemoryLock arrayPosition = new MemoryLock(_ArrayPosition))
      using (MemoryLock arrayColor = new MemoryLock(_ArrayColor))
      using (MemoryLock arrayScale = new MemoryLock(_ArrayScale))
      {
        Gl.VertexAttribPointer((uint)shader.Attributes[aPosition], 2, VertexAttribType.Float, false, 0, arrayPosition.Address);
        Gl.EnableVertexAttribArray((uint)shader.Attributes[aPosition]);

        Gl.VertexAttribPointer((uint)shader.Attributes[aColor], 3, VertexAttribType.Float, false, 0, arrayColor.Address);
        Gl.EnableVertexAttribArray((uint)shader.Attributes[aColor]);

        Gl.VertexAttribPointer((uint)shader.Attributes[aScale], 1, VertexAttribType.Float, false, 0, arrayScale.Address);
        Gl.EnableVertexAttribArray((uint)shader.Attributes[aScale]);

        Gl.UniformMatrix4f(shader.Uniforms[uMVP], 1, false, Matrix4x4f.Ortho2D(0.0f, 1.0f, 0.0f, 1.0f));

        Gl.DrawArrays(PrimitiveType.Triangles, 0, 3);
      }
    }

    private void RenderControl_ContextDestroying(object sender, OpenGL.GlControlEventArgs e)
    {
      shader.Destroy(); 
      /*
      if (_Es2_Program != 0)
        Gl.DeleteProgram(_Es2_Program);
      _Es2_Program = 0;
      */
    }

    //private uint _Es2_Program;

    //private int _Es2_Program_Location_aPosition;

    //private int _Es2_Program_Location_aColor;

    //private int _Es2_Program_Location_uMVP;


    //private readonly string[] _Es2_ShaderVertexSource = SolarSystem.Shader.Load("TestVec");
    //private readonly string[] _Es2_ShaderFragmentSource = SolarSystem.Shader.Load("TestFrag");

    /// <summary>
    /// Vertex position array.
    /// </summary>
    private static readonly float[] _ArrayPosition = new float[] {
      0.0f, 0.0f,
      0.5f, 1.0f,
      1.0f, 0.0f
    };

    /// <summary>
    /// Vertex color array.
    /// </summary>
    private static readonly float[] _ArrayColor = new float[] {
      1.0f, 0.0f, 0.0f,
      0.0f, 1.0f, 0.0f,
      0.0f, 0.0f, 1.0f
    };

    private static readonly float[] _ArrayScale = new float[]{
      0.5f,
      0.8f,
      1.0f
    };

  }
}
