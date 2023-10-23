using market.muchik.domain.events;

namespace market.muchik.pay.application.events
{
    public class CreatePaymentEvent : Event
    {
        public string OperationId { get; set; }
        public decimal InvoiceId { get;set; }

        public CreatePaymentEvent(string operationId, decimal invoiceId)
        {
            OperationId = operationId;
            InvoiceId = invoiceId;
        }
    }
}
