using Derivco.Roulette.Api.DTO;
using Derivco.Roulette.Api.Middleware;
using Derivco.Roulette.Api.Services;
using Derivco.Roulette.Api.Validation;
using Derivco.Roulette.Infrastructure.Data;
using Derivco.Roullete.Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

namespace Derivco.VectorStock.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Roulette API", Version = "v1" });
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IValidator<PlayerBetRequest>, PlayerBetValidator>();

            string dbPath = Configuration.GetConnectionString("RouletteDatabase");
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string absolutePath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\..\"));
            string connectionString = $"Data Source={Path.Combine(absolutePath, dbPath)}";

            services.AddScoped<IRepositoryFacade>(e => new RepositoryFacacde(connectionString));
            services.AddScoped<IPlayerService, PlayerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Roulette API v1"));
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
