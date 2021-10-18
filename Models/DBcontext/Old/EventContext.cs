using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {
        }

        public DbSet<EventData> EventList { get; set; }
    }
}