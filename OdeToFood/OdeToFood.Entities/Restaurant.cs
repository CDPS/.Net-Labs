using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(80)]
        public string Locatiion { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
