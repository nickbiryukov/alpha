using System;
using Alpha.Reservation.Data.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Alpha.Reservation.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, 
            Action<DataLayerOptions> optionsBuilder)
        {
            var dataLayerOptions = new DataLayerOptions();
            optionsBuilder?.Invoke(dataLayerOptions);

            services
                .AddSingleton(dataLayerOptions);

            services
                .ConfigureDbContext(dataLayerOptions.DbOptions);
            
            return services;
        }

        private static IServiceCollection ConfigureDbContext(this IServiceCollection services, DbOptions dbOptions)
        {
            services
                .AddSingleton(dbOptions)
                .AddDbContext<DatabaseContext>(a =>
                {
                    /*a.UseSqlServer(dbOptions.DbConnection, b =>
                        b.MigrationsAssembly(dbOptions.DbMigrationAssembly));*/

                    a.UseNpgsql(dbOptions.DbConnection, b =>
                        b.MigrationsAssembly(dbOptions.DbMigrationAssembly));
                    
                    //a.UseInMemoryDatabase("Alpha");
                });

            return services;
        }
    }
}