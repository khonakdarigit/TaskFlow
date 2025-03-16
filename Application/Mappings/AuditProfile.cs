using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {

            CreateMap<Audit, AuditDto>()
               .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));


            CreateMap<AuditDto, Audit>();
        }
    }
}
