using Pelispedia.Domain.DbEntities;

namespace Pelispedia.Infrastructure.Repositories.Interfaces
{
    public interface IGeneroRepository
    {
        Task<Genero> GetGeneroById(int id);
        Task<IEnumerable<Genero>> GetAllGeneros();
    }
}