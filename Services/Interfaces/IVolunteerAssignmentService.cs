using RescueSphere.Api.DTOs.VolunteerAssignments;

namespace RescueSphere.Api.Services.Interfaces;

public interface IVolunteerAssignmentService
{
    Task AssignAsync(VolunteerAssignmentCreateDto dto);
    Task<List<VolunteerAssignmentResponseDto>> GetAllAsync();
    Task<VolunteerAssignmentResponseDto> GetByIdAsync(int id);
}
