using AutoMapper;
using market.muchik.pay.application.dto;
using market.muchik.pay.application.dto.Creates;
using market.muchik.pay.domain.entities;

namespace market.muchik.pay.application.mappings
{
    public class DtoToEntityProfile : Profile
    {
       public DtoToEntityProfile() 
       {
            CreateMap<PaymentDto, Payment>();
            CreateMap<CreatePaymentDto, Payment>();
        }
    }
}
