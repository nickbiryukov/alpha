using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

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
            
            services
                .AddMvcCore()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            return services;
        }

        private static IServiceCollection ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo { Title = "Alpha API", Version = "v1" });
            });

            return services;
        }
    }
}