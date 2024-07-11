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
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _peliculaRepository;

        public PeliculaService(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        public async Task<PeliculaDTO> GetPeliculaById(int id)
        {
            var pelicula = await _peliculaRepository.GetPeliculaById(id);
            return Mapper.Map(pelicula);
        }

        public async Task<IEnumerable<PeliculaDTO>> GetAllPeliculas()
        {
            var peliculas = await _peliculaRepository.GetAllPeliculas();
            return peliculas.Select(p =>
            {
                return new PeliculaDTO(
                    p.IdPelicula, p.Titulo, p.Estreno, p.Valoracion, p.Sinopsis, p.IdDirector, p.IdGenero
                );
            });
        }

        public async Task<IEnumerable<PeliculaDetailedDTO>> GetDetailedMovies()
        {
            var peliculas = await _peliculaRepository.GetMovieDetailed();

            return peliculas.GroupBy( p => new {p.IdPelicula, p.Titulo, p.Sinopsis, p.Estreno, p.Valoracion, p.nombre_genero, p.nombre_director})
                .Select(g => new PeliculaDetailedDTO
                ( 
                    g.Key.IdPelicula,
                    g.Key.Titulo,
                    g.Key.Estreno,
                    g.Key.Valoracion,
                    g.Key.Sinopsis,
                    g.Key.nombre_genero,
                    g.Key.nombre_director
                )
                {
                    Actores = g.Select( a => a.actor).ToList()
                }).ToList();
        }
    }
}
