using RescueSphere.Api.Common;
using RescueSphere.Api.DTOs.Categories;
using RescueSphere.Api.Services.Interfaces;

namespace RescueSphere.Api.Controllers.Categories;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/categories")
            .WithName("Categories");

        group.MapPost("/", CreateCategory)
            .WithName("CreateCategory");

        group.MapGet("/", GetAllCategories)
            .WithName("GetAllCategories");

        group.MapGet("/{id:int}", GetCategoryById)
            .WithName("GetCategoryById");

        group.MapPut("/{id:int}", UpdateCategory)
            .WithName("UpdateCategory");

        group.MapDelete("/{id:int}", SoftDeleteCategory)
            .WithName("SoftDeleteCategory");
    }

    private static async Task<IResult> CreateCategory(
        SupportCategoryCreateDto dto, 
        ISupportCategoryService service)
    {
        var created = await service.CreateAsync(dto);
        return Results.Created($"/categories/{created.Id}",
            ApiResponse<SupportCategoryResponseDto>.Ok(created, "Category created"));
    }

    private static async Task<IResult> GetAllCategories(ISupportCategoryService service)
    {
        var list = await service.GetAllAsync();
        return Results.Ok(ApiResponse<List<SupportCategoryResponseDto>>.Ok(list));
    }

    private static async Task<IResult> GetCategoryById(
        int id, 
        ISupportCategoryService service)
    {
        var category = await service.GetByIdAsync(id);
        if (category is null)
            return Results.NotFound(ApiResponse<string>.Fail("Category not found"));

        return Results.Ok(ApiResponse<SupportCategoryResponseDto>.Ok(category));
    }

    private static async Task<IResult> UpdateCategory(
        int id, 
        SupportCategoryUpdateDto dto, 
        ISupportCategoryService service)
    {
        var updated = await service.UpdateAsync(id, dto);
        if (updated is null)
            return Results.NotFound(ApiResponse<string>.Fail("Category not found"));

        return Results.Ok(ApiResponse<SupportCategoryResponseDto>.Ok(updated, "Category updated"));
    }

    private static async Task<IResult> SoftDeleteCategory(
        int id, 
        ISupportCategoryService service)
    {
        var deleted = await service.SoftDeleteAsync(id);
        if (!deleted)
            return Results.NotFound(ApiResponse<string>.Fail("Category not found"));

        return Results.Ok(ApiResponse<string>.Ok("", "Category deleted"));
    }
}
