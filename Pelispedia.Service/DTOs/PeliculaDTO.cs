using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Service.DTOs
{
    public class PeliculaDTO
    {
        public int Id { get;  set; }
        public string Titulo { get;  set; }
        public int Estreno { get; set; }
        public decimal Valoracion { get;  set; }
        public string Sinopsis { get;  set; }
        public int IdDirector { get;  set; }
        public int IdGenero { get;  set; }
        public PeliculaDTO(int id, string titulo, int estreno, decimal valoracion, string sinopsis, int idDirector, int idGenero)
        {
            Id = id;
            Titulo = titulo;
            Estreno = estreno;
            Valoracion = valoracion;
            Sinopsis = sinopsis;
            IdDirector = idDirector;
            IdGenero = idGenero;
        }
    }
}
