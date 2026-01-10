using RescueSphere.Api.Common;
using RescueSphere.Api.DTOs.VolunteerAssignments;
using RescueSphere.Api.Services.Interfaces;

namespace RescueSphere.Api.Controllers.VolunteerAssignments;

public static class VolunteerAssignmentEndpoints
{
    public static void MapVolunteerAssignmentEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/volunteer-assignments")
            .WithName("VolunteerAssignments");

        group.MapPost("/", AssignVolunteer)
            .WithName("AssignVolunteer");

        group.MapGet("/", GetAllAssignments)
            .WithName("GetAllAssignments");

        group.MapGet("/{id:int}", GetAssignmentById)
            .WithName("GetAssignmentById");
    }

    private static async Task<IResult> AssignVolunteer(
        VolunteerAssignmentCreateDto dto,
        IVolunteerAssignmentService service)
    {
        var result = await service.AssignAsync(dto);

        if (!result)
            return Results.BadRequest(
                ApiResponse<string>.Fail("HelpRequest not found"));

        return Results.Ok(
            ApiResponse<string>.Ok("", "Volunteer assigned successfully"));
    }

    private static async Task<IResult> GetAllAssignments(
        IVolunteerAssignmentService service)
    {
        var assignments = await service.GetAllAsync();
        return Results.Ok(ApiResponse<List<VolunteerAssignmentResponseDto>>.Ok(assignments));
    }

    private static async Task<IResult> GetAssignmentById(
        int id,
        IVolunteerAssignmentService service)
    {
        var assignment = await service.GetByIdAsync(id);
        if (assignment is null)
            return Results.NotFound(ApiResponse<string>.Fail("Assignment not found"));

        return Results.Ok(ApiResponse<VolunteerAssignmentResponseDto>.Ok(assignment));
    }
}
