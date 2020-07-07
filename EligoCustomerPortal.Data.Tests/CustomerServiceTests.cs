using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services;
using EligoCustomerPortal.Data.Services.Interfaces;
using NUnit.Framework;
using System.Linq;

namespace EligoCustomerPortal.Data.Tests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private ICustomerService _customerService;

        [SetUp]
        public void Setup()
        {
            var mockContext = MockDataFactory.CreateContext();
            _customerService = new CustomerService(mockContext);
        }

        [Test]
        public void Test_GetAll()
        {
            var customers = _customerService.GetAll();

            Assert.AreEqual(3, customers.Count());
        }

        [Test]
        [TestCase(123)]
        [TestCase(234)]
        [TestCase(345)]
        public void Test_GetByID(int id)
        {
            var customer = _customerService.GetByID(id);

            Assert.AreEqual(id, customer.ID);
        }

        [Test]
        public void Test_AddOrUpdate()
        {
            var customer = new Customer() { EmailAddress = "testcreate@test.com", FirstName = "Add", LastName = "Test" };

            var result = _customerService.AddOrUpdate(customer);

            Assert.AreEqual(true, result);
        }
    }
}