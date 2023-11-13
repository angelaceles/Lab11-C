using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business
{
    public class BInvoice
    {
        public List<Invoice> GetByDate()
        {
            DInvoice data = new DInvoice();
            var invoices = data.Get();

            //var result = invoices.Where(x => x.Date == date).ToList();
            return invoices;
        }

        public void InsertarInvoices(Invoice invoice)
        {
            DInvoice data = new DInvoice();
            data.InsertarInvoices(invoice);
        }
        public void EliminarInvoices(Invoice invoice)
        {
            DInvoice data = new DInvoice();
            data.EliminarInvoices(invoice);
        }
    }
}
