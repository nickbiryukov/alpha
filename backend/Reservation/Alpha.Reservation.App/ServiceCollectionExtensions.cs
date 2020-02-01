using Microsoft.Extensions.DependencyInjection;

namespace Alpha.Reservation.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}