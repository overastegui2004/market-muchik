using market.muchik.domain.bus;
using market.muchik.pay.application.dto.Creates;
using market.muchik.pay.application.events;
using market.muchik.pay.application.interfaces;

namespace market.muchik.pay.application.eventHandlers
{
    public class CreatePaymentEventHandler : IEventHandler<CreatePaymentEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly IPaymentService _paymentService;

        public CreatePaymentEventHandler(IEventBus eventBus, IPaymentService paymentService) 
        {
            _eventBus = eventBus;
            _paymentService = paymentService;
        }
        
        public Task Handle(CreatePaymentEvent @event)
        {
            var paymentDto = new CreatePaymentDto
            {
                OperationId = @event.OperationId,
                InvoiceId = @event.InvoiceId
            };

            var successPayment = _paymentService.CreatePayment(paymentDto);

            return Task.CompletedTask;
        }
    }
}
