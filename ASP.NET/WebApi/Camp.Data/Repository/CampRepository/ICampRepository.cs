using Camp.Data.Repository.BaseRepository;
using System;
using System.Threading.Tasks;

namespace Camp.Data.Repository.CampRepository
{
    public interface ICampRepository : IRepository<Entites.Camp>
    {
        Task<Entites.Camp[]> GetAllCampsAsync(bool includeTalks = false);
        Task<Entites.Camp> GetCampAsync(string moniker, bool includeTalks = false);
        Task<Entites.Camp[]> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false);
    }
}
