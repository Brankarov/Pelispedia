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
             new Actor(actor.Nobre, actor.Raza, actor.Sexo)
            : new Actor("", "", ""));
        }

        public static PeliculaDTO Map(Pelicula peli)
        {
            return (new PeliculaDTO(peli.IdPelicula, peli.Titulo, peli.Estreno, peli.Valoracion, peli.Sinopsis, peli.IdDirector, peli.IdGenero ));
        }
    }
}
