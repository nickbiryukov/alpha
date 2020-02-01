using Microsoft.Extensions.DependencyInjection;

namespace Alpha.Reservation.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}