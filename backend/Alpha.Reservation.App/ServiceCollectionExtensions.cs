using Alpha.Reservation.App.Hashing;
using Alpha.Reservation.App.Hashing.Contracts;
using Alpha.Reservation.App.Mappings;
using Alpha.Reservation.App.Services;
using Alpha.Reservation.App.Services.Contracts;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Alpha.Reservation.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppLayer(this IServiceCollection services)
        {
            services
                .ConfigureAutoMapper()
                .ConfigureHashProvider()
                .ConfigureAccountService()
                .ConfigureReservationService()
                .ConfigureRoomService()
                .ConfigureUserService();
            
            return services;
        }
        
        private static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(a =>
            {
                a.AddProfile(new RoomMappingProfile());
                a.AddProfile(new UserMappingProfile());
                a.AddProfile(new ReservationMappingProfile());
            });

            services.AddSingleton(mappingConfig.CreateMapper());

            return services;
        }

        private static IServiceCollection ConfigureHashProvider(this IServiceCollection services) =>
            services.AddScoped<IHashProvider, HashProvider>();
        
        private static IServiceCollection ConfigureAccountService(this IServiceCollection services) =>
            services.AddScoped<IAccountService, AccountService>();
        
        private static IServiceCollection ConfigureReservationService(this IServiceCollection services) =>
            services.AddScoped<IReservationService, ReservationService>();
        
        private static IServiceCollection ConfigureRoomService(this IServiceCollection services) =>
            services.AddScoped<IRoomService, RoomService>();
        
        private static IServiceCollection ConfigureUserService(this IServiceCollection services) =>
            services.AddScoped<IUserService, UserService>();
    }
}