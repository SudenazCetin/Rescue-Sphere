using Microsoft.EntityFrameworkCore;
using RescueSphere.Api.Domain.Entities;

namespace RescueSphere.Api.Data.Seed;

public static class UserSeed
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@rescuesphere.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Role = UserRole.Admin,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new User
            {
                Id = 2,
                Username = "volunteer_ali",
                Email = "ali@rescuesphere.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("volunteer123"),
                Role = UserRole.Volunteer,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new User
            {
                Id = 3,
                Username = "volunteer_fatma",
                Email = "fatma@rescuesphere.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("volunteer123"),
                Role = UserRole.Volunteer,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new User
            {
                Id = 4,
                Username = "citizen_mehmet",
                Email = "mehmet@rescuesphere.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("citizen123"),
                Role = UserRole.Citizen,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            },
            new User
            {
                Id = 5,
                Username = "citizen_zeynep",
                Email = "zeynep@rescuesphere.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("citizen123"),
                Role = UserRole.Citizen,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            }
        );
    }
}
