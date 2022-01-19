using PieShop.Entiies.Pie;
using System.Collections.Generic;

namespace PieShop.Data.PieRepository
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies();
        IEnumerable<Pie> GetPiesOfTheWeek();
        Pie GetPiesById(int pieID);
    }
}
