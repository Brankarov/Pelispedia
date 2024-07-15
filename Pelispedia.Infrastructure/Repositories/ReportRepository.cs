using Pelispedia.Domain.ReportEntities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pelispedia.Domain.DbEntities;
using Pelispedia.Infrastructure.Repositories.Interfaces;

namespace Pelispedia.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public ReportRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<ActorConMasPeliculas> GetActorConMasPelicula()
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<ActorConMasPeliculas>("GetActorConMásPelicula", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<DirectorConMasPeliculas> GetDirectorConMasPeliculas()
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<DirectorConMasPeliculas>("GetDirectorConMasPeliculas", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<PeliculaConMasActor> GetPeliculaConCMasActor()
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<PeliculaConMasActor>("GetPeliculaConMasActor", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Pelicula> GetPeliculaMasVieja()
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<Pelicula>("GetPeliculaMasVieja", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Pelicula> GetPeliculaMasNueva()
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<Pelicula>("GetPeliculaUltimaEstrenada", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Pelicula>> GetTop5Peliculas()
        {
            using (var connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                return await connection.QueryAsync<Pelicula>("GetTop5PeliculasValoradas", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
