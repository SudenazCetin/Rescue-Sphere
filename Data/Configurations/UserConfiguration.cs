using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RescueSphere.Api.Domain.Entities;

namespace RescueSphere.Api.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.Role)
            .HasConversion<int>();

        builder.Property(u => u.CreatedAt)
            .IsRequired();

        builder.Property(u => u.IsDeleted)
            .HasDefaultValue(false);

        // Soft Delete Filter
        builder.HasQueryFilter(u => !u.IsDeleted);

        // Relationships
        builder.HasMany(u => u.HelpRequests)
            .WithOne(hr => hr.RequestedByUser)
            .HasForeignKey(hr => hr.RequestedByUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.VolunteerAssignments)
            .WithOne(va => va.VolunteerUser)
            .HasForeignKey(va => va.VolunteerUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
