using DesingPatterns.FactoryMethod.Business.Models.Shipping.ShippingProviders;
using DesingPatterns.FactoryMethod.Business.Configuration;
using System;

namespace DesingPatterns.FactoryMethod.Business.Models.Shipping.Factories
{
    internal class AsianShippingProviderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            ShippingProvider shippingProvider;

            if (country == ShippingProviderCountries.CHINA)
            {
                var shippingCostCalculator = new ShippingCostCalculator(internationalShippingFee: 250, extraWeightFee: 500)
                {
                    ShippingType = ShippingType.Standard
                };

                shippingProvider = new ChineseShippingProvider(shippingCostCalculator);
            }
            else if (country == ShippingProviderCountries.JAPAN)
            {
                var shippingCostCalculator = new ShippingCostCalculator(internationalShippingFee: 50, extraWeightFee: 100)
                {
                    ShippingType = ShippingType.Express
                };

                shippingProvider = new JapaneseShippingProvider(shippingCostCalculator);
            }
            else
            {
                throw new NotSupportedException("No shipping provider found for origin country");
            }

            return shippingProvider;
        }
    }
}
