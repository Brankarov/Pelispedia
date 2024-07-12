using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Pelispedia.Domain.DbEntities;
using Pelispedia.Infrastructure.Repositories.Interfaces;

namespace Pelispedia.Infrastructure.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public DirectorRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<Director> GetDirectorById(int id)
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT IdDirector, NombreDirector from Director WHERE IdDirector = @Id";
                var director = await connection.QueryFirstOrDefaultAsync<Director>(query, new { Id = id });
                return director;
            }
        }
        public async Task<Director> GetDirectorIdByName(string name)
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT IdDirector, NombreDirector from Director WHERE NombreDirector = @name";
                var director = await connection.QueryFirstOrDefaultAsync<Director>(query, new { name = name });
                return director;
            }
        }

        public async Task<IEnumerable<Director>> GetAllDirector()
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT IdDirector, NombreDirector from Director";
                var director = await connection.QueryAsync<Director>(query);
                return director;
            }
        }
    }
}
