using Microsoft.AspNetCore.Mvc;
using PieShop.Data.CategoryRepository;
using PieShop.Data.PieRepository;
using PieShop.Entiies.Pie;
using PieShop.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Web.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepostory, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepostory;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.GetAll().OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.GetAll().Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.GetAll().FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PieListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPiesById(id);
            if(pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
