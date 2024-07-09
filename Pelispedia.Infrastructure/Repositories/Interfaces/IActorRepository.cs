using Pelispedia.Domain.DbEntities;

namespace Pelispedia.Infrastructure.Repositories.Interfaces
{
    public interface IActorRepository
    {
        Task InsertActor(Actor actor);
    }
}