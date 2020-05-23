using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RotaDasTapas.Models.Configuration;
using RotaDasTapas.Repository;
using RotaDasTapas.Services;

namespace RotaDasTapas
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private static RotaDasTapasConfiguration _rotaDasTapasConfiguration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ITapasService, TapasService>();
            services.AddScoped<ITapasRepository, TapasRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Rota das Tapas",
                    Description = "A simple API for Rota das Tapas",
                    Contact = new OpenApiContact
                    {
                        Name = "Hugo Cabrita",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/ilusi0n"),
                    },
                });
                //activate xml comments in swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            // Set the comments path for the Swagger JSON and UI.
            SetupRotaDasTapasOptions(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rota das Tapas API");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void SetupRotaDasTapasOptions(IServiceCollection services, IConfiguration config)
        {
            services.Configure<RotaDasTapasConfiguration>(config.GetSection("RotaDasTapasConfiguration"));
            _rotaDasTapasConfiguration = config.GetSection("RotaDasTapasConfiguration").Get<RotaDasTapasConfiguration>();
        }
    }
}