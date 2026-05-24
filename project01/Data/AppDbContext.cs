using Microsoft.EntityFrameworkCore;
using project01.Models;

namespace project01.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Train> Trains { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(local);Database=MetroDB;Trusted_Connection=True;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasPrecision(10, 2);
        }
    }
}