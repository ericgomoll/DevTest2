using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services;
using EligoCustomerPortal.Data.Services.Interfaces;
using NUnit.Framework;
using System;
using System.Linq;

namespace EligoCustomerPortal.Data.Tests
{
    [TestFixture]
    public class InvoiceServiceTests
    {
        private IInvoiceService _invoiceService;

        [SetUp]
        public void Setup()
        {
            var mockContext = MockDataFactory.CreateContext();
            _invoiceService = new InvoiceService(mockContext);
        }

        [Test]
        public void Test_GetAll()
        {
            var invoices = _invoiceService.GetAll();

            Assert.AreEqual(4, invoices.Count());
        }

        [Test]
        [TestCase(1001)]
        [TestCase(1002)]
        [TestCase(1003)]
        [TestCase(1004)]
        public void Test_GetByID(int id)
        {
            var invoice = _invoiceService.GetByID(id);

            Assert.AreEqual(invoice.ID, id);
        }

        [Test]
        [TestCase(555, ExpectedResult = 1)]
        [TestCase(556, ExpectedResult = 1)]
        [TestCase(655, ExpectedResult = 1)]
        [TestCase(755, ExpectedResult = 1)]
        public int Test_GetByAccountID(int accountID)
        {
            var invoices = _invoiceService.GetByAccountID(accountID, true);

            return invoices.Count();
        }

        [Test]
        public void Test_AddOrUpdate()
        {
            var invoice = new Invoice() { AccountID = 555, InvoiceDate = new DateTime(2020, 6, 1), Amount = 100.00m, IsPaid = false };

            var result = _invoiceService.AddOrUpdate(invoice);

            Assert.AreEqual(true, result);
        }
    }
}
