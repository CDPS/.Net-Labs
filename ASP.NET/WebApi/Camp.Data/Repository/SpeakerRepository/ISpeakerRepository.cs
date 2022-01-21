using Camp.Data.Repository.BaseRepository;
using Camp.Entites;
using System.Threading.Tasks;

namespace Camp.Data.Repository.SpeakerRepository
{
    public interface ISpeakerRepository : IRepository<Speaker>
    {
        Task<Speaker[]> GetSpeakersByMonikerAsync(string moniker);
        Task<Speaker> GetSpeakerAsync(int speakerId);
        Task<Speaker[]> GetAllSpeakersAsync();
    }
}
