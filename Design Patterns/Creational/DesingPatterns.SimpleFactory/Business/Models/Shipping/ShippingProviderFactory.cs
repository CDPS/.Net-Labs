using DesingPatterns.SimpleFactory.Business.Configuration;
using System;

namespace DesingPatterns.SimpleFactory.Business.Models.Shipping
{
    public class ShippingProviderFactory
    {
        public static ShippingProvider CreateShippingProvider(string country)
        {
            ShippingProvider shippingProvider;

            if (country == ShippingProviderCountries.AUSTRALIA)
            {
                var shippingCostCalculator = new ShippingCostCalculator( internationalShippingFee: 250, extraWeightFee: 500)
                {
                    ShippingType = ShippingType.Standard
                };

                shippingProvider = new AustraliaPostShippingProvider(shippingCostCalculator);
            }
            else if (country == ShippingProviderCountries.SWEDEN)
            {
                var shippingCostCalculator = new ShippingCostCalculator( internationalShippingFee: 50, extraWeightFee: 100)
                {
                    ShippingType = ShippingType.Express
                };

                shippingProvider = new SwedishPostalServiceShippingProvider(shippingCostCalculator);
            }
            else
            {
                throw new NotSupportedException("No shipping provider found for origin country");
            }

            return shippingProvider;
        }
    }
}
