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
        [HttpPost("PostActor", Name = "PostActor")]
        public ActionResult Get(ActorRequest actor)
        {
            _actorService.RegisterNewActor(actor);
            return Ok();   
        }
        [HttpGet("GetActores", Name ="GetActores")]
        public async Task<List<Actor>> GetActores()
        {
           var actores= await _actorService.GetActores();
            return actores.ToList();
        }
        [HttpPost("PostCasting", Name = "PostCasting")]
        public async Task<ActionResult> PostCasting(Casting casting)
        {
            await _actorService.InsertCasting(casting);
            return Ok();
        }
        [HttpDelete("DeleteCasting", Name ="DeleteCasting")]
        public async Task<ActionResult> DeleteCasting(Casting casting)
        {
            int castid = await _actorService.GetCastingId(casting);
            bool result = await _actorService.DeleteCasting(castid);
            if (result)
            {
                return Ok();
            } else { return BadRequest(); }
        }
    }
}
