using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services;
using EligoCustomerPortal.Data.Services.Interfaces;
using NUnit.Framework;
using System.Linq;

namespace EligoCustomerPortal.Data.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private IAccountService _accountService;

        [SetUp]
        public void Setup()
        {
            var mockContext = MockDataFactory.CreateContext();
            _accountService = new AccountService(mockContext);
        }

        [Test]
        public void Test_GetAll()
        {
            var accounts = _accountService.GetAll();

            Assert.AreEqual(4, accounts.Count());
        }

        [Test]
        [TestCase(555)]
        [TestCase(556)]
        [TestCase(655)]
        [TestCase(755)]
        public void Test_GetById(int id)
        {
            var account = _accountService.GetByID(id);

            Assert.AreEqual(id, account.ID);
        }

        [Test]
        [TestCase(123, ExpectedResult = 2)]
        [TestCase(234, ExpectedResult = 1)]
        [TestCase(345, ExpectedResult = 1)]
        public int Test_GetCustomerAccounts(int customerID)
        {
            var accounts = _accountService.GetCustomerAccounts(customerID);

            return accounts.Count();
        }

        [Test]
        public void Test_AddOurUpdate()
        {
            var account = new Account() { AccountTypeID = 1, BillingAddressID = 6, ServiceAddressID = 5, CustomerID = 1 };

            var result = _accountService.AddOrUpdate(account);

            Assert.AreEqual(true, result);
        }
    }
}
