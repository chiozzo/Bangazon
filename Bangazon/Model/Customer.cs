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

      StringBuilder insertCommand = new StringBuilder();
      insertCommand.Append("INSERT INTO Customer (FirstName, LastName, StreetNumber, StreetName, City, State, ZipCode, PhoneNumber) VALUES (");
      insertCommand.Append("'" + this.FirstName + "'");
      insertCommand.Append(", ");
      insertCommand.Append("'" + this.LastName + "'");
      insertCommand.Append(", ");
      insertCommand.Append("'" + this.StreetNumber + "'");
      insertCommand.Append(", ");
      insertCommand.Append("'" + this.StreetName + "'");
      insertCommand.Append(", ");
      insertCommand.Append("'" + this.City + "'");
      insertCommand.Append(", ");
      insertCommand.Append("'" + this.State + "'");
      insertCommand.Append(", ");
      insertCommand.Append(this.ZipCode);
      insertCommand.Append(", ");
      insertCommand.Append(this.PhoneNumber);
      insertCommand.Append(")");

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
