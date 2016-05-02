using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
  class Customer
  {
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string StreetNumber { get; set; }
    public string StreetName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int ZipCode { get; set; }
    public double PhoneNumber { get; set; }

    public void insertCustomer()
    {
      throw new NotImplementedException();
      // need to take entered customer information and insert to table
    }
  }
}
