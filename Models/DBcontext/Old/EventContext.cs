using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models
{
    public class IEventContextDepository : DbContext
    {
        public IEventContextDepository(DbContextOptions<IEventContextDepository> options)
            : base(options)
        {
        }

        public DbSet<EventData> EventList { get; set; }
    }
}