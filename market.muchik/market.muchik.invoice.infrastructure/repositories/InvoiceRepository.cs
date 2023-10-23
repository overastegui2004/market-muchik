using Microsoft.EntityFrameworkCore;
using market.muchik.invoice.domain.entities;
using market.muchik.invoice.domain.interfaces;
using market.muchik.invoice.infrastructure.context;

namespace market.muchik.invoice.infrastructure.repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceContext context) : base(context) { }
    }
}
