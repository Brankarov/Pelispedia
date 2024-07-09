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
        public ActorService(IActorRepository actorRepository)
        {
            this._actorRepository = actorRepository;
        }

        public async Task RegisterNewActor(ActorRequest actor)
        {

           await _actorRepository.InsertActor(Mapper.Map(actor));

        }
    }
}
