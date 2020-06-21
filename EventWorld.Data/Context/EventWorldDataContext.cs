using EventWorld.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventWorld.Data.Context
{
    public class EventWorldDataContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<EventGuest> EventGuests { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        public EventWorldDataContext(DbContextOptions<EventWorldDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventGuest>().HasKey(e => new { e.EventId, e.UserId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }


    }
}
