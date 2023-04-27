using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using SzkolenieUT.Model;
using SzkolenieUT.Services.Invoicing;

namespace SzkolenieUT.Services.FluentTests.Invoicing
{
    public class InvoiceServiceTests
    {
        [Test]
        public void GenerateInvoiceShouldReturnValidInvoiceForGivenItems()
        {
            //ARRANGE

            var items = new List<BasketItem>
            {
                new BasketItem
                {
                    Id = 1,
                    Name = "test",
                    NetPrice = 10,
                    Tax = 23,
                    Count = 1
                },
                new BasketItem
                {
                    Id = 2,
                    Name = "test 2",
                    NetPrice = 10,
                    Tax = 7,
                    Count = 2
                }
            };

            InvoiceService service = new InvoiceService(null);
            DateTime actualDate = 27.April(2023);

            //ACT

            Invoice actual = service.GenerateInvoice(actualDate, items.ToList());

            //ASSERT

            actual.CreationDate.Should().Be(actualDate);
            actual.Number.Should().NotBeNullOrEmpty().And.StartWith("2023");
            actual.Items.Should().HaveCount(2);
            actual.TotalNetValue.Should().Be(items.Sum(x => x.NetPrice));
            actual.TotalGrossValue.Should().Be(33.7m);
        }

        [Test]
        public void GenerateInvoiceShouldRaiseInvoiceCreatedEvent()
        {
            //ARRANGE
            InvoiceService service = new InvoiceService(null);

            using var monitorSubject = service.Monitor();

            var items = new List<BasketItem>
            {
                new BasketItem
                {
                    Id = 1,
                    Name = "test",
                    NetPrice = 10,
                    Tax = 23,
                    Count = 1
                },
                new BasketItem
                {
                    Id = 2,
                    Name = "test 2",
                    NetPrice = 10,
                    Tax = 7,
                    Count = 2
                }
            };
            DateTime actualDate = 27.April(2023);

            Invoice? eventInvoice = null;

            service.InvoiceCreated += (sender, invoice) =>
            {
                eventInvoice = invoice;
            };


            //ACT
            Invoice actual = service.GenerateInvoice(actualDate, items.ToList());

            //ASSERT

            monitorSubject.Should().Raise(nameof(InvoiceService.InvoiceCreated));

            eventInvoice.Should().NotBeNull();
        }
    }
}
