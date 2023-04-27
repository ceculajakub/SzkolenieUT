using System;
using System.Collections;
using System.Collections.Generic;

namespace SzkolenieUT.Model
{
    public class Invoice
    {
        public string Number { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal TotalGrossValue { get; set; }
        public decimal TotalNetValue { get; set; }


        public IEnumerable<InvoiceItem> Items { get; set; }

    }

    public class InvoiceItem
    {
        public int Count { get; set; }

        public string Name { get; set; }

        public decimal GrossValue  { get; set; }

        public decimal NetValue { get; set; }

        public decimal Tax { get; set; }
    }
}
