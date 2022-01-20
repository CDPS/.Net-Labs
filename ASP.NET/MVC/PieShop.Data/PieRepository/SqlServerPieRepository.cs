using PieShop.Data.DBContexts;
using PieShop.Data.Repository;
using PieShop.Entiies.Pie;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Data.PieRepository
{
    public class SqlServerPieRepository : SQLServerRepository<Pie>, IPieRepository
    {
        public SqlServerPieRepository(PieShopDbContext context) : base(context) { }

        public IEnumerable<Pie> GetAllPies()
        {
            return _context.Set<Pie>();
        }

        public Pie GetPiesById(int pieID)
        {
            return _context.Set<Pie>().Find(pieID);
        }

        public IEnumerable<Pie> GetPiesOfTheWeek()
        {
            return _context.Set<Pie>().Where(x => x.IsPieOfTheWeek);
        }
    }
}
