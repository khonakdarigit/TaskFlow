using Domain.DTOs.Project;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProjectWithTaskCount>> AllUserProjectWithTaskCountAsync(string userId)
        {
            return await _context.Projects
                .Where(c => c.OwnerId == userId)
                .Select(p => new ProjectWithTaskCount
                {
                    ProjectId = p.Id,
                    ProjectName = p.Name,
                    TaskCount = p.TaskItems.Count
                })
                .ToListAsync();
        }

        public async Task<Project> GetProjectWithDeatilsByIdAsync(Guid id)
        {
            return await _context.Projects
                .Include(c => c.TaskItems)
                .FirstAsync(c => c.Id == id);
        }
    }
}
