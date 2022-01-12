using Microsoft.EntityFrameworkCore;
using OdeToFood.Entities;

using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public Restaurant Create(Restaurant restaurant)
        {
            _dbContext.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                _dbContext.Remove(restaurant); 
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _dbContext.Restaurants;
        }

        public Restaurant GetById(int id)
        {
           return _dbContext.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            return _dbContext.Restaurants.Where(x=> x.Name.StartsWith(name));
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = _dbContext.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}
