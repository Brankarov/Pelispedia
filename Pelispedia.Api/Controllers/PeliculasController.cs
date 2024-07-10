using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pelispedia.Service.DTOs;
using Pelispedia.Service.Services.Interface;

namespace Pelispedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService _peliculaService;
        public PeliculasController( IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }


        [HttpGet("{id}", Name = "GetPeliculaById")]
        public async Task<ActionResult<PeliculaDTO>> GetPeliculaById(int id)
        {
            var pelicula = await _peliculaService.GetPeliculaById(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpGet(Name = "GetPeliculasList")]
        public async Task<ActionResult<List<PeliculaDTO>>> GetPeliculasList()
        {
            var peliculas = await _peliculaService.GetAllPeliculas();
            return Ok(peliculas.ToList());
        }
    }
}
