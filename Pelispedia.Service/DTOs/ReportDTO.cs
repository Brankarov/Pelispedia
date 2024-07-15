using Pelispedia.Domain.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Service.DTOs
{
    public class ReportDTO
    {
        public int PeliculaViejaEstrenoFecha { get; set; }
        public string TitutloPeliculaMasVieja { get; set; }
        public int PeliculaNuevaFechaEstreno { get; set; }
        public string TituloPeliculaNueva { get; set; }
        public List<Pelicula> Top5Peliculas { get; set; } = new List<Pelicula>();
        public string PeliculaConMasActores { get; set; }
        public int NumeroDeActoresPeliculaConMasActores { get; set; }
        public string DirectorConMasPelicuas { get; set; }
        public int CantidadDePeliculasDelDirector { get; set; }
        public string ActorConMasPeliculas { get; set; }
        public int CantidadDePelicuasActor { get; set; }

    }
}
