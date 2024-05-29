using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingMinutes.Infrastructure.Persistence.Configurations;

public class IndividualCustomerTblConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> entity)
    {
        entity.ToTable("Individual_Customer_Tbl");
        entity.HasKey(e => e.CustomerId);

        entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(255);
    }
}
