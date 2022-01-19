using PieShop.Entiies.Pie;
using System.Collections.Generic;

namespace PieShop.Data.CategoryRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
