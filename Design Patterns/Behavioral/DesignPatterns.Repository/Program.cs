using DesignPatterns.Repository.Business;
using DesignPatterns.Repository.DBContexts.DBEntities;
using System;

namespace DesignPatterns.Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // resolve via DI

            Product product = new Product
            {
                Name = "Shamppo",
                DueDate = DateTime.Now
            };

            ProductBusiness productBusiness = GetProductBusiness();
            productBusiness.Create(product);

        }

        public static ProductBusiness GetProductBusiness()
        {
            return null;
        }
    }
}
