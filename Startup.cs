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
using gttgBackend.Models.Interfaces;
using gttgBackend.Models.Interfaces.SQL;

namespace gttgBackend
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000");
                                  });
            });

            services.AddDbContextPool<AppDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddScoped<IPlanetDataRepository, SQLPlanetDataRepository>();
            services.AddScoped<ILodgingDataRepository, SQLLodgingDataRepository>();
            services.AddScoped<IEventDataRepository, SQLEventDataRepository>();
            services.AddScoped<ITravelTypeRepository, SQLTravelTypeRepository>();
            //services.AddDbContext<PlanetContext>(opt =>
            //                                  opt.UseInMemoryDatabase("PlanetList"));
            //services.AddDbContext<LodgingContext>(opt =>
            //                                   opt.UseInMemoryDatabase("LodgingList"));
            //services.AddDbContext<EventContext>(opt =>
            //                                  opt.UseInMemoryDatabase("EventList"));
            //services.AddDbContext<TripContext>(opt =>
            //                                   opt.UseInMemoryDatabase("TripList"));
            //services.AddDbContext<TravelContext>(opt =>
            //                                   opt.UseInMemoryDatabase("TravelTypeList"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "gttgBackend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var scope = app.ApplicationServices.CreateScope();

            //TODO
            //var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
            //AddDefaultData(dbContext, "App_data/planets.json");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "gttgBackend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseHttpsRedirection();

        }

        private void AddDefaultData(AppDBContext context)
        {
            throw new NotImplementedException();
        }
    }
}
