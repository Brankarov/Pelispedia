using Pelispedia.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Service.DTOs
{
    public class PeliculaDetailedDTO
    {
        public int Id { get;  set; }
        public string Titulo { get;  set; }
        public int Estreno { get; set; }
        public decimal Valoracion { get;  set; }
        public string Sinopsis { get;  set; }
        public Director Director { get;  set; }
        public Genero Genero { get;  set; }
        public List<string> Actores { get; set; }
        public PeliculaDetailedDTO(int id, string titulo, int estreno, decimal valoracion, string sinopsis,Director director, Genero genero)
        {
            Id = id;
            Titulo = titulo;
            Estreno = estreno;
            Valoracion = valoracion;
            Sinopsis = sinopsis;
            Director = director;
            Genero = genero;
            Actores = new List<string>();
        }

        public void add(string actor)
        {
            Actores.Add(actor);
        }
    }
}
