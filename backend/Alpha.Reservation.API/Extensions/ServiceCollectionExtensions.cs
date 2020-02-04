using System;
using System.Collections.Generic;
using System.Text;
using Alpha.Reservation.API.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Alpha.Reservation.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services,
            Action<ApiLayerOptions> optionsBuilder)
        {
            var apiLayerOptions = new ApiLayerOptions();
            optionsBuilder?.Invoke(apiLayerOptions);

            services
                .AddSingleton(apiLayerOptions);

            services
                .ConfigureMvc()
                .ConfigureJwtAuthentication(apiLayerOptions.JwtTokenOptions)
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

        private static IServiceCollection ConfigureJwtAuthentication(this IServiceCollection services,
            JwtTokenOptions jwtTokenOptions)
        {
            services
                .AddSingleton(jwtTokenOptions)
                .AddAuthentication(a =>
                {
                    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(a =>
                {
                    var securityKeyBytes = Encoding.ASCII.GetBytes(jwtTokenOptions.SecurityKey);

                    a.RequireHttpsMetadata = false;
                    a.SaveToken = true;
                    a.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(securityKeyBytes),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }

        private static IServiceCollection ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo {Title = "Alpha API", Version = "v1"});

                a.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization with jwt token (bearer -token-)",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer"
                });

                a.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}