using DesingPatterns.AbstractFactory.Business.Models.Commerce;

namespace DesingPatterns.AbstractFactory.Business.Models.Invoicing
{
    internal interface IInvoice
    {
        byte[] GenerateInvoice(Order order);
    }
}
