using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RescueSphere.Api.Domain.Entities;

namespace RescueSphere.Api.Data.Configurations;

public class SupportCategoryConfiguration : IEntityTypeConfiguration<SupportCategory>
{
    public void Configure(EntityTypeBuilder<SupportCategory> builder)
    {
        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(sc => sc.Description)
            .HasMaxLength(500);

        builder.Property(sc => sc.CreatedAt)
            .IsRequired();

        builder.Property(sc => sc.IsDeleted)
            .HasDefaultValue(false);

        // Soft Delete Filter
        builder.HasQueryFilter(sc => !sc.IsDeleted);

        // Relationships
        builder.HasMany(sc => sc.HelpRequests)
            .WithOne(hr => hr.SupportCategory)
            .HasForeignKey(hr => hr.SupportCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
