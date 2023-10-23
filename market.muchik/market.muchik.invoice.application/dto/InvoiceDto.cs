namespace market.muchik.invoice.application.dto
{
    public partial class InvoiceDto
    {
        public int InvoiceId { get; set; } 
        public decimal  Amount { get; set; } 
        public int State { get; set; }
    }
}
