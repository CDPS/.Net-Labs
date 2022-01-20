using PieShop.Data.Repository;
using PieShop.Entiies.Pie;
using System.Collections.Generic;

namespace PieShop.Data.CategoryRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllCategories();
    }
}
