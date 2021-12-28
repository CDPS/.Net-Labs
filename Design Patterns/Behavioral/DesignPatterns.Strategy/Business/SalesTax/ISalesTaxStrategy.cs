
using DesingPatterns.Strategy.Business.Models;

namespace DesingPatterns.Strategy.Business.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
