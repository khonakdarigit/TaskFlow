using Application.DTOs;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;
using MapsterMapper;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        public ProjectService(
            IMapper mapper,
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectDto>> AllProjectAsync()
        {
            var allProjects= await _projectRepository.GetAllAsync();
            return _mapper.Map<List<ProjectDto>>(allProjects);
        }

        public async Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> GetProjectAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            return _mapper.Map<ProjectDto>(project);
        }
    }
}
