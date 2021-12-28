using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using DesingPatterns.AbstractFactory.Business.Models.Invoicing;
using DesingPatterns.AbstractFactory.Business.Models.Shipping;
using DesingPatterns.AbstractFactory.Business.Models.Summarizing;

namespace DesingPatterns.AbstractFactory.Business.Models.Factories
{
    internal class AustralianPurchaseFactory : IPurchaseFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public IShippingProvider CreateShippingProvider(Order order)
        {
            return new StandardShippingProvider();
        }

        public ISummary CreateSummary(Order order)
        {
            return new EmailSummary();
        }
    }
}
