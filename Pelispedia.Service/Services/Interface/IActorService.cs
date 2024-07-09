using Pelispedia.Service.DTOs;

namespace Pelispedia.Service.Services.Interface
{
    public interface IActorService
    {
        Task RegisterNewActor(ActorRequest actor);
    }
}