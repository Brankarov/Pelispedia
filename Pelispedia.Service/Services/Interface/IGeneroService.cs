using Pelispedia.Domain.DbEntities;

namespace Pelispedia.Service.Services.Interface
{
    public interface IGeneroService
    {
        Task<IEnumerable<Genero>> GetAllGeneros();
    }
}