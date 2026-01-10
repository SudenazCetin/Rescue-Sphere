using Microsoft.EntityFrameworkCore;
using RescueSphere.Api.Data.Seed;
using RescueSphere.Api.Domain.Entities;

namespace RescueSphere.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<SupportCategory> SupportCategories => Set<SupportCategory>();
    public DbSet<HelpRequest> HelpRequests => Set<HelpRequest>();
    public DbSet<VolunteerAssignment> VolunteerAssignments => Set<VolunteerAssignment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Seed data
        UserSeed.Seed(modelBuilder);
        SupportCategorySeed.Seed(modelBuilder);
        HelpRequestSeed.Seed(modelBuilder);
        VolunteerAssignmentSeed.Seed(modelBuilder);

        base.OnModelCreating(modelBuilder);

    }
}
