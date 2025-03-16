using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
             .ForMember(dest => dest.Task, opt => opt.MapFrom(src => src.Task))
             .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));


            CreateMap<CommentDto, Comment>();
        }
    }
}
