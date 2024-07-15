using Pelispedia.Domain.DbEntities;
using Pelispedia.Domain.ReportEntities;

namespace Pelispedia.Infrastructure.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<ActorConMasPeliculas> GetActorConMasPelicula();
        Task<DirectorConMasPeliculas> GetDirectorConMasPeliculas();
        Task<PeliculaConMasActor> GetPeliculaConCMasActor();
        Task<Pelicula> GetPeliculaMasNueva();
        Task<Pelicula> GetPeliculaMasVieja();
        Task<IEnumerable<Pelicula>> GetTop5Peliculas();
    }
}