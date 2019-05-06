using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class CPoint3DArray : IDisposable
  {
    public bool Owner { get; }
    public int Size { get; }
    public IntPtr Ptr { get; }

    public CPoint3DArray(int size)
    {
      Size = size; 
      Ptr = Marshal.AllocHGlobal(size * 24);
      unsafe
      {
        Point3D* points = (Point3D*) Ptr.ToPointer();
        for (int i=0; i<size;i++,points++)
          *points = new Point3D(); 
      }
      Owner = true; 
    }

    public CPoint3DArray(int size, IntPtr sourcePtr, bool copy = true)
    {
      Size = size; 
      if (copy)
      {
        Ptr = Marshal.AllocHGlobal(size * 24);
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
        Point3D* s = (Point3D*)source.Ptr.ToPointer()+sourcePosition;
        Point3D* t = (Point3D*)Ptr.ToPointer() + targetPosition;
        for (int i = 0; i<count; i++, s++, t++)
          *s = *t; 
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
        Marshal.FreeHGlobal(Ptr); 
    }
  }


  public class CIntArrray : IDisposable
  {
    public bool Owner { get; }
    public int Size { get; }
    public IntPtr Ptr { get; }

    public CIntArrray(int size)
    {
      Size = size;
      Ptr = Marshal.AllocHGlobal(size * sizeof(int));
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
          int* ints  = (int*)Ptr.ToPointer();
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

    public void CopyRange(CPoint3DArray source, int sourcePosition, int targetPosition, int count)
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
          *s = *t;
      }
    }

    public void SetDefaultIndex()
    {
      unsafe
      {
        int* target = (int*)Ptr.ToPointer();
        for (int i = 0; i < Size; i++)
          *target = i; 
      }
    }
    public void Dispose()
    {
      if (Owner)
        Marshal.FreeHGlobal(Ptr);
    }
  }
}
