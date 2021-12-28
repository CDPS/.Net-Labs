using DesingPatterns.FactoryMethod.Business.Models.Shipping.ShippingProviders;

namespace DesingPatterns.FactoryMethod.Business.Models.Shipping.Factories
{
    public abstract class ShippingProviderFactory
    {
        public abstract ShippingProvider CreateShippingProvider(string country);

        public ShippingProvider GetShippingProvider(string country)
        {
            return CreateShippingProvider(country);
        }
    }
}
