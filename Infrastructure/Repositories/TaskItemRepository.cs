using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Common;

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
    }
}
