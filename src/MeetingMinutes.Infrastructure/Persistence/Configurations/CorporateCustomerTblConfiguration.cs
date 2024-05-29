using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingMinutes.Infrastructure.Persistence.Configurations;

public class CorporateCustomerTblConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> entity)
    {
        entity.ToTable("Corporate_Customer_Tbl");
        entity.HasKey(e => e.CustomerId);

        entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(255);
    }
}
