using DesignPatterns.Repository.DBContexts.DBEntities;
using DesignPatterns.Repository.Repository;
using System.Collections.Generic;

namespace DesignPatterns.Repository.DataAccess.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsNeartoExpire(int take);
    }
}
