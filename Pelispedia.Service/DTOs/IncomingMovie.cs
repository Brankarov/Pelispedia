using Pelispedia.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Service.DTOs
{
    public class IncomingMovie
    {
        public int id { get; set; } 
        public string director { get; set; }
        public int estreno { get; set; }    
        public string genero { get; set; }
        public string sinopsis { get; set; }
        public string titulo { get; set; }
        public decimal valoracion { get; set; }
    }
}
