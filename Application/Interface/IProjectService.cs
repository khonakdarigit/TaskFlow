

using Application.DTOs;

namespace Application.Interface
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto);
    }
}
