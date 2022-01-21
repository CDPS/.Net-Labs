using Microsoft.AspNetCore.Mvc;
using PieShop.Data.CategoryRepository;
using PieShop.Data.PieRepository;
using PieShop.Web.Models;

namespace PieShop.Web.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepostory;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepostory, ICategoryRepository categoryRepository)
        {
            _pieRepostory = pieRepostory;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            PieListViewModel pieListViewModel = new PieListViewModel()
            {
                Pies = _pieRepostory.GetAllPies(),
                CurrentCategory = "Cheese cakes"
            };
            return View(pieListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepostory.GetPiesById(id);
            if(pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
