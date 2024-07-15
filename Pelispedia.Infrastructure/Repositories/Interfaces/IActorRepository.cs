using Pelispedia.Domain.DbEntities;

namespace Pelispedia.Infrastructure.Repositories.Interfaces
{
    public interface IActorRepository
    {
        Task InsertActor(Actor actor);
        Task<IEnumerable<Actor>> GetActores();
        Task<Actor> GetActorByName(string nombre);
        Task<List<Actor>> GetActorsByNames(List<string> nombres);
    }
}