using DesingPatterns.Strategy.Business.Models;
using DesingPatterns.Strategy.Business.SalesTax;
using DesingPatterns.Strategy.Configuration;
using System;

namespace DesingPatterns.Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                },
                SalesTaxStrategy = new SwedenSalesTaxStrategy()
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);

            Console.WriteLine(order.GetTax());
        }
    }
}
