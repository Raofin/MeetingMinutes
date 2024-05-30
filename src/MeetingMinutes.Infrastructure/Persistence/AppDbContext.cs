using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingMinutes.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; } = null!;
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; } = null!;
    public DbSet<MeetingMinutesMaster> MeetingMinutesMasters { get; set; } = null!;
    public DbSet<MeetingMinutesDetails> MeetingMinutesDetails { get; set; } = null!;
    public DbSet<ProductsService> ProductsServices { get; set; } = null!;
    public DbSet<LogEvent> LogEvents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);
    }
}