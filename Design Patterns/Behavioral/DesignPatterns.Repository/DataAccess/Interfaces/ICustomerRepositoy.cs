using DesignPatterns.Repository.DBContexts.DBEntities;
using DesignPatterns.Repository.Repository;

namespace DesignPatterns.Repository.DataAccess.Interfaces
{
    public interface ICustomerRepositoy : IRepository<Customer>
    {
        Customer GetOldestCustomer();
    }
}
