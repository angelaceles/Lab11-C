using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public Decimal Total { get; set; }
        public Boolean Active { get; set; }
        public Decimal IGV { get; set; }
    }
}
