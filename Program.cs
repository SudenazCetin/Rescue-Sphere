using Microsoft.EntityFrameworkCore;
using RescueSphere.Api.Data;
using RescueSphere.Api.Services.Interfaces;
using RescueSphere.Api.Services.Implementations;
using RescueSphere.Api.Controllers.Users;
using RescueSphere.Api.Controllers.Categories;
using RescueSphere.Api.Controllers.HelpRequests;
using RescueSphere.Api.Controllers.VolunteerAssignments;
using RescueSphere.Api.Common.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ================== DATABASE ==================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "Data Source=rescueSphere.db";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

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

// ================== AUTO MIGRATION & SEED ====================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

// ================== SWAGGER (Development Only) ==================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RescueSphere API v1");
        c.RoutePrefix = "swagger";
    });
}

// ================= MAP ENDPOINTS =================
app.MapUserEndpoints();
app.MapCategoryEndpoints();
app.MapHelpRequestEndpoints();
app.MapVolunteerAssignmentEndpoints();

// ================= ROOT =================
app.MapGet("/", () => app.Environment.IsDevelopment() 
    ? Results.Redirect("/swagger/index.html") 
    : Results.Ok(new { message = "RescueSphere API is running", version = "v1.0", status = "healthy" }));

app.Run();