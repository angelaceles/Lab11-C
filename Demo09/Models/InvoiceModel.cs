namespace Demo09.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public Decimal Total { get; set; }
        public Boolean Active { get; set; }
        public Decimal IGV { get; set; }
    }
}
