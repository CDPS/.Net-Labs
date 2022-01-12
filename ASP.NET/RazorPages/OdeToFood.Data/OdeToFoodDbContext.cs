using Microsoft.EntityFrameworkCore;
using OdeToFood.Entities;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext :  DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options): base(options)  {  }
    }
}
