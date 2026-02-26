using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Entities.Property;

namespace StaySphere.Infrastructure.Data;

public class StaySphereDbContext : DbContext
{
    public StaySphereDbContext(DbContextOptions<StaySphereDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<PropertyLocation> PropertyLocations { get; set; }
    public DbSet<PropertyImage> PropertyImages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();   

        modelBuilder.Entity<Property>()
            .Property(p => p.PropertyType);  

        modelBuilder.Entity<Property>()
            .Property(p => p.PricePerNight)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Property>()
            .HasOne(p => p.Location)
            .WithOne(l => l.Property)
            .HasForeignKey<PropertyLocation>(l => l.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Property>()
            .HasMany(p => p.Images)
            .WithOne(i => i.Property)
            .HasForeignKey(i => i.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
