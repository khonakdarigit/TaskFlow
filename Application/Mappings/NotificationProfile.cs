using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class NotificationProfile:Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>()
              .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));


            CreateMap<NotificationDto, Notification>();
        }
    }
}
