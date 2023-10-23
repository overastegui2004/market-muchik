using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using market.muchik.pay.application.dto.Creates;
using market.muchik.pay.application.interfaces;

namespace market.muchik.pay.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
        {
            _paymentService.CreatePayment(createPaymentDto);
            return Ok();
        }
    }
}
