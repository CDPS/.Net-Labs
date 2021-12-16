using DesingPatterns.SimpleFactory.Business.Models.Commerce;
using System;

namespace DesingPatterns.SimpleFactory.Business.Models.Shipping
{
    public class SwedishPostalServiceShippingProvider : ShippingProvider
    {
        public SwedishPostalServiceShippingProvider(ShippingCostCalculator shippingCostCalculator)
        {
            ShippingCostCalculator = shippingCostCalculator;
        }

        public override string GenerateShippingLabel(Order order)
        {
            var shippingId = GetShippingId();

            var shippingCost = ShippingCostCalculator.CalculateShippingCost(order.Recipient.Country,
                order.Sender.Country,
                order.TotalWeight);

            return $"Shipping Id: {shippingId} {Environment.NewLine}" +
                    $"To: {order.Recipient.To} {Environment.NewLine}" +
                    $"Order total: {order.Total} {Environment.NewLine}" +
                    $"Shipping Cost: {shippingCost}";
        }

        private string GetShippingId()
        {
            return $"SWE-{Guid.NewGuid()}";
        }
    }
}
