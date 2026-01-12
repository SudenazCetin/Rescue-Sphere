using Microsoft.EntityFrameworkCore;
using RescueSphere.Api.Domain.Entities;

namespace RescueSphere.Api.Data.Seed;

public static class SupportCategorySeed
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<SupportCategory>().HasData(
            new SupportCategory
            {
                Id = 1,
                Name = "Gıda",
                Description = "Yiyecek ve içecek yardımı",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new SupportCategory
            {
                Id = 2,
                Name = "Barınma",
                Description = "Acil barınma ve konaklama yardımı",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new SupportCategory
            {
                Id = 3,
                Name = "Sağlık",
                Description = "Tıbbi yardım ve sağlık hizmetleri",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new SupportCategory
            {
                Id = 4,
                Name = "Nakliye",
                Description = "Taşınma ve ulaştırma yardımı",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            }
        );
    }
}
