using DesingPatterns.AbstractFactory.Business.Models.Commerce;

namespace DesingPatterns.AbstractFactory.Business.Models.Summarizing
{
    internal interface ISummary
    {
        string CreateOrderSummary(Order order);
        void Send();
    }
}
