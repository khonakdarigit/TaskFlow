

using Application.DTOs;
using Application.DTOs.Project;

namespace Application.Interface
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> AllProjectAsync();
        Task<List<ProjectWithTaskCountDto>> AllUserProjectWithTaskCountAsync(string userId);
        Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto);
        Task<ProjectDto> GetProjectAsync(Guid id);
        Task<ProjectDto> GetProjectWithDeatilsAsync(Guid id);
    }
}
