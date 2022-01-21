using Microsoft.AspNetCore.Mvc;
using PieShop.Data.CategoryRepository;
using System.Linq;

namespace PieShop.Web.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAll().OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
