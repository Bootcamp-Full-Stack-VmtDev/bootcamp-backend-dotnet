using LaboratorioUdemy.Application.Interfaces.Services;
using LaboratorioUdemy.Application.Services;
using LaboratorioUdemy.Domain.Database.SqlServer.Context;
using LaboratorioUdemy.Domain.Interfaces.Repositories;
using LaboratorioUdemy.Infrastructure.Persistence.SqlServer.Repositories;

namespace LaboratorioUdemy.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Metodo que sirve para añadir otros servicios de la aplicacion
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IInstructorService, InstructorService>();

        }

        /// <summary>
        /// Metodo que sirve para añadir otros respositorios de la aplicacion
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            // Database - Repositories
            services.AddTransient<IInstructorRepository, InstructorRepository>();

        }

        /// <summary>
        /// Metodo que añade lo esencial que necesita nuestra aplicacion para funcionar
        /// </summary>
        /// <param name="services"></param>
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();

            // Database
            services.AddSqlServer<UdemyClonContext>(configuration.GetConnectionString("Database"));

            services.AddServices();
            services.AddRepositories();
        }
    }
}
