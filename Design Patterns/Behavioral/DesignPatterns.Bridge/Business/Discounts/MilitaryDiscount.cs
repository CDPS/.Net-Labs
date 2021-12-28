
namespace DessingPatterns.Bridge.Business.Discounts
{
    public class MilitaryDiscount : Discount
    {
        public override int GetDiscount()
        {
            return 10;
        }
    }
}
