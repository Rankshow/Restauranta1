using Microsoft.EntityFrameworkCore;
using Restauranta1.Domain.Entities;
namespace Restauranta1.Infrastructure.Persistence;

internal class RestaurantDbContext : DbContext
{     
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RestaurantsDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>()
            .OwnsOne(d => d.Address);

        modelBuilder.Entity<Restaurant>()
            .HasMany(p => p.Dishes)
            .WithOne()
            .HasForeignKey(r => r.RestaurantId);
    }
}
