using Dapper;
using Pelispedia.Domain.DbEntities;
using Pelispedia.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Infrastructure.Repositories
{
    public class CastingRepository : ICastingRepository
    {
        private readonly DatabaseConfig _databaseConsfig;
        public CastingRepository(DatabaseConfig databaseConfig)
        {
            _databaseConsfig = databaseConfig;
        }
        public async Task InsertCasting(Casting casting)
        {
            using (var connection = new SqlConnection(_databaseConsfig.ConnectionString))
            {
                connection.Open();
                await connection.ExecuteAsync("INSERT INTO Casting(IdPelicula, IdActor) VALUES(@IdPelicula, @IdActor)", casting);
            }
        }

        public async Task<Casting> GetCasting(Casting casting)
        {
            using (var connection = new SqlConnection(_databaseConsfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Casting WHERE IdPelicua = @IdPelicula, IdActor = @IdActor";
                var cast =  await connection.QueryFirstOrDefaultAsync<Casting>(query, new { IdPelicula = casting.IdPelicula, IdActor = casting.IdActor });
                return cast;
            }
        }

        public async Task<bool> DeleteCasting(int id)
        {
            using (var connection = new SqlConnection(_databaseConsfig.ConnectionString))
            {
                try
                {
                    connection.Open();
                    var query = "DELETE FROM Casting WHERE IdCasting = @Id";
                    await connection.ExecuteAsync(query, new { Id = id });
                    return true;

                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
