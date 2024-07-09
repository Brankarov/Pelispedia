using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pelispedia.Domain.DbEntities;
using Pelispedia.Service.DTOs;
using Pelispedia.Service.Services;
using Pelispedia.Service.Services.Interface;

namespace Pelispedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IActorService _actorService;
        public DirectorController(IActorService actorService)
        {
                _actorService = actorService;
        }
        [HttpPost(Name = "PostActor")]
        public ActionResult Get(ActorRequest actor)
        {
            _actorService.RegisterNewActor(actor);
            return Ok();   
        }

    }
}
