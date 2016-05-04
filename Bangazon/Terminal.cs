using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bangazon
{
  class Terminal
  {
    private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Bangazon;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
      menu.AppendLine("Type 'exit' to leave Bangazon");
      menu.Append("> ");
      return menu.ToString();
    }

    public Customer createNewCustomer()
    {
      Customer newCustomer = new Customer();

      // Customer Name
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

    public string getCustomerOptions()
    {
      StringBuilder queryCommand = new StringBuilder();
      queryCommand.Append("SELECT CustomerId, Firstname + ' ' + LastName AS FullName FROM Customer");

      StringBuilder customerOptions = new StringBuilder();
      customerOptions.AppendLine("Which customer?");

      SqlConnection connection = new SqlConnection(connectionString);
      SqlCommand cmd = new SqlCommand(queryCommand.ToString(), connection);
      connection.Open();
      SqlDataReader reader = cmd.ExecuteReader();
      // Check is the reader has any rows at all before starting to read.
      if (reader.HasRows)
      {
        // Read advances to the next row.
        while (reader.Read())
        {
          customerOptions.AppendLine(reader[0] + ". " + reader[1]);
        }
        customerOptions.Append("> ");
      }
      return customerOptions.ToString();
    }

    public PaymentMethod createPaymentMethod()
    {
      PaymentMethod newPaymentMethod = new PaymentMethod();

      Console.Write(this.getCustomerOptions());
      string customerForPaymentMethod = Console.ReadLine();
      newPaymentMethod.CustomerId = Convert.ToInt32(customerForPaymentMethod);
      Console.Write(this.getNewPaymentType());
      newPaymentMethod.PaymentType = Console.ReadLine();
      Console.Write(this.getNewAccountNumber());
      string accountNumber = Console.ReadLine();
      newPaymentMethod.AccountNumber = Convert.ToDouble(accountNumber);
      return newPaymentMethod;
    }

    public string getNewPaymentType()
    {
      StringBuilder payment = new StringBuilder();
      payment.AppendLine("Enter payment type (e.g.AmEx, Visa, MasterCard, Discover)");
      payment.Append("> ");
      return payment.ToString();
    }

    public string getNewAccountNumber()
    {
      StringBuilder account = new StringBuilder();
      account.AppendLine("Enter account number");
      account.Append("> ");
      return account.ToString();
    }

    /** PRODUCTS SECTION **/

    public string showProductsToOrder()
    {
      StringBuilder queryCommand = new StringBuilder();
      queryCommand.Append("SELECT ProductId, Name, Price FROM Product");

      StringBuilder productOptions = new StringBuilder();
      productOptions.AppendLine("Here is a list of our heroes you can order:");

      SqlConnection connection = new SqlConnection(connectionString);
      SqlCommand cmd = new SqlCommand(queryCommand.ToString(), connection);
      connection.Open();
      SqlDataReader reader = cmd.ExecuteReader();
      // Check if the reader has any rows at all before starting to read.
      if (reader.HasRows)
      {
        // Read advances to the next row.
        while (reader.Read())
        {
          productOptions.AppendLine(reader[0] + ". " + reader[1]);
          productOptions.AppendLine("    (" + reader[2] + ")");
        }
        productOptions.Append("0. BACK TO MAIN MENU");
        productOptions.Append("> ");
      }
      return productOptions.ToString();
    }

    public string getCustomerOrderSummary(int CustomerId)
    {
      StringBuilder queryCommand = new StringBuilder();
      queryCommand.Append("SELECT Product.Name, Product.Price ");
      queryCommand.Append("FROM ProductOrder ");
      queryCommand.Append("LEFT JOIN Product ON ProductOrder.ProductId = Product.ProductId ");
      queryCommand.Append("WHERE ProductOrder.CustomerId = " + CustomerId);
      queryCommand.Append(" AND ProductOrder.Completed = 0");

      StringBuilder orderSummary = new StringBuilder();
      orderSummary.Append("These heroes can rush your way to rescue you for a nominal fee of $");

      SqlConnection connection = new SqlConnection(connectionString);
      string stringQuery = queryCommand.ToString();
      SqlCommand cmd = new SqlCommand(stringQuery, connection);
      connection.Open();
      SqlDataReader reader = cmd.ExecuteReader();

      StringBuilder orderedHeroes = new StringBuilder();
      if (reader.HasRows)
      {
        decimal productOrderTotal = 0.0M;
        while (reader.Read())
        {
          decimal thisPrice = (decimal)reader[1];
          productOrderTotal +=thisPrice;
          orderedHeroes.AppendLine(reader[0].ToString());
        }
        string stringOrderTotal = Convert.ToString(productOrderTotal);
        orderSummary.Append(stringOrderTotal);
        orderSummary.AppendLine(":");
      }
      else
      {
        return "If you don't need to be rescued by anyone, what exactly are you trying to buy?";
      }
      orderSummary.Append(orderedHeroes.ToString());

      return orderSummary.ToString();
    }
    
    public string getPaymentOptions(int CustomerId)
    {
      StringBuilder queryCommand = new StringBuilder();
      queryCommand.Append("SELECT PaymentMethodId, PaymentType ");
      queryCommand.Append("FROM PaymentMethod ");
      queryCommand.Append("WHERE CustomerId = " + CustomerId);

      SqlConnection connection = new SqlConnection(connectionString);
      string stringQuery = queryCommand.ToString();
      SqlCommand cmd = new SqlCommand(stringQuery, connection);
      connection.Open();
      SqlDataReader reader = cmd.ExecuteReader();

      StringBuilder paymentOptions = new StringBuilder();
      paymentOptions.AppendLine("Please select your payment method.");

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          paymentOptions.AppendLine(reader[0] + ". " + reader[1]);
        }
      }

      paymentOptions.Append("> ");
      return paymentOptions.ToString();
    }

    public void completeProductOrders(int selectedPaymentMethod, int CustomerId)
    {
      StringBuilder updateCommand = new StringBuilder();
      updateCommand.Append("UPDATE ProductOrder ");
      updateCommand.Append("SET Completed = 1, PaymentMethodId = " + selectedPaymentMethod);
      updateCommand.Append("WHERE CustomerId = " + CustomerId);

      SqlConnection sqlConnection1 = new SqlConnection(connectionString);

      SqlCommand cmd = new SqlCommand();
      cmd.CommandType = System.Data.CommandType.Text;
      cmd.CommandText = updateCommand.ToString();
      cmd.Connection = sqlConnection1;

      sqlConnection1.Open();
      cmd.ExecuteNonQuery();
      sqlConnection1.Close();
    }

    public string getProductPopularity()
    {
      StringBuilder queryCommand = new StringBuilder();
      queryCommand.Append("SELECT ");
      queryCommand.Append("Product.Name, ");
      queryCommand.Append("Count(ProductOrder.ProductOrderId) as CountOfOrders, ");
      queryCommand.Append("Count(DISTINCT ProductOrder.CustomerId) as CountOfCustomers,");
      queryCommand.Append("Sum(Product.Price) as TotalRevenue ");
      queryCommand.Append("FROM ProductOrder ");
      queryCommand.Append("LEFT JOIN Product ON ProductOrder.ProductId = Product.ProductId ");
      queryCommand.Append("WHERE ProductOrder.Completed = 1 ");
      queryCommand.Append("GROUP BY Product.Name, ProductOrder.CustomerId");

      SqlConnection connection = new SqlConnection(connectionString);
      string stringQuery = queryCommand.ToString();
      SqlCommand cmd = new SqlCommand(stringQuery, connection);
      connection.Open();
      SqlDataReader reader = cmd.ExecuteReader();

      StringBuilder popularity = new StringBuilder();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          //AA Batteries ordered 10 times by 2 customers for total revenue of $99.90
          popularity.Append(reader[0]);
          popularity.Append(" ordered ");
          popularity.Append(reader[1]);
          popularity.Append(" times by ");
          popularity.Append(reader[2]);
          popularity.Append(" customers for a total revenue of $");
          popularity.Append(reader[3]);
          popularity.AppendLine(".");
        }
      }

      return popularity.ToString();
    }

  }
}
