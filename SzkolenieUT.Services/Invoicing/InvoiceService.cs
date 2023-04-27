using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public Invoice GenerateInvoice(DateTime actualDate, List<BasketItem> items)
        {
            var invoice =  new Invoice
            {
                Number = "2023/123/1",
                CreationDate = actualDate,
                Items = items.ConvertAll(x => new InvoiceItem
                {
                    Count = x.Count,
                    Name = x.Name,
                    NetValue = x.NetPrice,
                    Tax = x.Tax,
                    GrossValue = (x.NetPrice+x.NetPrice *(x.Tax/100)) * x.Count
                })
            };
            invoice.TotalNetValue = invoice.Items.Sum(x => x.NetValue);
            invoice.TotalGrossValue = invoice.Items.Sum(x => x.GrossValue);

            InvoiceCreated?.Invoke(this, invoice); 

            return invoice;
        }

        public event EventHandler<Invoice> InvoiceCreated;

    }
}
