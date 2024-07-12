using Pelispedia.Domain.DbEntities;
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
        private readonly IDirectorRepository _directorRepository;
        private readonly IGeneroRepository _generoRepository;

        public PeliculaService(IPeliculaRepository peliculaRepository, IDirectorRepository directorRepository, IGeneroRepository generoRepository)
        {
            _peliculaRepository = peliculaRepository;
            _directorRepository = directorRepository;
            _generoRepository = generoRepository;
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
                    new Director {IdDirector= 0, NombreDirector= g.Key.nombre_director },
                    new Genero {IdGenero = 0, NombreGenero = g.Key.nombre_genero }
                )
                {
                    Actores = g.Select( a => a.actor).ToList()
                }).ToList();
        }

        public async Task InsertPelicula(IncomingMovie pelicula)
        {
            Director director = await _directorRepository.GetDirectorIdByName(pelicula.director);
            Genero genero = await _generoRepository.GetGeneroIdByName(pelicula.genero);
            Pelicula peliculita = Mapper.Map(pelicula, director, genero);
            await _peliculaRepository.InsertPelicula(peliculita);
        }

        public async Task ActualizarPelicula(PeliculaDetailedDTO pelicula)
        {
            Director director = await _directorRepository.GetDirectorIdByName(pelicula.Director.NombreDirector);
            Genero genero = await _generoRepository.GetGeneroIdByName(pelicula.Genero.NombreGenero);
            Pelicula movie = Mapper.Map(pelicula, director,genero);
            await _peliculaRepository.ActualizarPelicula(movie);
        }
    }
}
