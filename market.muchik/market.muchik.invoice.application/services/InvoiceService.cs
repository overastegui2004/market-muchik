using AutoMapper;
using market.muchik.invoice.application.dto;
using market.muchik.invoice.application.interfaces;
using market.muchik.invoice.domain.entities;
using market.muchik.invoice.domain.interfaces;

namespace market.muchik.invoice.application.services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public ICollection<InvoiceDto> GetAllInvoices()
        {
            var Invoices = _invoiceRepository.List();
            var InvoicesDto = _mapper.Map<ICollection<InvoiceDto>>(Invoices);
            return InvoicesDto;
        }

        public InvoiceDto CreateInvoice(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(invoiceDto);
        //    _invoicesRepository.Add(invoice);
         //   _invoicesRepository.Save();
            return invoiceDto;
        }
    }
}
