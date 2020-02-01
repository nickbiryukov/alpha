using Alpha.Reservation.App;
using Alpha.Reservation.Data;
using Alpha.Reservation.Data.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Alpha.Reservation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddApiLayer()
                .AddAppLayer()
                .AddDataLayer(a =>
                {
                    a.DbOptions = new DbOptions
                    {
                        DbConnection = Configuration["DbSettings:DbConnection"],
                        DbMigrationAssembly = Configuration["DbSettings:DbMigrationAssembly"]
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger(); 
            
            app.UseSwaggerUI(a =>
            {
                a.SwaggerEndpoint("/swagger/v1/swagger.json", "Alpha API V1");
                a.RoutePrefix = "api/help";
            }); 

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}