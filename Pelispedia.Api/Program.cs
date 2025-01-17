
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
            builder.Services.AddTransient<IDirectorRepository, DirectorRepository>();
            builder.Services.AddTransient<IPeliculaRepository, PeliculaRepository>();
            builder.Services.AddTransient<IGeneroRepository, GeneroRepository>();
            builder.Services.AddTransient<ICastingRepository, CastingRepository>();
            builder.Services.AddTransient<IReportRepository, ReportRepository>();

            builder.Services.AddTransient<IActorService, ActorService>();
            builder.Services.AddTransient<IPeliculaService, PeliculaService>();
            builder.Services.AddTransient<IGeneroService, GeneroService>();
            builder.Services.AddTransient<IDirectorService , DirectorService>();
            builder.Services.AddTransient<IReportService, ReportService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            // Agrega la política CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200") // Cambia esto a la URL de tu aplicación Angular
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
