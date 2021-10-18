using gttgBackend.Models.Extensions;
using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
        }

        public DbSet<EventData> EventList { get; set; }
        public DbSet<TravelType> TravelTypeList { get; set; }
        public DbSet<LodgingData> LodgingList { get; set; }
        public DbSet<PlanetData> PLanetList { get; set; }
        public DbSet<TripData> TripList { get; set; }
    }
}