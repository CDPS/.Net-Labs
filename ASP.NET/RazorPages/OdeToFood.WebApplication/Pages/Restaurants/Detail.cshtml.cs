using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Data;
using OdeToFood.Entities;
using System.Collections.Generic;

namespace OdeToFood.WebApplication.Pages.Restaurants
{
    public class DetailModel : PageModel
    {

        public Restaurant Restaurant { get; set; }
        private readonly IRestaurantData _restaurantData;
        
        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {

            Restaurant = _restaurantData.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}
