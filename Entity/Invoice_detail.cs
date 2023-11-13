using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Invoice_detail
    {
        public int DetailId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int quantity { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
        public int Active { get; set; }
    }
}
