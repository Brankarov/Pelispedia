using Pelispedia.Infrastructure.Repositories.Interfaces;
using Pelispedia.Service.DTOs;
using Pelispedia.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<ReportDTO> GetGeneralReport()
        {
            var viejaPelicula = await _reportRepository.GetPeliculaMasVieja();
            var nuevaPelicula = await _reportRepository.GetPeliculaMasNueva();
            var actorPelicula = await _reportRepository.GetActorConMasPelicula();
            var directorPelicula = await _reportRepository.GetDirectorConMasPeliculas();
            var TopMovies = await _reportRepository.GetTop5Peliculas();

            ReportDTO Reporte = new ReportDTO
            {
                ActorConMasPeliculas = actorPelicula.Nombre,
                CantidadDePelicuasActor = actorPelicula.NumPeliculas,
                CantidadDePeliculasDelDirector = directorPelicula.NumPeli,
                DirectorConMasPelicuas = directorPelicula.NombreDirector,
                TituloPeliculaNueva = nuevaPelicula.Titulo,
                PeliculaNuevaFechaEstreno = nuevaPelicula.Estreno,
                TitutloPeliculaMasVieja = viejaPelicula.Titulo,
                PeliculaViejaEstrenoFecha = viejaPelicula.Estreno,
            };
            foreach (var item in TopMovies)
            {
                Reporte.Top5Peliculas.Add(item);
            }
            return Reporte;
        }
    }
}
