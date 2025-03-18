using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskItemRepository : Repository<TaskItem>, ITaskItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetMaxTaskNumberInProject(Guid projectId)
        {
            return _context.Tasks
                .Where(c => c.ProjectId == projectId)
                .Select(c => (int?)c.TaskNumber)
                .Max() ?? 0;
        }

        public Task<TaskItem> GetTaskItemWithProjectAsync(Guid id)
        {
            return _context.Tasks
                .Include(c => c.Project)
                .FirstAsync(c => c.Id == id);
        }
    }
}
