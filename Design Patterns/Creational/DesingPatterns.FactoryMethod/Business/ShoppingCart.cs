using DesingPatterns.FactoryMethod.Business.Configuration;
using DesingPatterns.FactoryMethod.Business.Models.Commerce;
using DesingPatterns.FactoryMethod.Business.Models.Shipping.Factories;

namespace DesingPatterns.FactoryMethod.Business
{
    public  class ShoppingCart
    {
        private readonly Order _order;
        private readonly ShippingProviderFactory _factory;
        public ShoppingCart (Order order, ShippingProviderFactory factory)
        {
            _order = order;
            _factory = factory;
        }

        public string Finalize()
        {
            var shippingProvider = _factory.GetShippingProvider(_order.Sender.Country);
            _order.ShippingStatus = ShippingStatus.ReadyForShippment;
            return shippingProvider.GenerateShippingLabel(_order);
        }
    }
}
