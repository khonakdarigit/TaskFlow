using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(dest => dest.AssignedTasks, opt => opt.MapFrom(src => src.AssignedTasks))
                .ForMember(dest => dest.Audits, opt => opt.MapFrom(src => src.Audits))
                .ForMember(dest => dest.OwnedProjects, opt => opt.MapFrom(src => src.OwnedProjects))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Logs, opt => opt.MapFrom(src => src.Logs))
                .ForMember(dest => dest.Notifications, opt => opt.MapFrom(src => src.Notifications));


            CreateMap<ApplicationUserDto, ApplicationUser>()
                .ForMember(dest => dest.AssignedTasks, opt => opt.MapFrom(src => src.AssignedTasks))
                .ForMember(dest => dest.Audits, opt => opt.MapFrom(src => src.Audits))
                .ForMember(dest => dest.OwnedProjects, opt => opt.MapFrom(src => src.OwnedProjects))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Logs, opt => opt.MapFrom(src => src.Logs))
                .ForMember(dest => dest.Notifications, opt => opt.MapFrom(src => src.Notifications));
        }
    }
}
