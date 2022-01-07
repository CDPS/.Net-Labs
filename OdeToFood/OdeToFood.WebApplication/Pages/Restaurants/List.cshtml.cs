using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;
using OdeToFood.Entities;
using System.Collections.Generic;

namespace OdeToFood.WebApplication.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; } 
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } 

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
        }

        public void OnGet()
        {

            Message = _configuration["Message"];

            if (string.IsNullOrEmpty(SearchTerm))
                Restaurants = _restaurantData.GetAll();
            else
                Restaurants = _restaurantData.GetByName(SearchTerm);
        }
    }
}
