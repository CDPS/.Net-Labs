using DesingPatterns.AbstractFactory.Business.Configuration;
using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using DesingPatterns.AbstractFactory.Business.Models.Factories;

namespace DesingPatterns.AbstractFactory.Business
{
    internal  class ShoppingCart
    {
        private readonly Order _order;
        private readonly IPurchaseFactory _factory;

        public ShoppingCart (Order order, IPurchaseFactory factory)
        {
            _order = order;
            _factory = factory;
        }

        public string Finalize()
        {
            var shippingProvider = _factory.CreateShippingProvider(_order);

            _order.ShippingStatus = ShippingStatus.ReadyForShippment;

            var invoice = _factory.CreateInvoice(_order);
            invoice.GenerateInvoice(_order);

            var summary = _factory.CreateSummary(_order);
            summary.CreateOrderSummary(_order);
            summary.Send();

            return shippingProvider.GenerateShippingLabel(_order);
        }
    }
}
