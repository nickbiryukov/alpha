using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Alpha.Reservation.Extensions
{
    public static class WebHostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
                scope.ServiceProvider.GetRequiredService<TContext>().Database.Migrate();
            
            return host;
        }
    }
}