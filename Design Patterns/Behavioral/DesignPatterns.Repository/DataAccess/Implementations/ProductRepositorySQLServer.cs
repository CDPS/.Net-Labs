using DesignPatterns.Repository.DataAccess.Interfaces;
using DesignPatterns.Repository.DBContexts;
using DesignPatterns.Repository.DBContexts.DBEntities;
using DesignPatterns.Repository.Repository;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Repository.DataAccess.Implementations
{
    public class ProductRepositorySQLServer : SQLServerRepository<Product>, IProductRepository
    {
        public ProductRepositorySQLServer(ShoppingDBContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductsNeartoExpire(int take)
        {
            return _context.Set<Product>().OrderBy(x=> x.DueDate).Take(take);
        }
    }
}
