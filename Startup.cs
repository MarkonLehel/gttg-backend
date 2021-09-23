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

            services.AddDbContext<PlanetContext>(opt =>
                                              opt.UseInMemoryDatabase("PlanetList"));
            services.AddDbContext<LodgingContext>(opt =>
                                               opt.UseInMemoryDatabase("LodgingList"));
            services.AddDbContext<EventContext>(opt =>
                                              opt.UseInMemoryDatabase("EventList"));
            services.AddDbContext<TripContext>(opt =>
                                               opt.UseInMemoryDatabase("TripList"));
            services.AddDbContext<TravelContext>(opt =>
                                               opt.UseInMemoryDatabase("TravelTypeList"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "gttgBackend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var scope= app.ApplicationServices.CreateScope();
            var planetContext = scope.ServiceProvider.GetRequiredService<PlanetContext>();
            var eventContext = scope.ServiceProvider.GetRequiredService<EventContext>();
            var lodgingContext = scope.ServiceProvider.GetRequiredService<LodgingContext>();
            var travelContext = scope.ServiceProvider.GetRequiredService<TravelContext>();
            var tripContext = scope.ServiceProvider.GetRequiredService<TripContext>();
            
            AddDefaultData(planetContext, "App_data/planets.json");
            AddDefaultData(eventContext, "App_data/events.json");
            AddDefaultData(lodgingContext, "App_data/lodgings.json");
            AddDefaultData(travelContext, "App_data/travelTypes.json");
            AddDefaultData(tripContext);
            Console.WriteLine("Yeet");

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

        private void AddDefaultData(TripContext tripContext)
        {
            TripData trip = new TripData(1, 2, 1, "2021-10-10", "2021-10-14", 1, new List<int>() { 1, 2 });
            System.Diagnostics.Debug.WriteLine(trip.ToString());
            tripContext.Add(trip);
            tripContext.SaveChanges();
        }

        private void AddDefaultData(PlanetContext context, string dataPath)
        {
            List<PlanetData> data = FileReader.ReadFile<PlanetData>(dataPath);
            foreach (PlanetData planet in data)
            {
                System.Diagnostics.Debug.WriteLine(planet.PlanetDataID);
                context.Entry(planet).State = EntityState.Detached;
                context.PLanetList.Add(planet);
            }

            context.SaveChanges();
        }

        private void AddDefaultData(EventContext context, string dataPath)
        {
            List<EventData> data = FileReader.ReadFile<EventData>(dataPath);
            foreach (EventData eventD in data)
            {
                context.Entry(eventD).State = EntityState.Detached;
                context.EventList.Add(eventD);
            }
            context.SaveChanges();
        }

        private void AddDefaultData(TravelContext context, string dataPath)
        {
            List<TravelType> data = FileReader.ReadFile<TravelType>(dataPath);
            foreach (TravelType travelType in data)
            {
                context.Entry(travelType).State = EntityState.Detached;
                context.TravelTypeList.Add(travelType);
            }
            context.SaveChanges();
        }

        private void AddDefaultData(LodgingContext context, string dataPath)
        {
            List<LodgingData> data = FileReader.ReadFile<LodgingData>(dataPath);
            foreach (LodgingData lodging in data)
            {
                context.Entry(lodging).State = EntityState.Detached;
                context.LodgingList.Add(lodging);
            }
            context.SaveChanges();
        }
    }
}
