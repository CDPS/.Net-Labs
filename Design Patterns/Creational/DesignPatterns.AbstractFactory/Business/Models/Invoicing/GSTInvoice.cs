using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using System.Text;

namespace DesingPatterns.AbstractFactory.Business.Models.Invoicing
{
    internal class GSTInvoice : IInvoice
    {
        public byte[] GenerateInvoice(Order order)
        {
            return Encoding.Default.GetBytes("Generating GST Invoice"); 
        }
    }
}
