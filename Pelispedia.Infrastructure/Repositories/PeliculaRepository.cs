using Dapper;
using Pelispedia.Domain.DbEntities;
using Pelispedia.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
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

        public async Task InsertPelicula(Pelicula pelicula)
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                await connection.ExecuteAsync("INSERT INTO Pelicula(Titulo, Estreno, Valoracion, Sinopsis, IdDirector, IdGenero) VALUES(@Titulo, @Estreno, @Valoracion, @Sinopsis, @IdDirector, @IdGenero)", pelicula);
            }
        }

        public async Task ActualizarPelicula(Pelicula pelicula)
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                const string query = @"UPDATE Pelicula SET Titulo = @Titulo, Estreno = @Estreno, Valoracion = @Valoracion, Sinopsis = @Sinopsis, IdDirector = @IdDirector, IdGenero = @IdGenero
                WHERE IdPelicula = @IdPelicula";
                await connection.ExecuteAsync(query, pelicula);
            }
        }
    }
}
