using PieShop.Data.DBContexts;
using PieShop.Data.Repository;
using PieShop.Entiies.Pie;
using System.Collections.Generic;

namespace PieShop.Data.CategoryRepository
{
    public class SqlServerCategoryRepository : SQLServerRepository<Category>, ICategoryRepository
    {
        public SqlServerCategoryRepository(PieShopDbContext context) : base(context) { }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Set<Category>();
        }
    }
}
