using Pelispedia.Domain.DbEntities;

namespace Pelispedia.Infrastructure.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        Task<Director> GetDirectorById(int id);
    }
}