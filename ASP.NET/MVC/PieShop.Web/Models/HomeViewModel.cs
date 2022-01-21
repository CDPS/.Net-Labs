using PieShop.Entiies.Pie;
using System.Collections.Generic;

namespace PieShop.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}
