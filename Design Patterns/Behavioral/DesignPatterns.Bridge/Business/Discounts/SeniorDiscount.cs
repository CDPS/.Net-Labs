
namespace DessingPatterns.Bridge.Business.Discounts
{
    internal class SeniorDiscount : Discount
    {
        public override int GetDiscount()
        {
            return 20;
        }
    }
}
