using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RescueSphere.Api.Domain.Entities;

namespace RescueSphere.Api.Data.Configurations;

public class HelpRequestConfiguration : IEntityTypeConfiguration<HelpRequest>
{
    public void Configure(EntityTypeBuilder<HelpRequest> builder)
    {
        builder.HasKey(hr => hr.Id);

        builder.Property(hr => hr.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(hr => hr.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(hr => hr.Location)
            .HasMaxLength(300);

        builder.Property(hr => hr.Status)
            .HasConversion<int>();

        builder.Property(hr => hr.Priority)
            .HasConversion<int>();

        builder.Property(hr => hr.CreatedAt)
            .IsRequired();

        builder.Property(hr => hr.IsDeleted)
            .HasDefaultValue(false);

        // Soft Delete Filter
        builder.HasQueryFilter(hr => !hr.IsDeleted);

        // Foreign Keys
        builder.HasOne(hr => hr.RequestedByUser)
            .WithMany(u => u.HelpRequests)
            .HasForeignKey(hr => hr.RequestedByUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(hr => hr.SupportCategory)
            .WithMany(sc => sc.HelpRequests)
            .HasForeignKey(hr => hr.SupportCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relationships
        builder.HasMany(hr => hr.VolunteerAssignments)
            .WithOne(va => va.HelpRequest)
            .HasForeignKey(va => va.HelpRequestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
