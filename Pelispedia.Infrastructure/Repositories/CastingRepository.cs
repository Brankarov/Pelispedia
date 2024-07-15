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
    }
}
