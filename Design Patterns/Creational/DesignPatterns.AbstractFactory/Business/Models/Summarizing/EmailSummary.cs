using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using System;

namespace DesingPatterns.AbstractFactory.Business.Models.Summarizing
{
    internal class EmailSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This is an Email Notification Summary";
        }

        public void Send()
        {
            Console.WriteLine("Sending Summary throw email");
        }
    }
}
