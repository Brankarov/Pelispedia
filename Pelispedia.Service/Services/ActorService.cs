using Pelispedia.Domain.DbEntities;
using Pelispedia.Infrastructure.Repositories;
using Pelispedia.Infrastructure.Repositories.Interfaces;
using Pelispedia.Service.DTOs;
using Pelispedia.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Service.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly ICastingRepository _castingRepository;
        public ActorService(IActorRepository actorRepository, ICastingRepository castingRepository)
        {
            this._actorRepository = actorRepository;
            this._castingRepository = castingRepository;
        }

        public async Task RegisterNewActor(ActorRequest actor)
        {

           await _actorRepository.InsertActor(Mapper.Map(actor));

        }

        public async Task<IEnumerable<Actor>> GetActores()
        {
            return await _actorRepository.GetActores();
        }

        public async Task InsertCasting(Casting casting)
        {
            await _castingRepository.InsertCasting(casting);
        }

        public async Task<int> GetCastingId(Casting casting)
        {
            var cast = await _castingRepository.GetCasting(casting);
            return cast.IdCasting;
        }

        public async Task<bool> DeleteCasting(int id)
        {
            var result = await _castingRepository.DeleteCasting(id);
            return result;
        }
    }
}
