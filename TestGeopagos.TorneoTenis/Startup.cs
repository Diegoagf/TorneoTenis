using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestGeopagos.TorneoTenis.Repositories;
using TestGeopagos.TorneoTenis.Services;
using TestGeopagos.TorneoTenis.Services.Impl;

namespace TestGeopagos.TorneoTenis
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
            services.AddControllers();
            services.AddTransient<IMongoDBContext, MongoDBContext>();
            services.AddTransient<ISimularTorneoService, SimularTorneoService>(); 
            services.AddTransient<IJugadoresService, JugadoresService>();       
            services.AddTransient<ITorneosRepository, TorneosRepository>();       
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Torneos-Tenis",
                    Description = "Api para simular Torneos en base a jugadores",
                    Contact = new OpenApiContact
                    {
                        Name = "Diego Gonzalez",
                        Url = new Uri("https://github.com/Diegoagf/TorneoTenis"),
                        Email = "alfonzoferrer97@gmail.com"
                    }
                });
                // Para habilitar los comentarios en el swagger
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
           
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
