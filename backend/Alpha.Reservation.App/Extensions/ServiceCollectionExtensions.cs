using System;
using Alpha.Reservation.App.Hashing;
using Alpha.Reservation.App.Hashing.Contracts;
using Alpha.Reservation.App.JwtAuthentication;
using Alpha.Reservation.App.JwtAuthentication.Contracts;
using Alpha.Reservation.App.MappingProfiles;
using Alpha.Reservation.App.Options;
using Alpha.Reservation.App.Services;
using Alpha.Reservation.App.Services.Contracts;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Alpha.Reservation.App.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppLayer(this IServiceCollection services,
            Action<AppLayerOptions> optionsBuilder)
        {
            var appLayerOptions = new AppLayerOptions();
            optionsBuilder?.Invoke(appLayerOptions);

            services
                .AddSingleton(appLayerOptions)
                .AddSingleton(appLayerOptions.JwtTokenOptions);

            services
                .ConfigureAutoMapper()
                .ConfigureHashProvider()
                .ConfigureTokenProvider()
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

        private static IServiceCollection ConfigureTokenProvider(this IServiceCollection services) =>
            services.AddScoped<ITokenProvider, TokenProvider>();

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