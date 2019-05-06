using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public static class CMemoryBlock
  {
    public static IntPtr Allocate(int size)
    {
      return Marshal.AllocHGlobal(size);
    }
    public static void Free(IntPtr ptr)
    {
      Marshal.FreeHGlobal(ptr); 
    }
  }

  public class CPoint3DArray : IDisposable
  {
    public bool Owner { get; private set; }
    public int Size { get; }
    public IntPtr Ptr { get; }

    public CPoint3DArray(int size)
    {
      Size = size;
      Ptr = CMemoryBlock.Allocate(size * 24);
      unsafe
      {
        Point3D* points = (Point3D*)Ptr.ToPointer();
        for (int i = 0; i < size; i++, points++)
          *points = new Point3D();
      }
      Owner = true;
    }

    public CPoint3DArray(int size, IntPtr sourcePtr, bool copy = true)
    {
      Size = size;
      if (copy)
      {
        Ptr = CMemoryBlock.Allocate(size * 24);
        unsafe
        {
          Point3D* points = (Point3D*)Ptr.ToPointer();
          Point3D* source = (Point3D*)sourcePtr.ToPointer();
          for (int i = 0; i < size; i++, points++, source++)
            *points = *source;
        }
        Owner = true;
      }
      else
      {
        Ptr = sourcePtr;
        Owner = false;
      }
    }

    public Point3D this[int index]
    {
      get
      {
        unsafe
        {
          if (index < 0 || index >= Size)
            throw new IndexOutOfRangeException();
          Point3D* points = (Point3D*)Ptr.ToPointer();
          return points[index];
        }
      }
      set
      {
        unsafe
        {
          if (index < 0 || index >= Size)
            throw new IndexOutOfRangeException();
          Point3D* points = (Point3D*)Ptr.ToPointer();
          points[index] = value;
        }
      }
    }

    public void CopyRange(CPoint3DArray source, int sourcePosition, int targetPosition, int count)
    {
      if (sourcePosition < 0 || sourcePosition + count > source.Size)
        throw new ArgumentOutOfRangeException();
      if (targetPosition < 0 || targetPosition + count > Size)
        throw new ArgumentOutOfRangeException();
      unsafe
      {
        Point3D* s = (Point3D*)source.Ptr.ToPointer() + sourcePosition;
        Point3D* t = (Point3D*)Ptr.ToPointer() + targetPosition;
        for (int i = 0; i < count; i++, s++, t++)
          *t = *s;
      }
    }

    public void Scale(double value)
    {
      unsafe
      {
        Point3D* p = (Point3D*)Ptr.ToPointer();
        for (int i = 0; i < Size; i++, p++)
          (*p) *= value;
      }
    }

    public void Move(Point3D value)
    {
      unsafe
      {
        Point3D* p = (Point3D*)Ptr.ToPointer();
        for (int i = 0; i < Size; i++, p++)
          (*p) += value;
      }
    }

    public void Dispose()
    {
      if (Owner)
        CMemoryBlock.Free(Ptr);
      Owner = false; 
    }
  }

  public class CIntArrray : IDisposable
  {
    public bool Owner { get; private set; }
    public int Size { get; }
    public IntPtr Ptr { get; }

    public CIntArrray(int size)
    {
      Size = size;
      Ptr = CMemoryBlock.Allocate(size * sizeof(int));
      unsafe
      {
        int* ints = (int*)Ptr.ToPointer();
        for (int i = 0; i < size; i++, ints++)
          *ints = 0;
      }
      Owner = true;
    }

    public CIntArrray(int size, IntPtr sourcePtr, bool copy = true)
    {
      Size = size;
      if (copy)
      {
        Ptr = Marshal.AllocHGlobal(size * sizeof(int));
        unsafe
        {
          int* ints = (int*)Ptr.ToPointer();
          int* source = (int*)sourcePtr.ToPointer();
          for (int i = 0; i < size; i++, ints++, source++)
            *ints = *source;
        }
        Owner = true;
      }
      else
      {
        Ptr = sourcePtr;
        Owner = false;
      }
    }

    public int this[int index]
    {
      get
      {
        unsafe
        {
          if (index < 0 || index >= Size)
            throw new IndexOutOfRangeException();
          int* ints = (int*)Ptr.ToPointer();
          return ints[index];
        }
      }
      set
      {
        unsafe
        {
          if (index < 0 || index >= Size)
            throw new IndexOutOfRangeException();
          int* ints = (int*)Ptr.ToPointer();
          ints[index] = value;
        }
      }
    }

    public void CopyRange(CIntArrray source, int sourcePosition, int targetPosition, int count)
    {
      if (sourcePosition < 0 || sourcePosition + count > source.Size)
        throw new ArgumentOutOfRangeException();
      if (targetPosition < 0 || targetPosition + count > Size)
        throw new ArgumentOutOfRangeException();
      unsafe
      {
        int* s = (int*)source.Ptr.ToPointer() + sourcePosition;
        int* t = (int*)Ptr.ToPointer() + targetPosition;
        for (int i = 0; i < count; i++, s++, t++)
          *t = *s;
      }
    }

    public void SetDefaultIndex()
    {
      unsafe
      {
        int* target = (int*)Ptr.ToPointer();
        for (int i = 0; i < Size; i++,target++)
          *target = i;
      }
    }

    public void Dispose()
    {
      if (Owner)
        CMemoryBlock.Free(Ptr);
      Owner = false; 
    }
  }

  public class CColorArrray : IDisposable
  {
    public bool Owner { get; private set; }
    public int Size { get; }
    public IntPtr Ptr { get; }

    public CColorArrray(int size)
    {
      Size = size;
      Ptr = CMemoryBlock.Allocate(size * 16);
      unsafe
      {
        ColorFloat* colors = (ColorFloat*)Ptr.ToPointer();
        for (int i = 0; i < size; i++, colors++)
          *colors = new ColorFloat();
      }
      Owner = true;
    }

    public CColorArrray(int size, IntPtr sourcePtr, bool copy = true)
    {
      Size = size;
      if (copy)
      {
        Ptr = CMemoryBlock.Allocate(size * 16);
        unsafe
        {
          ColorFloat* color = (ColorFloat*)Ptr.ToPointer();
          ColorFloat* source = (ColorFloat*)sourcePtr.ToPointer();
          for (int i = 0; i < size; i++, color++, source++)
            *color = *source;
        }
        Owner = true;
      }
      else
      {
        Ptr = sourcePtr;
        Owner = false;
      }
    }

    public ColorFloat this[int index]
    {
      get
      {
        unsafe
        {
          if (index < 0 || index >= Size)
            throw new IndexOutOfRangeException();
          ColorFloat* colors = (ColorFloat*)Ptr.ToPointer();
          return colors[index];
        }
      }
      set
      {
        unsafe
        {
          if (index < 0 || index >= Size)
            throw new IndexOutOfRangeException();
          ColorFloat* colors = (ColorFloat*)Ptr.ToPointer();
          colors[index] = value;
        }
      }
    }

    public void CopyRange(CColorArrray source, int sourcePosition, int targetPosition, int count)
    {
      if (sourcePosition < 0 || sourcePosition + count > source.Size)
        throw new ArgumentOutOfRangeException();
      if (targetPosition < 0 || targetPosition + count > Size)
        throw new ArgumentOutOfRangeException();
      unsafe
      {
        ColorFloat* s = (ColorFloat*)source.Ptr.ToPointer() + sourcePosition;
        ColorFloat* t = (ColorFloat*)Ptr.ToPointer() + targetPosition;
        for (int i = 0; i < count; i++, s++, t++)
          *t = *s;
      }
    }

    public void SetColor(ColorFloat color)
    {
      unsafe
      {
        ColorFloat* t = (ColorFloat*)Ptr.ToPointer();
        for (int i = 0; i < Size; i++, t++)
          *t = color;
      }
    }

    public void SetColorMap(ColorMap colorMap, CDoubleArray doubles)
    {
      if (doubles.Size != Size)
        throw new Exception("Array size mismatch.");

      unsafe
      {
        ColorFloat* t = (ColorFloat*)Ptr.ToPointer();
        double* d = (double*)doubles.Ptr.ToPointer(); 
        for (int i = 0; i < Size; i++, t++)
          *t = colorMap.GetColor(*d);
      }
    }

    public void SetColorMap(ColorMap colorMap, double[] doubles)
    {
      if (doubles.Length != Size)
        throw new Exception("Array size mismatch.");

      unsafe
      {
        ColorFloat* t = (ColorFloat*)Ptr.ToPointer();
        for (int i = 0; i < Size; i++, t++)
          *t = colorMap.GetColor(doubles[i]);
      }
    }

    public void Dispose()
    {
      if (Owner)
        CMemoryBlock.Free(Ptr);
      Owner = false; 
    }
  }

  public class CDoubleArray
   {
    public bool Owner { get; private set;  }
    public int Size { get; }
    public IntPtr Ptr { get; }

    public CDoubleArray(int size)
    {
      Size = size;
      Ptr = CMemoryBlock.Allocate(size * sizeof(double));
      unsafe
      {
        double* doubles = (double*)Ptr.ToPointer();
        for (int i = 0; i < size; i++, doubles++)
          *doubles = 0;
      }
      Owner = true;
    }

    public CDoubleArray(int size, IntPtr sourcePtr, bool copy = true)
    {
      Size = size;
      if (copy)
      {
        Ptr = CMemoryBlock.Allocate(size * sizeof(double));
        unsafe
        {
          double* doubles = (double*)Ptr.ToPointer();
          double* source = (double*)sourcePtr.ToPointer();
          for (int i = 0; i < size; i++, doubles++, source++)
            *doubles = *source;
        }
        Owner = true;
      }
      else
      {
        Ptr = sourcePtr;
        Owner = false;
      }
    }

    public double this[int index]
    {
      get
      {
        unsafe
        {
          if (index < 0 || index >= Size)
            throw new IndexOutOfRangeException();
          double* doubles = (double*)Ptr.ToPointer();
          return doubles[index];
        }
      }
      set
      {
        unsafe
        {
          if (index < 0 || index >= Size)
            throw new IndexOutOfRangeException();
          double* doubles = (double*)Ptr.ToPointer();
          doubles[index] = value;
        }
      }
    }

    public void CopyRange(CDoubleArray source, int sourcePosition, int targetPosition, int count)
    {
      if (sourcePosition < 0 || sourcePosition + count > source.Size)
        throw new ArgumentOutOfRangeException();
      if (targetPosition < 0 || targetPosition + count > Size)
        throw new ArgumentOutOfRangeException();
      unsafe
      {
        double* s = (double*)source.Ptr.ToPointer() + sourcePosition;
        double* t = (double*)Ptr.ToPointer() + targetPosition;
        for (int i = 0; i < count; i++, s++, t++)
          *t = *s;
      }
    }

    public void Dispose()
    {
      if (Owner)
        CMemoryBlock.Free(Ptr);
      Owner = false; 
    } 
  }
}
