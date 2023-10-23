using market.muchik.invoice.application.dto;

namespace market.muchik.invoice.application.interfaces
{
    public interface IInvoiceService
    {
        ICollection<InvoiceDto> GetAllInvoices();
        InvoiceDto CreateInvoice(InvoiceDto invoiceDto);
    }
}
