using PieShop.Data.Repository;
using PieShop.Entiies.Pie;
using System.Collections.Generic;

namespace PieShop.Data.CategoryRepository
{
    public class InMemoryCategoryRepository : InMemoryRepository<Category> , ICategoryRepository
    {
        private readonly IEnumerable<Category> _categories;

        public InMemoryCategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fruit pies", Description="All-fruity pies"},
                new Category{CategoryId=2, CategoryName="Cheese cakes", Description="Cheesy all the way"},
                new Category{CategoryId=3, CategoryName="Seasonal pies", Description="Get in the mood for a seasonal pie"}
            };
        }

        public IEnumerable<Category> GetAllCategories()
        {
           return _categories;
        }
    }
}
