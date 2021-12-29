using DesignPatterns.Repository.DataAccess.Interfaces;
using DesignPatterns.Repository.DBContexts;
using DesignPatterns.Repository.DBContexts.DBEntities;
using DesignPatterns.Repository.Repository;
using System.Linq;


namespace DesignPatterns.Repository.DataAccess.Implementations
{
    public class CustomerRepositorySQLServer : SQLServerRepository<Customer>, ICustomerRepositoy
    {
        public CustomerRepositorySQLServer(ShoppingDBContext context) : base(context)
        {
        }

        public Customer GetOldestCustomer()
        {
             return _context.Set<Customer>().OrderByDescending(x=> x.Age).Single();
        }
    }
}
