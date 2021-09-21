using System;
using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Models
{
    public class PlanetContext : DbContext
    {
        public PlanetContext(DbContextOptions<PlanetContext> options)
            : base(options)
        {
        }

        public DbSet<PlanetData> PLanetList { get; set; }
    }
}