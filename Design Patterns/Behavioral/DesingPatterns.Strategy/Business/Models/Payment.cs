using DesingPatterns.Strategy.Configuration;

namespace DesingPatterns.Strategy.Business.Models
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public PaymentProvider PaymentProvider { get; set; }
    }
}