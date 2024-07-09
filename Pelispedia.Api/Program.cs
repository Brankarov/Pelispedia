
using Pelispedia.Infrastructure;
using Pelispedia.Infrastructure.Repositories;
using Pelispedia.Infrastructure.Repositories.Interfaces;
using Pelispedia.Service.Services;
using Pelispedia.Service.Services.Interface;

namespace Pelispedia.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("DatabaseConfig"));
            builder.Services.AddSingleton(provider =>
                {
                    return provider.GetService<IConfiguration>().GetSection("DatabaseConfig").Get<DatabaseConfig>();
                }
            );
            builder.Services.AddTransient<IActorRepository, ActorRepository>();
            builder.Services.AddTransient<IActorService, ActorService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
