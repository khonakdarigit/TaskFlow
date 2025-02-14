

using Application.DTOs;

namespace Application.Interface
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> AllProjectAsync();
        Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto);
        Task<ProjectDto> GetProjectAsync(Guid id);
    }
}
