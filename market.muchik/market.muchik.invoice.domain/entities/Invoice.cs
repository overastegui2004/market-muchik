namespace market.muchik.invoice.domain.entities
{

    public class Invoice
    {
        public int InvoiceId { get; set; } 
        public decimal Amount { get; set; } 
        public int State { get; set; }

    }
}
