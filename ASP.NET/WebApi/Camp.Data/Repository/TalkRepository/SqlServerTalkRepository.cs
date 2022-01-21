using Camp.Data.DbContexts;
using Camp.Data.Repository.BaseRepository;
using Camp.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.Data.Repository.TalkRepository
{
    public class SqlServerTalkRepository : SQLServerRepository<Talk>, ITalkRepository
    {
        public SqlServerTalkRepository(CampDbContext context) : base(context)
        {
        }

        public async Task<Talk[]> GetTalksByMonikerAsync(string moniker, bool includeSpeakers = false)
        {
            IQueryable<Talk> query = _context.Talks;

            if (includeSpeakers)
            {
                query = query
                  .Include(t => t.Speaker);
            }

            query = query.Where(t => t.Camp.Moniker == moniker).OrderByDescending(t => t.Title);
            return await query.ToArrayAsync();
        }

        public async Task<Talk> GetTalkByMonikerAsync(string moniker, int talkId, bool includeSpeakers = false)
        { 
            IQueryable<Talk> query = _context.Talks;

            if (includeSpeakers)
            {
                query = query
                  .Include(t => t.Speaker);
            }

            query = query.Where(t => t.TalkId == talkId && t.Camp.Moniker == moniker);
            return await query.FirstOrDefaultAsync();
        }
    }
}
