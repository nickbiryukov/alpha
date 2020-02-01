using Microsoft.Extensions.DependencyInjection;

namespace Alpha.Reservation.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}