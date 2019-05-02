//Copyright Maarten 't Hart 2019
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
  public class ErrorLog
  {
    public static List<Exception> exceptions = new List<Exception>();
    public static List<string> messages = new List<string>();
    public static void LogException(Exception exception, string message)
    {
      exceptions.Add(exception);
      messages.Add(message); 
    }
  }
}
