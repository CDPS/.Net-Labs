
using Camp.Data.DbContexts;
using Camp.Data.Repository.BaseRepository;
using Camp.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.Data.Repository.SpeakerRepository
{
    public class SqlServerSpeakerRepository : SQLServerRepository<Speaker>, ISpeakerRepository
    {
        public SqlServerSpeakerRepository(CampDbContext context) : base(context)
        {
        }

        public async Task<Speaker[]> GetSpeakersByMonikerAsync(string moniker)
        {
            IQueryable<Speaker> query = _context.Talks
              .Where(t => t.Camp.Moniker == moniker)
              .Select(t => t.Speaker)
              .Where(s => s != null)
              .OrderBy(s => s.LastName)
              .Distinct();

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersAsync()
        {
            var query = _context.Speakers.OrderBy(t => t.LastName);
            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerAsync(int speakerId)
        {
            var query = _context.Speakers.Where(t => t.SpeakerId == speakerId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
