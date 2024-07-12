using Pelispedia.Domain.DbEntities;

namespace Pelispedia.Service.Services.Interface
{
    public interface IDirectorService
    {
        Task<IEnumerable<Director>> GetAllDirectores();
    }
}