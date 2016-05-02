using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
  class Terminal
  {
    public string getMainMenu()
    {
      StringBuilder menu = new StringBuilder();
      menu.AppendLine("*********************************************************");
      menu.AppendLine("**  Welcome to Bangazon! Command Line Ordering System  **");
      menu.AppendLine("*********************************************************");
      menu.AppendLine("1. Create an account");
      menu.AppendLine("2. Create a payment option");
      menu.AppendLine("3. Order a product");
      menu.AppendLine("4. Complete an order");
      menu.AppendLine("5. See product popularity");
      menu.AppendLine("6. Leave Bangazon!");
      menu.Append("> ");
      return menu.ToString();
    }

    public string getCustomerName()
    {
      StringBuilder name = new StringBuilder();
      name.AppendLine("Enter customer name");
      name.Append("> ");
      return name.ToString();
    }
  }
}
