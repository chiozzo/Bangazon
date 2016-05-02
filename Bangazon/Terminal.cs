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

    public string getCustomerStreetAddress()
    {
      StringBuilder addy = new StringBuilder();
      addy.AppendLine("Enter street address");
      addy.Append("> ");
      return addy.ToString();
    }

    public string getCustomerCity()
    {
      StringBuilder city = new StringBuilder();
      city.AppendLine("Enter city");
      city.Append("> ");
      return city.ToString();
    }

    public string getCustomerState()
    {
      StringBuilder state = new StringBuilder();
      state.AppendLine("Enter state");
      state.Append("> ");
      return state.ToString();
    }

    public string getCustomerZipCode()
    {
      StringBuilder zip = new StringBuilder();
      zip.AppendLine("Enter postal code");
      zip.Append("> ");
      return zip.ToString();
    }

    public string getCustomerPhoneNumber()
    {
      StringBuilder phone = new StringBuilder();
      phone.AppendLine("Enter phone number");
      phone.Append("> ");
      return phone.ToString();
    }
  }
}
