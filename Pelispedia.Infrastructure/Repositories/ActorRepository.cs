using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Pelispedia.Domain.DbEntities;
using Pelispedia.Infrastructure.Repositories.Interfaces;


namespace Pelispedia.Infrastructure.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly DatabaseConfig _databaseConsfig;

        public ActorRepository(DatabaseConfig databaseConfig)
        {
            _databaseConsfig = databaseConfig;
        }

        public async Task InsertActor(Actor actor)
        {
            using (var connection = new SqlConnection(_databaseConsfig.ConnectionString))
            {
                connection.Open();
                await connection.ExecuteAsync("INSERT INTO Actor(Nombre, Raza, Sexo) VALUES(@Nombre, @Raza, @Sexo)", actor);
            }
        }

        public async Task<IEnumerable<Actor>> GetActores()
        {
            using (var connection = new SqlConnection(_databaseConsfig.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Actor";
                var actores = await connection.QueryAsync<Actor>(query);
                return actores;
            }
        }

        public async Task<Actor> GetActorByName(string nombre)
        {
            using (var connection = new SqlConnection(_databaseConsfig.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Actor WHERE Nombre = @Nombre";
                var actore = await connection.QueryFirstOrDefaultAsync<Actor>(query, new { Nombre = nombre});
                return actore;
            }
        }

        public async Task<List<Actor>> GetActorsByNames(List<string> nombres)
        {
            using (var connection = new SqlConnection(_databaseConsfig.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Actor WHERE Nombre IN @Nombres";
                var actores = await connection.QueryAsync<Actor>(query, new { Nombres = nombres });
                return actores.ToList();
            }
        }
    }
}
