using DesingPatterns.Prototype.Models;
using System;

namespace DesingPatterns.Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Original order:");
            FoodOrder savedOrder = new FoodOrder
            {
                CustomerName = "Harrison",
                IsDelivery = true,
                OrderContents = new string[] { "Pizza", "Coke" },
                Info = new OrderInfo
                {
                    Id = 2345
                }
            };

            Debug(savedOrder);

            Console.WriteLine("Cloned order:");
            FoodOrder clonedOrder = (FoodOrder) savedOrder.DeepClone();
            
            Debug(clonedOrder);

            Console.WriteLine("Order changes:");
            savedOrder.CustomerName = "Jeff";
            savedOrder.Info.Id = 5555;
            Debug(clonedOrder);

        }

        static void Debug(FoodOrder order)
        {
            Console.WriteLine("------- Prototype Food Order -------");
            Console.WriteLine("\nName: {0} \nDelivery: {1}", order.CustomerName, order.IsDelivery);
            Console.WriteLine("ID: {0}", order.Info.Id);
            Console.WriteLine("Order Contents: " + string.Join(",", order.OrderContents) + "\n");
        }
    }
}
