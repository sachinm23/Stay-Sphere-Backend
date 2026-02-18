using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Data;

public class StaySphereDbContext : DbContext
{
    public StaySphereDbContext(DbContextOptions<StaySphereDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();
    }
}
