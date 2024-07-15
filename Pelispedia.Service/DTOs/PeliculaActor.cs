using Pelispedia.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Service.DTOs
{
    public class PeliculaActor
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Estreno { get; set; }
        public decimal Valoracion { get; set; }
        public string Sinopsis { get; set; }
        public Director Director { get; set; }
        public Genero Genero { get; set; }
        public List<Actor> Actores { get; set; } =  new List<Actor> { };
       
    }
}
