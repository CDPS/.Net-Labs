using DesingPatterns.AbstractFactory.Business.Models.Commerce;

namespace DesingPatterns.AbstractFactory.Business.Models.Shipping
{
    internal interface IShippingProvider
    {
        string GenerateShippingLabel(Order order);
    }
}
