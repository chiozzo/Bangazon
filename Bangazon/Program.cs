using System;
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
      string stringInput = Console.ReadLine();
      int menuSelection = Convert.ToInt32(stringInput);
      switch (menuSelection)
      {
        case 1: Customer newCustomer = UI.createNewCustomer();
          // need to insert this new object into the DB.
          newCustomer.insertCustomer();
          break;
      }
    }
  }
}
