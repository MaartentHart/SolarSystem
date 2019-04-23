using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class StringValueAttribute : Attribute
  {
    public string Value { get; }

    public StringValueAttribute(string value)
    {
      Value = value;
    }
  }
}
