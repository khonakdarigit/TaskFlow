using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemDto>()
              .ForMember(dest => dest.AssignedUser, opt => opt.MapFrom(src => src.AssignedUser))
              .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project))
              .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachments))
              .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            CreateMap<TaskItemDto, TaskItem>();
        }
    }
}
