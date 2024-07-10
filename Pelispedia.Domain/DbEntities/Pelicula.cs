using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Domain.DbEntities
{
    public class Pelicula
    {
        public string Titulo { get; private set; }
        public int Estreno { get; private set; }
        public decimal Valoracion { get; private set; }
        public string Sinopsis { get; private set; }
        public int IdDirector { get; private set; }
        public int IdGenero { get; private set; }

        public Pelicula(string titutlo, int estrenoFecha, decimal valoracion, string sinopsis, int IdDirector, int IdGenero)
        {
            this.Titulo = titutlo;
            this.Estreno = estrenoFecha;
            this.Valoracion = valoracion;
            this.Sinopsis = sinopsis;
            this.IdDirector = IdDirector;
            this.IdGenero = IdGenero;
        }
    }
}
