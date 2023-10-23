using Microsoft.AspNetCore.Mvc;
using market.muchik.invoice.application.dto;
using market.muchik.invoice.application.interfaces;

namespace market.muchik.invoice.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService) 
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("getAllHomeDeliveries")]
        public IActionResult GetAllInvoices()
        {
            return Ok(_invoiceService.GetAllInvoices());
        }

        [HttpPost]
        public IActionResult CreateInvoice([FromBody] InvoiceDto invoiceDto)
        {
            return Ok(_invoiceService.CreateInvoice(invoiceDto));
        }
    }
}
