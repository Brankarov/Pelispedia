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
    }
}
