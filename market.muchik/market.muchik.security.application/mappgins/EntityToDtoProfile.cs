using AutoMapper;
using market.muchik.security.application.dto;
using market.muchik.security.domain.entities;

namespace market.muchik.security.application.mappgins
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, SignInResponseDto>();
        }
    }
}
