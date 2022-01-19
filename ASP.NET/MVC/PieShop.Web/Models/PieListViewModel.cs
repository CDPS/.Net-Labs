using PieShop.Entiies.Pie;
using System.Collections.Generic;

namespace PieShop.Web.Models
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
