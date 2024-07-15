using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Domain.ReportEntities
{
    public class PeliculaConMasActor
    {
        public int IdPelicula { get; set; }
        public string Titulo { get; set; }
        public int NumActores { get; set; }
    }
}
