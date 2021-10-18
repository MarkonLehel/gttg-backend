using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanetData>().HasData(
                new PlanetData("Planet1", "First planet in DB", 2, "F1", "Anonym", 10, 50)
                //new PlanetData
                //{
                //    PlanetDataID = 1,
                //    PlanetName = "Planet1",
                //    PlanetDescription = "First planet in DB",
                //    Population = 2,
                //    Race = "F1",
                //    ImageName = "Anonym",
                //    X = 10,
                //    Y = 50
                //}
            );
        }
    }
}
