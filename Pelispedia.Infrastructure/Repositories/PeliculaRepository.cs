using Dapper;
using Pelispedia.Domain.DbEntities;
using Pelispedia.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Infrastructure.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public PeliculaRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<Pelicula> GetPeliculaById(int id)
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT IdPelicula, Titulo, Estreno, Valoracion, Sinopsis, IdDIrector, IdGenero FROM Pelicula WHERE IdPelicula = @Id";
                var pelicula = await connection.QueryFirstOrDefaultAsync<Pelicula>(query, new { Id = id });
                return pelicula;
            }
        }

        public async Task<IEnumerable<Pelicula>> GetAllPeliculas()
        {
            using ( var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT IdPelicula, Titulo, Estreno, Valoracion, Sinopsis, IdDIrector, IdGenero FROM Pelicula";
                var peliculas = await connection.QueryAsync<Pelicula>(query);
                return peliculas;
            }
        }

        public async Task<IEnumerable<PeliculaDetailed>> GetMovieDetailed()
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                return connection.Query<PeliculaDetailed>("GetMovieDetails", commandType: CommandType.StoredProcedure);
            }
        }

        //public async Task<Pelicula> 
    }
}
