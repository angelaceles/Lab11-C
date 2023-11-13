using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business;
using Entity;
using Demo09.Models;
using System.ComponentModel.Design;
using System;

namespace Demo09.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: InvoiceController
        public ActionResult Index()
        {
            BInvoice bInvoce = new BInvoice();
            List<Invoice> invoicesEntity = bInvoce.GetByDate();

            List<InvoiceModel> invoices = invoicesEntity.Select(x => new InvoiceModel
            {
                InvoiceId = x.InvoiceId,
                CustomerId = x.CustomerId,
                Date = x.Date,
                Total = x.Total,
                Active = x.Active,
                IGV = (x.Total*100)/18

            }).ToList();

            return View(invoices);
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceModel model)
        {
            try
            {
                BInvoice bInvoice = new BInvoice();
                Invoice invoice = new Invoice
                {
                    InvoiceId = model.InvoiceId,
                    CustomerId = model.CustomerId,
                    Date = model.Date,
                    Total = model.Total,
                    Active = true
                };

                bInvoice.InsertarInvoices(invoice);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            BInvoice binvoice = new BInvoice();
            var invoice = binvoice.GetByDate().Where(x => x.InvoiceId == id).FirstOrDefault();
            InvoiceModel model = new InvoiceModel 
            { 
                InvoiceId = invoice.InvoiceId,
                CustomerId = invoice.CustomerId,
                Date = invoice.Date,
                Total = invoice.Total
            };
            return View(model);
        }

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                BInvoice binvoice = new BInvoice();
                binvoice.EliminarInvoices(new Invoice { InvoiceId = id});

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
