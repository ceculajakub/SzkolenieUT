using System.Collections;
using System.Collections.Generic;
using SzkolenieUT.Model;

namespace SzkolenieUT.Services.Invoicing
{
    public class InvoiceService
    {
        private readonly IEnumerable<Invoice> Invoices;

        public InvoiceService(IEnumerable<Invoice> invoices)
        {
            Invoices = invoices;
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return Invoices;
        }

    }
}
