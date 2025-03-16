using Domain.DTOs.Project;
using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<ProjectWithTaskCount>> AllUserProjectWithTaskCountAsync(string userId);
        Task<Project> GetProjectWithDeatilsByIdAsync(Guid id);
    }
}
