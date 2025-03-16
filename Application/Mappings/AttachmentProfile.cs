using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class AttachmentProfile : Profile
    {
        public AttachmentProfile()
        {
            CreateMap<Attachment, AttachmentDto>()
               .ForMember(dest => dest.Task, opt => opt.MapFrom(src => src.Task));


            CreateMap<AttachmentDto, Attachment>();
        }
    }
}
