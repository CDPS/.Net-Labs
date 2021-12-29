using DesignPatterns.Repository.DBContexts.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository.DBContexts
{
    public  class ShoppingDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
