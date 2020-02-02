using System.Reflection;
using Alpha.Reservation.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Reservation.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Entities.Reservation> Reservations { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}