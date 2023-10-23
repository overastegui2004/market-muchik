using AutoMapper;
using market.muchik.security.application.dto;
using market.muchik.security.domain.entities;

namespace market.muchik.security.application.mappgins
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<CreateUserDto, User>();
        }
    }
}
