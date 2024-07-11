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
        public PeliculasController( IPeliculaService peliculaService, IGeneroService generoService)
        {
            _peliculaService = peliculaService;
            _generoService = generoService;
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

        //[HttpPost("UpdateMovie/{id}", Name ="UpdateMovie")]
        //public async Task<ActionResult> UpdateMovie(PeliculaDetailedDTO)
        //{
        //    var result = await _peliculaService.UpdateMovie();
        //    return Ok();
        //}

        [HttpGet("GetGeneros", Name ="GetGeneros")]
        public async Task<List<Genero>> GetGeneros()
        {
            var result = await _generoService.GetAllGeneros();
            return result.ToList();
        }

    }
}
