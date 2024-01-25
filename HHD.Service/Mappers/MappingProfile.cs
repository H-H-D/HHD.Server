using AutoMapper;
using HHD.Domain.Entities.Users;
using HHD.Service.DTOs.Users;

namespace HHD.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Users
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();
    }
}
