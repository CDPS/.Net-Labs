using DesingPatterns.FactoryMethod.Business;
using DesingPatterns.FactoryMethod.Business.Models.Commerce;
using DesingPatterns.FactoryMethod.Business.Models.Shipping.Factories;
using System;

namespace DesingPatterns.FactoryMethod
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


            var cart = new ShoppingCart(order, new AsianShippingProviderFactory());
            var shippingLabel = cart.Finalize();
            Console.WriteLine(shippingLabel);
        }
    }
}
