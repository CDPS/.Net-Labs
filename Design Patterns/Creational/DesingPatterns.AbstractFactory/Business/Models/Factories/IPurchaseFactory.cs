using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using DesingPatterns.AbstractFactory.Business.Models.Invoicing;
using DesingPatterns.AbstractFactory.Business.Models.Shipping;
using DesingPatterns.AbstractFactory.Business.Models.Summarizing;

namespace DesingPatterns.AbstractFactory.Business.Models.Factories
{
    internal interface IPurchaseFactory
    {
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
        IShippingProvider CreateShippingProvider(Order order);
    }
}
