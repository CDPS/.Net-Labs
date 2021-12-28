using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using System;

namespace DesingPatterns.AbstractFactory.Business.Models.Summarizing
{
    internal class CSVSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "this,is,a,CSV,Summary,Generation";
        }

        public void Send()
        {
            Console.WriteLine("Generating CSV File");
        }
    }
}
