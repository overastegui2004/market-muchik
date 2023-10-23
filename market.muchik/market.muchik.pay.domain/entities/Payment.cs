namespace market.muchik.pay.domain.entities
{
    public partial class Payment
    {
        public string OperationId { get; set; } = Guid.NewGuid().ToString("N");
        public decimal InvoiceId { get; set; }
        public DateTime DatePay { get; set; } = DateTime.UtcNow;
    }
}