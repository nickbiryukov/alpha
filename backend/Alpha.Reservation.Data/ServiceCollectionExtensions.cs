using System;
using Alpha.Reservation.Data.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Alpha.Reservation.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, 
            Action<DataLayerOptions> optionsBuilder)
        {
            var options = new DataLayerOptions();
            optionsBuilder?.Invoke(options);

            services
                .AddSingleton(options);

            services
                .ConfigureDbContext(options.DbOptions);
            
            return services;
        }

        private static IServiceCollection ConfigureDbContext(this IServiceCollection services, DbOptions dbOptions)
        {
            services
                .AddSingleton(dbOptions)
                .AddDbContext<DatabaseContext>(a =>
                {
                    a.UseSqlServer(dbOptions.DbConnection, b =>
                        b.MigrationsAssembly(dbOptions.DbMigrationAssembly));
                });

            return services;
        }
    }
}