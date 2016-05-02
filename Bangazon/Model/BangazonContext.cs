using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bangazon
{
  class BangazonContext : DbContext
  {
    public DbSet<Customer> Customer { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Customer>()
        .ToTable("Customer")
        .HasKey(a => a.CustomerId);
    }
  }
}
