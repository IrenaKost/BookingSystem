using BookingSystem.Domain.Bookings;
using BookingSystem.Domain.Resources;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
