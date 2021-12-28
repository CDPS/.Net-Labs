using DessingPatterns.Bridge.Business.Discounts;
using System;

namespace DessingPatterns.Bridge.Business.Licenses
{
    public abstract class MovieLicense
    {
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        private readonly Discount _discount; 
        protected MovieLicense(string movie, DateTime purchaseTime, Discount discount)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
        }

        public decimal GetPrice()
        {
            decimal multiplier = 1 - _discount.GetDiscount() / 100m;
            return GetPriceCore() * multiplier;
        }

        protected abstract decimal GetPriceCore();

        public abstract DateTime? GetExpirationDate();
    }
}
