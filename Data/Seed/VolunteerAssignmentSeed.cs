using Microsoft.EntityFrameworkCore;
using RescueSphere.Api.Domain.Entities;

namespace RescueSphere.Api.Data.Seed;

public static class VolunteerAssignmentSeed
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<VolunteerAssignment>().HasData(
            new VolunteerAssignment
            {
                Id = 1,
                HelpRequestId = 1,
                VolunteerUserId = 2,
                Status = AssignmentStatus.Assigned,
                AssignedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new VolunteerAssignment
            {
                Id = 2,
                HelpRequestId = 2,
                VolunteerUserId = 3,
                Status = AssignmentStatus.InProgress,
                AssignedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            }
        );
    }
}
