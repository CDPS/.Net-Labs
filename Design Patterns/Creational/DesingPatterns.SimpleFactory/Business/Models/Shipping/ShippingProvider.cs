using DesingPatterns.SimpleFactory.Business.Configuration;
using DesingPatterns.SimpleFactory.Business.Models.Commerce;

namespace DesingPatterns.SimpleFactory.Business.Models.Shipping
{
    public abstract class ShippingProvider
    {
        public ShippingCostCalculator ShippingCostCalculator { get; protected set; }

        public abstract string GenerateShippingLabel(Order order);
    }

    public class ShippingCostCalculator
    {
        private readonly decimal internationalShippingFee;
        private readonly decimal extraWeightFee;

        public ShippingType ShippingType { get; set; }

        public ShippingCostCalculator(decimal internationalShippingFee,
                                      decimal extraWeightFee,
                                      ShippingType shippingType = ShippingType.Standard)
        {
            this.internationalShippingFee = internationalShippingFee;
            this.extraWeightFee = extraWeightFee;

            ShippingType = shippingType;
        }

        public decimal CalculateShippingCost(string destinationCountry,  string originCountry, decimal weight)
        {
            decimal total = 10m; // Default shipping cost $10

            // International shipping
            if (destinationCountry != originCountry)
            {
                total += internationalShippingFee;
            }

            // Over 5kg
            if (weight > 5)
            {
                total += extraWeightFee;
            }

            switch (ShippingType)
            {
                case ShippingType.Express: total += 20; break;
                case ShippingType.NextDay: total += 50; break;
            }

            return total;
        }
    }
}
