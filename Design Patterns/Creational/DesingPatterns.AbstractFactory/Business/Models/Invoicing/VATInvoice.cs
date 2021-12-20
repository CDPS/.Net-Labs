using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using System.Text;

namespace DesingPatterns.AbstractFactory.Business.Models.Invoicing
{
    internal class VATInvoice : IInvoice
    {
        public byte[] GenerateInvoice(Order order)
        {
            return Encoding.Default.GetBytes("Generating VAT Invoice");
        }
    }
}
