using Camp.Data.Repository.BaseRepository;
using Camp.Entites;
using System.Threading.Tasks;

namespace Camp.Data.Repository.TalkRepository
{
    public interface ITalkRepository : IRepository<Talk>
    {
        Task<Talk> GetTalkByMonikerAsync(string moniker, int talkId, bool includeSpeakers = false);
        Task<Talk[]> GetTalksByMonikerAsync(string moniker, bool includeSpeakers = false);
    }
}
