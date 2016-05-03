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

    public Customer createNewCustomer()
    {
      // Customer Name
      Customer newCustomer = new Customer();
      Console.Write(this.getCustomerName());
      string customerName = Console.ReadLine();
      string[] customerNameArray = customerName.Split(' ');
      newCustomer.FirstName = customerNameArray[0];
      newCustomer.LastName = customerNameArray[1];

      // Customer Address
      Console.Write(this.getCustomerStreetAddress());
      string customerAddress = Console.ReadLine();
      string[] customerAddressArray = customerAddress.Split(' ');
      newCustomer.StreetNumber = customerAddressArray[0];
      StringBuilder streetName = new StringBuilder();
      for (int i = 1; i < customerAddressArray.Length; i++)
      {
        streetName.Append(customerAddressArray[i]);
        streetName.Append(" ");
      }
      newCustomer.StreetName = streetName.ToString();

      // Customer City
      Console.Write(this.getCustomerCity());
      newCustomer.City = Console.ReadLine();

      // Customer State
      Console.Write(this.getCustomerState());
      newCustomer.State = Console.ReadLine();

      // Customer Zip Code
      Console.Write(this.getCustomerZipCode());
      string customerZipCode = Console.ReadLine();
      newCustomer.ZipCode = Convert.ToInt32(customerZipCode);

      // Customer Phone Number
      Console.Write(this.getCustomerPhoneNumber());
      string customerPhoneNumber = Console.ReadLine();
      newCustomer.PhoneNumber = Convert.ToDouble(customerPhoneNumber);

      return newCustomer;
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
