using Camp.Data.DbContexts;
using Camp.Data.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.Data.Repository.CampRepository
{
    public class SqlServerCampRepository : SQLServerRepository<Entites.Camp>, ICampRepository
    {
        public SqlServerCampRepository(CampDbContext context) : base(context)
        {
        }

        public async Task<Entites.Camp[]> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false)
        {
           
            IQueryable<Entites.Camp> query = _context.Camps.Include(c => c.Location);

            if (includeTalks)
            {
                query = query
                  .Include(c => c.Talks)
                  .ThenInclude(t => t.Speaker);
            }

            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.EventDate.Date == dateTime.Date);

            return await query.ToArrayAsync();
        }

        public async Task<Entites.Camp[]> GetAllCampsAsync(bool includeTalks = false)
        {
         
            IQueryable<Entites.Camp> query = _context.Camps
                .Include(c => c.Location);

            if (includeTalks)
            {
                query = query
                  .Include(c => c.Talks)
                  .ThenInclude(t => t.Speaker);
            }
            query = query.OrderByDescending(c => c.EventDate);

            return await query.ToArrayAsync();
        }

        public async Task<Entites.Camp> GetCampAsync(string moniker, bool includeTalks = false)
        {

            IQueryable<Entites.Camp> query = _context.Camps.Include(c => c.Location);

            if (includeTalks)
            {
                query = query.Include(c => c.Talks)
                  .ThenInclude(t => t.Speaker);
            }
            // Query It
            query = query.Where(c => c.Moniker == moniker);
            return await query.FirstOrDefaultAsync();
        }
    }
}
