using DesingPatterns.FactoryMethod.Business.Configuration;
using DesingPatterns.FactoryMethod.Business.Models.Shipping.ShippingProviders;
using System;

namespace DesingPatterns.FactoryMethod.Business.Models.Shipping.Factories
{
    internal class EuropeanShippingProviderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            ShippingProvider shippingProvider;

            if (country == ShippingProviderCountries.FINLAND)
            {
                var shippingCostCalculator = new ShippingCostCalculator(internationalShippingFee: 250, extraWeightFee: 500)
                {
                    ShippingType = ShippingType.Standard
                };

                shippingProvider = new FinlandShippingProvider(shippingCostCalculator);
            }
            else if (country == ShippingProviderCountries.SWEDEN)
            {
                var shippingCostCalculator = new ShippingCostCalculator(internationalShippingFee: 50, extraWeightFee: 100)
                {
                    ShippingType = ShippingType.Express
                };

                shippingProvider = new SwedishShippingProvider(shippingCostCalculator);
            }
            else
            {
                throw new NotSupportedException("No shipping provider found for origin country");
            }

            return shippingProvider;
        }
    }
}
