using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using System.Text;

namespace DesingPatterns.AbstractFactory.Business.Models.Invoicing
{
    internal class NoVATInvoice : IInvoice
    {
        public byte[] GenerateInvoice(Order order)
        {
            return Encoding.Default.GetBytes("Generating NO VAT Invoice");
        }
    }
}
