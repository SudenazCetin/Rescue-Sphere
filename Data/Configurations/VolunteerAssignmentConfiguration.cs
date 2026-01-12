using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RescueSphere.Api.Domain.Entities;

namespace RescueSphere.Api.Data.Configurations;

public class VolunteerAssignmentConfiguration : IEntityTypeConfiguration<VolunteerAssignment>
{
    public void Configure(EntityTypeBuilder<VolunteerAssignment> builder)
    {
        builder.HasKey(va => va.Id);

        builder.Property(va => va.AssignedAt)
            .IsRequired();

        builder.Property(va => va.Status)
            .HasConversion<int>();

        builder.Property(va => va.CreatedAt)
            .IsRequired();

        builder.Property(va => va.IsDeleted)
            .HasDefaultValue(false);

        // Soft Delete Filter
        builder.HasQueryFilter(va => !va.IsDeleted);

        // Foreign Keys
        builder.HasOne(va => va.HelpRequest)
            .WithMany(hr => hr.VolunteerAssignments)
            .HasForeignKey(va => va.HelpRequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(va => va.VolunteerUser)
            .WithMany(u => u.VolunteerAssignments)
            .HasForeignKey(va => va.VolunteerUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
