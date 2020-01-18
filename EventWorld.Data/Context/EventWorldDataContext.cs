using Microsoft.EntityFrameworkCore;

namespace EventWorld.Data.Context
{
    public class EventWorldDataContext : DbContext
    {
        public EventWorldDataContext(DbContextOptions<EventWorldDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
