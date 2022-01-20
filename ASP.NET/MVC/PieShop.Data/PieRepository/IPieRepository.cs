using PieShop.Data.Repository;
using PieShop.Entiies.Pie;
using System.Collections.Generic;

namespace PieShop.Data.PieRepository
{
    public interface IPieRepository : IRepository<Pie>
    {
        IEnumerable<Pie> GetAllPies();
        IEnumerable<Pie> GetPiesOfTheWeek();
        Pie GetPiesById(int pieID);
    }
}
