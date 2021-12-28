using DessingPatterns.Bridge.Business.Discounts;
using System;

namespace DessingPatterns.Bridge.Business.Licenses
{
    public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseTime, Discount discount)
            : base(movie, purchaseTime,discount)
        {
        }

        protected override decimal GetPriceCore() => 4;

        public override DateTime? GetExpirationDate() => PurchaseTime.AddDays(2);
    }
}
