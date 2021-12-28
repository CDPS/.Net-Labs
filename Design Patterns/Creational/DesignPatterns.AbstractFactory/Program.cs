using DesingPatterns.AbstractFactory.Business;
using DesingPatterns.AbstractFactory.Business.Configuration;
using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using DesingPatterns.AbstractFactory.Business.Models.Factories;
using System;

namespace DesingPatterns.AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Recipient Country: ");
            var recipientCountry = Console.ReadLine().Trim();

            Console.Write("Sender Country: ");
            var senderCountry = Console.ReadLine().Trim();

            Console.Write("Total Order Weight: ");
            var totalWeight = Convert.ToInt32(Console.ReadLine().Trim());

            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Filip Ekberg",
                    Country = recipientCountry
                },

                Sender = new Address
                {
                    To = "Someone else",
                    Country = senderCountry
                },

                TotalWeight = totalWeight
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m), 1);


            IPurchaseFactory factory = null;
            if (order.Sender.Country == ShippingProviderCountries.AUSTRALIA)
            {
                factory = new AustralianPurchaseFactory();
            }
            else if (order.Sender.Country == ShippingProviderCountries.SWEDEN)
            {
                factory = new SwedenPurchaseFactory();
            }
            else
            {
                throw new NotSupportedException("No shipping provider found for origin country");
            }

            var cart = new ShoppingCart(order,factory);

            var shippingLabel = cart.Finalize();
            Console.WriteLine(shippingLabel);
        }
    }
}
