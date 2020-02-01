using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Alpha.Reservation.API
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services)
        {
            services
                .ConfigureMvc()
                .ConfigureSwaggerGen();

            return services;
        }

        private static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services
                .AddControllers();

            return services;
        }

        private static IServiceCollection ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            return services;
        }
    }
}