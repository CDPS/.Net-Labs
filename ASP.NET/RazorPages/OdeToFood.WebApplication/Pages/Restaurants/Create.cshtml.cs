using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Data;
using OdeToFood.Entities;
using System.Collections.Generic;

namespace OdeToFood.WebApplication.Pages.Restaurants
{
    public class CreateModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> CuisineTypes { get; set; }

        public CreateModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            CuisineTypes = htmlHelper.GetEnumSelectList<CuisineType>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Restaurant = _restaurantData.Create(Restaurant);
                _restaurantData.Commit();
                return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
            }
            return Page();
        }
    }
}
