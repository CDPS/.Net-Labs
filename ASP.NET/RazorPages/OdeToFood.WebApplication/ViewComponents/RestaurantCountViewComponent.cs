using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System.Linq;

namespace OdeToFood.WebApplication.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var restaurantsCount = _restaurantData.GetAll().Count();
            return View(restaurantsCount);
        }
    }
}
