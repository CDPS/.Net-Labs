using DesignPatterns.Repository.DataAccess.Interfaces;
using DesignPatterns.Repository.DBContexts.DBEntities;
using System.Collections.Generic;

namespace DesignPatterns.Repository.Business
{
    public  class ProductBusiness
    {
        private readonly IProductRepository productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Create(Product product)
        {
            return productRepository.Add(product);
        }

        public IEnumerable<Product> GetProductsToExpire()
        {
            return productRepository.GetProductsNeartoExpire(take: 10);
        }
    }
}
