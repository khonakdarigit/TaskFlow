using Application.DTOs.Project;
using AutoMapper;
using Domain.DTOs.Project;

namespace Application.Mappings.Project
{
    public class ProjectWithTaskCountProfile : Profile
    {
        public ProjectWithTaskCountProfile()
        {
            CreateMap<ProjectWithTaskCount, ProjectWithTaskCountDto>();


            CreateMap<ProjectWithTaskCountDto, ProjectWithTaskCount>();
        }
    }
}
