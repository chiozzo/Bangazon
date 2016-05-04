using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bangazon
{
  public class PaymentMethod
  {
    public int PaymentMethodId { get; set; }
    public int CustomerId { get; set; }
    public string PaymentType { get; set; }
    public double AccountNumber { get; set; }

    public void insertPaymentMethod()
    {
      string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Bangazon;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

      StringBuilder insertCommand = new StringBuilder();
      insertCommand.Append("INSERT INTO PaymentMethod (CustomerId, PaymentType, AccountNumber) VALUES (");
      insertCommand.Append(this.CustomerId);
      insertCommand.Append(", ");
      insertCommand.Append("'" + this.PaymentType + "'");
      insertCommand.Append(", ");
      insertCommand.Append(this.AccountNumber);
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
