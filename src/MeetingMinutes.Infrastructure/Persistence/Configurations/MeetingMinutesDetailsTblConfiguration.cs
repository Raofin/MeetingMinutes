using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingMinutes.Infrastructure.Persistence.Configurations;

public class MeetingMinutesDetailsTblConfiguration : IEntityTypeConfiguration<MeetingMinutesDetails>
{
    public void Configure(EntityTypeBuilder<MeetingMinutesDetails> entity)
    {
        entity.ToTable("Meeting_Minutes_Details_Tbl");
        entity.HasKey(e => e.DetailsId);

        entity.Property(e => e.Unit).HasMaxLength(255);

        entity.HasOne(d => d.ProductService)
            .WithMany(p => p.MeetingMinutesDetailsTbls)
            .HasForeignKey(d => d.ProductServiceId);
    }

}
