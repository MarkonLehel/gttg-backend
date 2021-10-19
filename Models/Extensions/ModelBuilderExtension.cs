using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //PlanetData
            modelBuilder.Entity<PlanetData>().HasData(
                new PlanetData("Planet1", "First planet in DB", 2, "F1", "Anonym", 10, 50)
            );
            //LodgingData
            modelBuilder.Entity<LodgingData>().HasData(
                new LodgingData(1, "Costa Cafe", "Middle of nowhere", 49.99f, 4)
            );
             //EventData
            modelBuilder.Entity<EventData>().HasData(
                new EventData("Party hat trading convention","Asteroid 9484643",250, new System.DateTime(2054,4,15))
            );
            //TravelTypes
            modelBuilder.Entity<TravelType>().HasData(
                new TravelType("SpaceBus",7,25.5f)
            );
        }
    }
}
