using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingMinutes.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<LogEvent> LogEvents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        //modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);
    }
}