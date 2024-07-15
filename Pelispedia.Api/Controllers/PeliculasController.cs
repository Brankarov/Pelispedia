using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pelispedia.Domain.DbEntities;
using Pelispedia.Service.DTOs;
using Pelispedia.Service.Services.Interface;

namespace Pelispedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService _peliculaService;
        private readonly IGeneroService _generoService;
        private readonly IDirectorService _directorService;
        public PeliculasController( IPeliculaService peliculaService, IGeneroService generoService, IDirectorService directorService)
        {
            _peliculaService = peliculaService;
            _generoService = generoService;
            _directorService = directorService;
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

        [HttpGet("GetPeliculasList", Name = "GetPeliculasList")]
        public async Task<ActionResult<List<PeliculaDTO>>> GetPeliculasList()
        {
            var peliculas = await _peliculaService.GetAllPeliculas();
            return Ok(peliculas.ToList());
        }
        
        [HttpGet("GetDetailedMovies", Name ="GetDetailedMovies")]
        public async Task<ActionResult<List<PeliculaDetailedDTO>>> GetDetailedMovie()
        {
            var peliculas = await _peliculaService.GetDetailedMovies();
            return Ok(peliculas.ToList());
        }

        [HttpPut("UpdateMovie", Name = "UpdateMovie")]
        public async Task<ActionResult> UpdateMovie(PeliculaDetailedDTO pelicula)
        {
            await _peliculaService.ActualizarPelicula(pelicula);
            return Ok();
        }

        [HttpPost("AddMovie", Name = "AddMovie")]
        public async Task<ActionResult> AddPelicula(IncomingMovie pelicula)
        {
            await _peliculaService.InsertPelicula(pelicula);
            return Ok();
        }

        [HttpGet("GetGeneros", Name ="GetGeneros")]
        public async Task<List<Genero>> GetGeneros()
        {
            var result = await _generoService.GetAllGeneros();
            return result.ToList();
        }

        [HttpGet("GetDirectores", Name ="GetDirectores")]
        public async Task<List<Director>> GetDirectores()
        {
            var result = await _directorService.GetAllDirectores();
            return result.ToList();
        }

        [HttpGet("GetPelisConActores", Name = "GetPelisConActores")]
        public async Task<List<PeliculaActor>> GetPelisConActores()
        {
            var result = await _peliculaService.GetPeliculaConActores();
            return result.ToList();
        }

    }
}
