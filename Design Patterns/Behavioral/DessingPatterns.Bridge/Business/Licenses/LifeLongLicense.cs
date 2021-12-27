using DessingPatterns.Bridge.Business.Discounts;
using System;

namespace DessingPatterns.Bridge.Business.Licenses
{
    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseTime, Discount discount)
            : base(movie, purchaseTime, discount)
        {
        }

        protected override decimal GetPriceCore() => 8;

        public override DateTime? GetExpirationDate() => null;
    }
}
