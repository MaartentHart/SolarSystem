//Copyright Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL; 

namespace SolarSystem
{
  public interface IRenderable
  {
    float PointSize { set; }
    bool On { get; set; }
    string Name { get; set; }
    bool Changed { get; }

    void Render(Camera camera);
    void SetColorMap(ColorMap colorMap);

    //is called when the time updates. 
    void TimeUpdate();
  }

  public class CRenderGeometry
  {
    public enum RenderMode
    {
      triangles,
      points
    }

    public IntPtr vertices;
    public IntPtr indices;
    public IntPtr colors;
    public IntPtr normals; 
    public bool enableColors = false;
    public bool enableNormals = false; 

    public int verticesCount;
    public int indicesCount;
    public RenderMode renderMode;
    public float pointSize = 2;
    public bool Transparent { get; set; } = false; 

    public void Render(bool useLight)
    {
      switch (renderMode)
      {
        case RenderMode.triangles:
          RenderTriangles(useLight);
          break;
        case RenderMode.points:
          RenderPoints();
          break; 
      }
    }

    private void RenderPoints()
    {
      Gl.Disable(EnableCap.NormalArray);
      Gl.EnableClientState(EnableCap.VertexArray);
      Gl.VertexPointer(3, VertexPointerType.Double, 0, vertices);
      Gl.Disable(EnableCap.Lighting);
      if (enableColors)
      {
        Gl.EnableClientState(EnableCap.ColorArray);
        Gl.ColorPointer(4, ColorPointerType.Float, 0, colors); 
      }
      else
      {
        Gl.DisableClientState(EnableCap.ColorArray); 
      }
      Gl.PointSize(pointSize);
      Gl.DrawElements(PrimitiveType.Points, verticesCount, DrawElementsType.UnsignedInt, indices);
    }

    private void RenderTriangles(bool useLight)
    {
      if (Transparent)
      {
        Gl.Enable(EnableCap.Blend);
        Gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
      }
      //else
      //{
      //  Gl.Disable(EnableCap.Blend);
      //}
      Gl.EnableClientState(EnableCap.VertexArray);
      Gl.VertexPointer(3, VertexPointerType.Double, 0, vertices);
      if (enableNormals && useLight)
      {
        Gl.Enable(EnableCap.Lighting);
        //Gl.Enable(EnableCap.Normalize); 
        Gl.NormalPointer(NormalPointerType.Double, 0, normals);
        Gl.EnableClientState(EnableCap.NormalArray);
      }
      else
      {
        Gl.Disable(EnableCap.Lighting);
        Gl.DisableClientState(EnableCap.NormalArray);
      }

      if (enableColors)
      {
        Gl.Enable(EnableCap.ColorMaterial);
        Gl.EnableClientState(EnableCap.ColorArray);
        Gl.ColorPointer(4, ColorPointerType.Float, 0, colors);
      }
      else
        Gl.DisableClientState(EnableCap.ColorArray);

      Gl.DisableVertexAttribArray(2);

      Gl.DrawElements(PrimitiveType.Triangles, indicesCount, DrawElementsType.UnsignedInt, indices);
      //if (Transparent)
      //  Gl.Disable(EnableCap.Blend);
    }

    public void SetGeodesicGrid(int generation)
    {
      vertices = CoreDll.GeodesicGridVertices(generation);
      verticesCount = CoreDll.GeodesicGridVerticesCount(generation);

      indices = CoreDll.GeodesicGridIndices(generation);
      indicesCount = CoreDll.GeodesicGridIndicesCount(generation); 

      normals = vertices;
      enableNormals = true;

      renderMode = RenderMode.triangles; 
    }

    public void SetTest()
    {
      vertices = CoreDll.TestVertices();
      verticesCount = CoreDll.TestVerticesCount();

      indices = CoreDll.TestIndices();
      indicesCount = CoreDll.TestIndicesCount();
      renderMode = RenderMode.triangles;
    }
  }

  public class CRenderableObject : IRenderable, IPositionObject
  {
    private bool changed = false; 
    public string Name { get; set; } = "Default";
    public bool On { get; set; } = true;
    public Transform Transform {get;set;} = new Transform();
    public bool UseLight { get; set; } = true; 

    public Point3D Position
    {
      get => Transform.Position;
      set
      {
        Transform.Position = value;
        Changed = true; 
      }
    }

    public Point3D Scale
    {
      get => Transform.Scale;
      set
      {
        Transform.Scale = value;
        Changed = true;
      }
    }

    /*
    public CelestialRotation Rotation
    {
      get =>  (CelestialRotation) Transform.Rotation;
      set
      {
        Transform.Rotation = value;
        Changed = true;
      }
    }*/

    public CRenderGeometry RenderGeometry { get; set; } = new CRenderGeometry();
    public bool Changed {
      get
      {
        bool ret = changed;
        changed = false;
        return ret; 
      }
      set => changed = value;
    }

    public float PointSize { get; set; }

    public void Render(Camera camera)
    {
      using (ApplyTransform apply = new ApplyTransform(Transform, camera.IgnoreObjectPositions))
      {
        RenderGeometry.Render(UseLight);
      }   
    }

    public void SetColorMap(ColorMap colorMap)
    {
      throw new NotImplementedException();
    }

    public void TimeUpdate()
    {
 
    }
  }

  public class GlPushPop : IDisposable
  {
    private readonly bool active;

    public GlPushPop(bool active = true)
    {
      this.active = active; 
      if (active)
        Gl.PushMatrix();
    }

    public void Dispose()
    {
      if (active)
       Gl.PopMatrix();
    }
  }

  public class Mesh : IRenderable
  {
    private bool changed = false; 
    private bool on = true;

    public int[] indices;
    public float[] colors;
    public float[] uv; 
    public double[] vertices;
    public double[] normals;
    public uint textureID;

    public bool On
    {
      get => on;
      set
      {
        Changed = true;
        on = value; 
      }
    }
    public string Name { get; set; } = "Mesh";
    public bool Changed { get
      {
        bool ret = changed;
        changed = false;
        return ret; 
      }

      set => changed = value; 
    }
    public Shader Shader { get; set; }
    public Transform Transform { get; set; } = new Transform();

    public List<IRenderable> Children { get; set; } = new List<IRenderable>();
    public bool Transparent { get; set; } = false;
    public float PointSize { get; set; }

    public void Render(Camera camera)
    {
      if (!On)
        return;

      if (Transparent)
      {
        Gl.Enable(EnableCap.Blend);
        Gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
      }
      else
      {
        Gl.Disable(EnableCap.Blend);
      }

      using (ApplyTransform apply = new ApplyTransform(Transform))
      {
        if (!(vertices == null || indices == null || vertices.Length == 0 || indices.Length == 0))
        {
          Gl.EnableClientState(EnableCap.VertexArray);
          Gl.VertexPointer(3, VertexPointerType.Double, 0, vertices);
          if (normals != null && normals.Length == vertices.Length)
          {
            Gl.Enable(EnableCap.Lighting);
            Gl.NormalPointer(NormalPointerType.Double, 0, normals);
            Gl.EnableClientState(EnableCap.NormalArray);
          }
          else
          {
            Gl.DisableClientState(EnableCap.NormalArray);
          }

          if (colors != null && colors.Length / 4 == vertices.Length / 3)
          {
            Gl.Enable(EnableCap.ColorMaterial);
            Gl.EnableClientState(EnableCap.ColorArray);
            Gl.ColorPointer(4, ColorPointerType.Float, 0, colors);
          }
          else
            Gl.DisableClientState(EnableCap.ColorArray);
          MemoryLock uvLock = new MemoryLock(uv);
          {
            if (uv != null && uv.Length / 2 == vertices.Length / 3)
            {
              Gl.VertexAttribPointer(2, 2, VertexAttribType.Float, false, 0, uvLock.Address);
              Gl.EnableVertexAttribArray(2);
              Gl.BindTexture(TextureTarget.Texture2d, textureID);
            }

            Gl.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, indices);
          }
        }

        foreach (IRenderable child in Children)
        {
          child.Render(camera); 
        }
      }
      if (Transparent)
        Gl.Disable(EnableCap.Blend);
    }

    public Point3D[] GetVertices() => Point3D.ToPointArray(vertices); 

    public void InitializeAsTexture(string fileName)
    { 
      //https://learnopengl.com/code_viewer_gh.php?code=src/1.getting_started/4.1.textures/textures.cpp
      Shader = new Shader("TextureVertex", "TextureFragment");
      using (Image testImage = Image.FromFile(fileName))
      {
        using (Bitmap bitmap = new Bitmap(testImage))
        {
          textureID = Gl.GenTexture();
          Gl.BindTexture(TextureTarget.Texture2d, textureID);

          System.Drawing.Imaging.BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
          IntPtr ptr = data.Scan0;
          Gl.TexImage2D(TextureTarget.Texture2d, 0, InternalFormat.Rgba, bitmap.Width, 512, bitmap.Height, PixelFormat.Rgba, PixelType.UnsignedByte, ptr);
          bitmap.UnlockBits(data);
          
          vertices = new double[]
          {
              0,0,0,
              1,0,0,
              0,1,0,
              1,1,0
          };
          indices = new int[]
          {
              0,1,2,
              3,2,1
          };
          colors = new float[]
          {
              1,1,1,1,
              1,1,1,1,
              1,1,1,1,
              1,1,1,1
          };
          uv = new float[]
          {
              0,0,
              1,0,
              0,1,
              1,1
          };
        }
        throw new NotImplementedException(); 
      }
    }    

    public void SetColor(ColorFloat color)
    {
      int length = vertices.Length/3; 
      colors = new float[length*4];
      for (int i =0; i<length;i++)
      {
        int j = i * 4;
        colors[j++] = color.R;
        colors[j++] = color.G;
        colors[j++] = color.B;
        colors[j++] = color.A;
      }
    }  

    public void SetColorMap(ColorMap colorMap)
    {
      throw new NotImplementedException();
    }

    public void TimeUpdate()
    {
      
    }
  }
}
