using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Reto.Api.Middleware;
using Reto.Infraestructura.Promocion.Command;
using Reto.IPersistencia.Promocion;
using Reto.Persistencia;
using Reto.Persistencia.Promocion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reto.Api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reto.Api", Version = "v1" });
                c.CustomSchemaIds(c => c.FullName);
            });
            services.AddDbContext<ModeloContext>(opt => {
                opt.UseNpgsql(Configuration.GetConnectionString("Modelo"));
            });
            services.AddMediatR(typeof(GenerarCodigo.Request).Assembly);
            services.AddCors(o => o.AddPolicy("corsApp", builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddScoped<IPromocionReadDb, PromocionReadDb>();
            services.AddScoped<IPromocionWriteDb, PromocionWriteDb>();
                
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
           
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reto.Api v1"));
            app.UseRouting();
            app.UseCors("corsApp");
            app.UseAuthorization();
            app.UseMiddleware<ErrorMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
