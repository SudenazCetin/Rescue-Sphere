using RescueSphere.Api.Common;
using RescueSphere.Api.DTOs.HelpRequests;
using RescueSphere.Api.Services.Interfaces;

namespace RescueSphere.Api.Controllers.HelpRequests;

public static class HelpRequestEndpoints
{
    public static void MapHelpRequestEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/help-requests")
            .WithName("HelpRequests");

        group.MapGet("/", GetAllHelpRequests)
            .WithName("GetAllHelpRequests");

        group.MapGet("/{id:int}", GetHelpRequestById)
            .WithName("GetHelpRequestById");

        group.MapPut("/{id:int}", UpdateHelpRequest)
            .WithName("UpdateHelpRequest");

        group.MapDelete("/{id:int}", SoftDeleteHelpRequest)
            .WithName("SoftDeleteHelpRequest");
    }

    private static async Task<IResult> GetAllHelpRequests(IHelpRequestService service)
    {
        var list = await service.GetAllAsync();
        return Results.Ok(ApiResponse<List<HelpRequestResponseDto>>.Ok(list));
    }

    private static async Task<IResult> GetHelpRequestById(
        int id, 
        IHelpRequestService service)
    {
        var item = await service.GetByIdAsync(id);
        if (item is null)
            return Results.NotFound(ApiResponse<string>.Fail("Help request not found"));

        return Results.Ok(ApiResponse<HelpRequestResponseDto>.Ok(item));
    }

    private static async Task<IResult> UpdateHelpRequest(
        int id, 
        HelpRequestUpdateDto dto, 
        IHelpRequestService service)
    {
        var updated = await service.UpdateAsync(id, dto);
        if (updated is null)
            return Results.NotFound(ApiResponse<string>.Fail("Help request not found"));

        return Results.Ok(ApiResponse<HelpRequestResponseDto>.Ok(updated, "Help request updated"));
    }

    private static async Task<IResult> SoftDeleteHelpRequest(
        int id, 
        IHelpRequestService service)
    {
        var result = await service.SoftDeleteAsync(id);
        if (!result)
            return Results.NotFound(ApiResponse<string>.Fail("Help request not found"));

        return Results.Ok(ApiResponse<string>.Ok("", "Help request deleted"));
    }
}