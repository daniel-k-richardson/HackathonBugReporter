using Application.Common.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.AutoMapper;
public  class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<GlobalUser, User>().ReverseMap();
    }
}
