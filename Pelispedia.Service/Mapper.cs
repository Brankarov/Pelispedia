using Pelispedia.Domain.DbEntities;
using Pelispedia.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Service
{
    public static class Mapper
    {
        public static Actor Map(ActorRequest actor)
        {
            return (actor != null? 
             new Actor { Nombre= actor.Nobre, Raza =  actor.Raza, Sexo = actor.Sexo }
            : new Actor { });
        }

        public static PeliculaDTO Map(Pelicula peli)
        {
            return (new PeliculaDTO(peli.IdPelicula, peli.Titulo, peli.Estreno, peli.Valoracion, peli.Sinopsis, peli.IdDirector, peli.IdGenero ));
        }

        public static Pelicula Map(IncomingMovie peli, Director director, Genero genero)
        {
            return (new Pelicula
            {
                Estreno = peli.estreno,
                IdDirector = director.IdDirector,
                IdGenero = genero.IdGenero,
                Sinopsis = peli.sinopsis,
                Titulo = peli.titulo,
                Valoracion = peli.valoracion,
                IdPelicula = peli.id,
            });
        }

        public static Pelicula Map(PeliculaDetailedDTO peli, Director director, Genero genero)
        {
            return (new Pelicula
            {
                Estreno = peli.Estreno,
                IdDirector = director.IdDirector,
                IdGenero = genero.IdGenero,
                Sinopsis = peli.Sinopsis,
                Titulo = peli.Titulo,
                Valoracion = peli.Valoracion,
                IdPelicula = peli.Id,
            });
        }
    }
}
