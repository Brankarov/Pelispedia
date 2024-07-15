using Pelispedia.Domain.DbEntities;
using Pelispedia.Service.DTOs;

namespace Pelispedia.Service.Services.Interface
{
    public interface IActorService
    {
        Task RegisterNewActor(ActorRequest actor);
        Task<IEnumerable<Actor>> GetActores();
        Task InsertCasting(Casting casting);
    }
}