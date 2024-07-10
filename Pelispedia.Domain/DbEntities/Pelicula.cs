using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Domain.DbEntities
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public string? Titulo { get; set; }
        public int Estreno { get; set; }
        public decimal Valoracion { get; set; }
        public string? Sinopsis { get; set; }
        public int IdDirector { get; set; }
        public int IdGenero { get; set; }
    }
}
