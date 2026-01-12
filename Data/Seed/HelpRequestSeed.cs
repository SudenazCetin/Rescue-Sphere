using Microsoft.EntityFrameworkCore;
using RescueSphere.Api.Domain.Entities;

namespace RescueSphere.Api.Data.Seed;

public static class HelpRequestSeed
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<HelpRequest>().HasData(
            new HelpRequest
            {
                Id = 1,
                Title = "Acil Gıda Yardımı",
                Description = "Ailemiz için yardım talep ediyoruz, 3 kişilik aile",
                Location = "İstanbul, Sultangazi",
                Status = HelpRequestStatus.Pending,
                Priority = HelpRequestPriority.High,
                RequestedByUserId = 4,
                SupportCategoryId = 1,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new HelpRequest
            {
                Id = 2,
                Title = "Geçici Barınma İhtiyacı",
                Description = "Deprem nedeniyle evim hasar gördü, geçici barınma yardımı istiyorum",
                Location = "İzmir, Konak",
                Status = HelpRequestStatus.InProgress,
                Priority = HelpRequestPriority.Critical,
                RequestedByUserId = 5,
                SupportCategoryId = 2,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new HelpRequest
            {
                Id = 3,
                Title = "Sağlık Desteği",
                Description = "Yaşlı anne için ilaç ve tıbbi malzeme gerekli",
                Location = "Ankara, Çankaya",
                Status = HelpRequestStatus.Pending,
                Priority = HelpRequestPriority.Medium,
                RequestedByUserId = 4,
                SupportCategoryId = 3,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            }
        );
    }
}
