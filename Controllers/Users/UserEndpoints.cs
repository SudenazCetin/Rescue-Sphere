using RescueSphere.Api.Common;
using RescueSphere.Api.DTOs.Users;
using RescueSphere.Api.Services.Interfaces;

namespace RescueSphere.Api.Controllers.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/users")
            .WithName("Users");

        group.MapPost("/", CreateUser)
            .WithName("CreateUser");

        group.MapGet("/", GetAllUsers)
            .WithName("GetAllUsers");

        group.MapGet("/{id:int}", GetUserById)
            .WithName("GetUserById");

        group.MapPut("/{id:int}", UpdateUser)
            .WithName("UpdateUser");

        group.MapDelete("/{id:int}", SoftDeleteUser)
            .WithName("SoftDeleteUser");
    }

    private static async Task<IResult> CreateUser(
        CreateUserDto dto, 
        IUserService service)
    {
        var created = await service.CreateUserAsync(dto);
        return Results.Created($"/users/{created.Id}",
            ApiResponse<UserResponseDto>.Ok(created, "User created successfully"));
    }

    private static async Task<IResult> GetAllUsers(IUserService service)
    {
        var users = await service.GetAllAsync();
        return Results.Ok(ApiResponse<List<UserResponseDto>>.Ok(users));
    }

    private static async Task<IResult> GetUserById(
        int id, 
        IUserService service)
    {
        var user = await service.GetByIdAsync(id);
        if (user is null)
            return Results.NotFound(ApiResponse<string>.Fail("User not found"));

        return Results.Ok(ApiResponse<UserResponseDto>.Ok(user));
    }

    private static async Task<IResult> UpdateUser(
        int id, 
        UpdateUserDto dto, 
        IUserService service)
    {
        var updated = await service.UpdateAsync(id, dto);
        if (updated is null)
            return Results.NotFound(ApiResponse<string>.Fail("User not found"));

        return Results.Ok(ApiResponse<UserResponseDto>.Ok(updated, "User updated successfully"));
    }

    private static async Task<IResult> SoftDeleteUser(
        int id, 
        IUserService service)
    {
        var result = await service.SoftDeleteAsync(id);
        if (!result)
            return Results.NotFound(ApiResponse<string>.Fail("User not found"));

        return Results.Ok(ApiResponse<string>.Ok("", "User deleted successfully"));
    }
}
