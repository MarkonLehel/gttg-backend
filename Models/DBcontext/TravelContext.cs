using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

        public DbSet<TravelType> TravelTypeList { get; set; }
    }
}