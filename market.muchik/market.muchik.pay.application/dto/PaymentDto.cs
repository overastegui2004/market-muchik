namespace market.muchik.pay.application.dto
{
    public class PaymentDto
    {
        public string  OperationId { get; set; } 
        public decimal InvoiceId { get; set; }
        public DateTime DatePay { get; set; }
    }
}
