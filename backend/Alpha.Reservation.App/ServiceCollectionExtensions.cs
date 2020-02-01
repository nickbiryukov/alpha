using Microsoft.Extensions.DependencyInjection;

namespace Alpha.Reservation.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}