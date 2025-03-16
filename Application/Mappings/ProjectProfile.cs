using Application.DTOs;
using AutoMapper;

namespace Application.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Domain.Entities.Project, ProjectDto>()
              .ForMember(dest => dest.TaskItems, opt => opt.MapFrom(src => src.TaskItems))
              .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner));


            CreateMap<ProjectDto, Domain.Entities.Project>();
        }
    }
}
