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
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gttgBackend.Models;
using System.Text.Json;
using gttgBackend.Utils;


namespace gttgBackend
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "gttgBackend", Version = "v1" });
            });

            services.AddDbContext<PlanetContext>(opt =>
                                               opt.UseInMemoryDatabase("PlanetList"));
            services.AddDbContext<LodgingContext>(opt =>
                                               opt.UseInMemoryDatabase("LodgingList"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var scope= app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PlanetContext>();
            AddDefaultData(context, "App_data/planets.json");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "gttgBackend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void AddDefaultData(PlanetContext context, string dataPath)
        {
            List<PlanetData> data = FileReader.ReadFile(dataPath);
            foreach (PlanetData planet in data)
            {
                System.Diagnostics.Debug.WriteLine(planet.PlanetDataID);
                context.Entry<PlanetData>(planet).State = EntityState.Detached;
                context.PLanetList.Add(planet);
            }

            context.SaveChanges();
        }
    }
}
