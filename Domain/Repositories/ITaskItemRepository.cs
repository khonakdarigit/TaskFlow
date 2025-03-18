using Domain.Entities;
using Domain.Repositories.Common;

namespace Domain.Repositories
{
    public interface ITaskItemRepository : IRepository<TaskItem>
    {
        int GetMaxTaskNumberInProject(Guid projectId);
        Task<TaskItem> GetTaskItemWithProjectAsync(Guid id);
    }
}
