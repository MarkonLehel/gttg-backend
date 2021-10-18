using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanetData>().HasData(
                new PlanetData("Planet1", "First planet in DB", 2, "F1", "Anonym", 10, 50)
            );
        }
    }
}
