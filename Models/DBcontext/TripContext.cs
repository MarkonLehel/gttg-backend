using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        {
        }

        public DbSet<TripData> TripList { get; set; }
    }
}