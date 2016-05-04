using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bangazon
{
  public class ProductOrder
  {
    private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Bangazon;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public int ProductOrderId { get; set; }
    public int CustomerId { get; set; }
    public int PaymentMethodId { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Completed { get; set; }

    public void insertProductOrder()
    {
      StringBuilder insertCommand = new StringBuilder();
      insertCommand.Append("INSERT INTO ProductOrder (CustomerId, ProductId) VALUES (");
      insertCommand.Append(this.CustomerId);
      insertCommand.Append(", ");
      insertCommand.Append(this.ProductId);
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
