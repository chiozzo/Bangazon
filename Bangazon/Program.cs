﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
  class Program
  {
    static void Main(string[] args)
    {
      Terminal UI = new Terminal();
      Console.Write(UI.getMainMenu());
      Console.Read();
    }
  }
}
