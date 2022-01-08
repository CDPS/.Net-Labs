using OdeToFood.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Burquin", Locatiion = "Calarca", Cuisine = CuisineType.FastFood},

                new Restaurant{ Id = 2, Name = "Faster Pizza", Locatiion = "Calarca", Cuisine = CuisineType.Italian},

                new Restaurant{ Id = 3, Name = "Juan Charrasqueado", Locatiion = "Calarca", Cuisine = CuisineType.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(x => x.Name);
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            return _restaurants.Where(x => x.Name.StartsWith(name));
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.FirstOrDefault(x => x.Id == id);
        }

        public Restaurant Update(Restaurant restaurantToUpdate)
        {
            var restaurant = GetById(restaurantToUpdate.Id);
            if(restaurant != null)
            {
                restaurant.Name = restaurantToUpdate.Name;
                restaurant.Locatiion = restaurantToUpdate.Locatiion;
                restaurant.Cuisine = restaurantToUpdate.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Create(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Count() + 1;
            _restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            _restaurants.Remove(restaurant);
            return restaurant;
        }
    }
}
