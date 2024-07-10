using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Domain.DbEntities
{
    public class Casting
    {
        public int IdCasting { get; private set; }
        public int IdPelicula { get; private set; }
        public int IdActor { get; private set; }
        public Casting(int idCasting,int idPelicula,int idActor)
        {
            IdCasting = idCasting;
            IdPelicula = idPelicula;
            IdActor = idActor;
        }
    }
}
