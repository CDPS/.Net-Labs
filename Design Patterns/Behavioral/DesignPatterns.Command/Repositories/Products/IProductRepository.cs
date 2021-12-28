using DesingPatterns.Command.Models;
using System.Collections.Generic;

namespace DesingPatterns.Command.Repositories
{
    public interface IProductRepository
    {
        Product FindBy(string articleId);
        int GetStockFor(string articleId);
        IEnumerable<Product> All();
        void DecreaseStockBy(string articleId, int amount);
        void IncreaseStockBy(string articleId, int amount);
    }
}
