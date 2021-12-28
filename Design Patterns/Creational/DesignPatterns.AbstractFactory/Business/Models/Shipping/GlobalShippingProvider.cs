using DesingPatterns.AbstractFactory.Business.Models.Commerce;
using System;

namespace DesingPatterns.AbstractFactory.Business.Models.Shipping
{
    internal class GlobalShippingProvider : IShippingProvider
    {
        public string GenerateShippingLabel(Order order)
        {
            var shippingId = GetShippingId();

            if (order.Recipient.Country != order.Sender.Country)
            {
                throw new NotSupportedException("International shipping not supported");
            }

            var shippingCost = 20;

            return $"Shipping Id: {shippingId} {Environment.NewLine}" +
                    $"To: {order.Recipient.To} {Environment.NewLine}" +
                    $"Order total: {order.Total} {Environment.NewLine}" +
                    $"Shipping Cost: {shippingCost}";
        }

        private string GetShippingId()
        {
            return $"Global-{Guid.NewGuid()}";
        }
    }
}
