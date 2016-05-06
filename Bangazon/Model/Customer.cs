using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bangazon
{
  public class Customer
  {
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StreetNumber { get; set; }
    public string StreetName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int ZipCode { get; set; }
    public double PhoneNumber { get; set; }

    public void insertCustomer()
    {
      string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Bangazon;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

      StringBuilder insertCommand = new StringBuilder()
        .Append("INSERT INTO Customer (FirstName, LastName, StreetNumber, StreetName, City, State, ZipCode, PhoneNumber) VALUES (")
        .Append("'" + this.FirstName + "'")
        .Append(", ")
        .Append("'" + this.LastName + "'")
        .Append(", ")
        .Append("'" + this.StreetNumber + "'")
        .Append(", ")
        .Append("'" + this.StreetName + "'")
        .Append(", ")
        .Append("'" + this.City + "'")
        .Append(", ")
        .Append("'" + this.State + "'")
        .Append(", ")
        .Append(this.ZipCode)
        .Append(", ")
        .Append(this.PhoneNumber)
        .Append(")");

      SqlConnection sqlConnection1 = new SqlConnection(connectionString);

      SqlCommand cmd = new SqlCommand();
      cmd.CommandType = System.Data.CommandType.Text;
      cmd.CommandText = insertCommand.ToString();
      cmd.Connection = sqlConnection1;

      sqlConnection1.Open();
      cmd.ExecuteNonQuery();
      sqlConnection1.Close();
    }
  }
}
