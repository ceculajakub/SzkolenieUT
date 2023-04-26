using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SzkolenieUT.Model;
using SzkolenieUT.Services.Invoicing;

namespace SzkolenieUT.Services.Tests.Invoicing
{
    public class InvoiceServiceTests
    {
        private IEnumerable<Invoice> Invoices { get; set; }

        [SetUp]
        public void Setup()
        {
            Invoices = new List<Invoice>
            {
                new Invoice
                {
                    Number = "1",
                    TotalGrossValue = 0
                },

                new Invoice
                {
                    Number = "1",
                    TotalGrossValue = 0
                },
                new Invoice
                {
                    Number = "1",
                    TotalGrossValue = 0
                },
                new Invoice
                {
                    Number = "1",
                    TotalGrossValue = 0
                }
            };
        }

        [Test]
        public void GetAllInvoicesShouldReturnAllInvoices()
        {
            //ARRANGE
            InvoiceService service = new InvoiceService(Invoices);

            //ACT
            var actual = service.GetAllInvoices();

            //ASSERT
            CollectionAssert.AllItemsAreNotNull(actual);
            CollectionAssert.AreEqual(Invoices, actual);
            CollectionAssert.AllItemsAreInstancesOfType(Invoices, typeof(Invoice));
            CollectionAssert.Contains(Invoices, Invoices.First());
        }

    }
}
