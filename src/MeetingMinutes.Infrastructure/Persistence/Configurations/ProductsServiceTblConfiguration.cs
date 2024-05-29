using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingMinutes.Infrastructure.Persistence.Configurations;

public class ProductsServiceTblConfiguration : IEntityTypeConfiguration<ProductsService>
{
    public void Configure(EntityTypeBuilder<ProductsService> entity)
    {
        entity.ToTable("Products_Service_Tbl");
        entity.HasKey(e => e.ProductServiceId);

        entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
        entity.Property(e => e.Type).IsRequired().HasMaxLength(255);
    }
}
