using AutoMapper;
using market.muchik.invoice.application.dto;
using market.muchik.invoice.domain.entities;

namespace market.muchik.invoice.application.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<Invoice, InvoiceDto>();
        }
    }
}
