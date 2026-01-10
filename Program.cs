using Microsoft.EntityFrameworkCore;
using RescueSphere.Api.Data;
using RescueSphere.Api.Services.Interfaces;
using RescueSphere.Api.Services.Implementations;
using RescueSphere.Api.Controllers.Users;
using RescueSphere.Api.Controllers.Categories;
using RescueSphere.Api.Controllers.HelpRequests;
using RescueSphere.Api.Controllers.VolunteerAssignments;

var builder = WebApplication.CreateBuilder(args);

// ================== DATABASE ==================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=rescueSphere.db"));

// ================== SERVICES ==================
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISupportCategoryService, SupportCategoryService>();
builder.Services.AddScoped<IHelpRequestService, HelpRequestService>();
builder.Services.AddScoped<IVolunteerAssignmentService, VolunteerAssignmentService>();

// ================== SWAGGER ==================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "RescueSphere API",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RescueSphere API v1");
});

// ================= MAP ENDPOINTS =================
app.MapUserEndpoints();
app.MapCategoryEndpoints();
app.MapHelpRequestEndpoints();
app.MapVolunteerAssignmentEndpoints();

// ================= ROOT =================
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

app.Run();