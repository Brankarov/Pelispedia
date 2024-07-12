using Pelispedia.Domain.DbEntities;
using System.Threading.Tasks;

namespace Pelispedia.Infrastructure.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        Task<Director> GetDirectorById(int id);
        Task<IEnumerable<Director>> GetAllDirector();
        Task<Director> GetDirectorIdByName(string name);
    }
}