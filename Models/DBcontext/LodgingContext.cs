using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models
{
    public class LodgingContext : DbContext
    {
        public LodgingContext(DbContextOptions<LodgingContext> options)
            : base(options)
        {
        }

        public DbSet<LodgingData> LodgingList { get; set; }
    }
}