using DesingPatterns.SimpleFactory.Business.Configuration;
using DesingPatterns.SimpleFactory.Business.Models.Commerce;
using DesingPatterns.SimpleFactory.Business.Models.Shipping;

namespace DesingPatterns.SimpleFactory.Business
{
    public  class ShoppingCart
    {
        private readonly Order order;

        public ShoppingCart (Order order)
        {
            this.order = order;
        }

        public string Finalize()
        {
            var shippingProvider = ShippingProviderFactory.CreateShippingProvider(order.Sender.Country);
            order.ShippingStatus = ShippingStatus.ReadyForShippment;
            return shippingProvider.GenerateShippingLabel(order);
        }
    }
}
