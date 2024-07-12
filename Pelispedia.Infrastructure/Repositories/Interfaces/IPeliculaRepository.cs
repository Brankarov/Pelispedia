using Pelispedia.Domain.DbEntities;

namespace Pelispedia.Infrastructure.Repositories.Interfaces
{
    public interface IPeliculaRepository
    {
        Task<Pelicula> GetPeliculaById(int id);
        Task<IEnumerable<Pelicula>> GetAllPeliculas();
        Task<IEnumerable<PeliculaDetailed>> GetMovieDetailed();
        Task InsertPelicula(Pelicula pelicula);
        Task ActualizarPelicula(Pelicula pelicula);
    }
}