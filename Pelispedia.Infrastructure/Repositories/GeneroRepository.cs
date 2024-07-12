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
    public class GeneroRepository : IGeneroRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public GeneroRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<Genero> GetGeneroById(int id)
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Genero WHERE IdGenero = @Id";
                var genero = await connection.QueryFirstOrDefaultAsync<Genero>(query, new { Id = id });
                return genero;
            }
        }
        public async Task<Genero> GetGeneroIdByName(string name)
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Genero WHERE NombreGenero = @name";
                var director = await connection.QueryFirstOrDefaultAsync<Genero>(query, new { name = name });
                return director;
            }
        }

        public async Task<IEnumerable<Genero>> GetAllGeneros()
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Genero";
                var genero = await connection.QueryAsync<Genero>(query);
                return genero;
            }
        }
    }
}
