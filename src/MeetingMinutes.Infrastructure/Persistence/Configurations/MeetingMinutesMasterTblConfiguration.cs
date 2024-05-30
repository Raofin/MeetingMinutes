using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingMinutes.Infrastructure.Persistence.Configurations;

public class MeetingMinutesMasterTblConfiguration : IEntityTypeConfiguration<MeetingMinutesMaster>
{
    public void Configure(EntityTypeBuilder<MeetingMinutesMaster> entity)
    {
        entity.ToTable("Meeting_Minutes_Master_Tbl");
        entity.HasKey(e => e.MeetingMinutesId);

        entity.Property(e => e.Agenda).IsRequired();
        entity.Property(e => e.ClientSide).IsRequired();
        entity.Property(e => e.Datetime).HasColumnType("datetime");
        entity.Property(e => e.Decision).IsRequired();
        entity.Property(e => e.Discussion).IsRequired();
        entity.Property(e => e.HostSide).IsRequired();
        entity.Property(e => e.Place).IsRequired().HasMaxLength(255);

        entity.HasOne(d => d.CorporateCustomer)
            .WithMany(p => p.MeetingMinutesMasterTbls)
            .HasForeignKey(d => d.CorporateCustomerId);

        entity.HasOne(d => d.IndividualCustomer)
            .WithMany(p => p.MeetingMinutesMasterTbls)
            .HasForeignKey(d => d.IndividualCustomerId);
    }
}
