using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class LogProfile:Profile
    {
        public LogProfile()
        {
            CreateMap<Log, LogDto>();


            CreateMap<LogDto, Log>();
        }
    }
}
