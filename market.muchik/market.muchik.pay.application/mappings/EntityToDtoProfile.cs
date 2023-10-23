using AutoMapper;
using market.muchik.pay.application.dto;
using market.muchik.pay.domain.entities;

namespace market.muchik.pay.application.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<Payment, PaymentDto>();
        }
    }
}
