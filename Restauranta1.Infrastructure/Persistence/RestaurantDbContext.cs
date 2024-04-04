using Microsoft.EntityFrameworkCore;
using Restauranta1.Domain.Entities;
namespace Restauranta1.Infrastructure.Persistence;

internal class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) 
    : DbContext(options)
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

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
