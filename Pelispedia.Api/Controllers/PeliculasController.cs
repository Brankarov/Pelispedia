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


        [HttpGet(Name = "GetPeliculaById")]
        public async Task<PeliculaDTO> GetPeliculaById(int id)
        {
            var pelicula = await _peliculaService.GetPeliculaById(id);   
            return pelicula;
        }

        [HttpGet(Name = "GetAllPeliculas")]
        public async Task<List<PeliculaDTO>> GetAllPeliculas()
        {
            return await _peliculaService.GetAllPeliculas();
        }
    }
}
