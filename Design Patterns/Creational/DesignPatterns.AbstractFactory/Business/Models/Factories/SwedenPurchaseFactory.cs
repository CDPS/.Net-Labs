using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using DesingPatterns.AbstractFactory.Business.Models.Invoicing;
using DesingPatterns.AbstractFactory.Business.Models.Shipping;
using DesingPatterns.AbstractFactory.Business.Models.Summarizing;
using System;

namespace DesingPatterns.AbstractFactory.Business.Models.Factories
{
    internal class SwedenPurchaseFactory : IPurchaseFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            if (order.Recipient.Country != order.Sender.Country)
                return new NoVATInvoice();
            return new VATInvoice();
        }

        public IShippingProvider CreateShippingProvider(Order order)
        {
            return new GlobalShippingProvider();
        }

        public ISummary CreateSummary(Order order)
        {
            return new CSVSummary();
        }
    }
}
