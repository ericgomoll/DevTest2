using EligoCustomerPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EligoCustomerPortal.Data.Tests
{
    /// <summary>
    /// Helper "factory" for creating a data context and inserting fake data.
    /// </summary>
    /// <remarks>This could be extended for generating mock instances of objects on the fly for future test creation.</remarks>
    public static class MockDataFactory
    {
        public static EligoDataContext CreateContext()
        {
            //Create a mock context using EF's In-Memory Database functionality.
            var optionsBuilder = new DbContextOptionsBuilder<EligoDataContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            var mockContext = new EligoDataContext(optionsBuilder.Options);

            //Add entities to the mock in-memory database.
            mockContext.AddRange(GetCustomerData());
            mockContext.AddRange(GetAccountData());
            mockContext.AddRange(GetAccountTypeData());
            mockContext.AddRange(GetAddressData());
            mockContext.AddRange(GetInvoiceData());
            mockContext.AddRange(GetPaymentData());
            mockContext.AddRange(GetPaymentMethodData());
            mockContext.SaveChanges();

            return mockContext;
        }

        private static IQueryable<Customer> GetCustomerData()
        {
            var customers = new List<Customer>()
            {
                new Customer { ID = 123, FirstName = "Test", LastName = "Case One", EmailAddress = "test@test1.com", PhoneNumber = "(312) 555-1234" },
                new Customer { ID = 234, FirstName = "Test", LastName = "Case Two", EmailAddress = "test@test2.com", PhoneNumber = "(312) 588-2300" },
                new Customer { ID = 345, FirstName = "Test", LastName = "Case Three", EmailAddress = "test@test3.com", PhoneNumber = "(312) 456-7890" }
            };

            return customers.AsQueryable();
        }

        private static IQueryable<Account> GetAccountData()
        {
            var accounts = new List<Account>()
            {
                new Account { ID = 555, CustomerID = 123, AccountTypeID = 1, BillingAddressID = 1, ServiceAddressID = 1 },
                new Account { ID = 556, CustomerID = 123, AccountTypeID = 2, BillingAddressID = 1, ServiceAddressID = 2 },
                new Account { ID = 655, CustomerID = 234, AccountTypeID = 1, BillingAddressID = 3, ServiceAddressID = 4 },
                new Account { ID = 755, CustomerID = 345, AccountTypeID = 2, BillingAddressID = 5, ServiceAddressID = 6 }
            };

            return accounts.AsQueryable();
        }

        private static IQueryable<AccountType> GetAccountTypeData()
        {
            var accountTypes = new List<AccountType>()
            {
                new AccountType {ID = 1, Name = "Test Residential" },
                new AccountType {ID = 2, Name = "Test Commercial" }
            };

            return accountTypes.AsQueryable();
        }

        private static IQueryable<Address> GetAddressData()
        {
            var addresses = new List<Address>()
            {
                new Address {ID = 1, StreetAddress = "123 Sesame Street", City = "New York City", State = "NY", PostalCode = "11219" },
                new Address {ID = 2, StreetAddress = "123 Main Street", City = "Anywheresville", State = "US", PostalCode = "12345" },
                new Address {ID = 3, StreetAddress = "1 North South Street", City = "Chicago", State = "IL", PostalCode = "60600" },
                new Address {ID = 4, StreetAddress = "2 South Main Street", City = "Anywheresville", State = "US", PostalCode = "12346" },
                new Address {ID = 5, StreetAddress = "1 N State", City = "Chicago", State = "IL", PostalCode = "60602" },
                new Address {ID = 6, StreetAddress = "1 S State", City = "Chicago", State = "IL", PostalCode = "60603" }
            };

            return addresses.AsQueryable();
        }

        private static IQueryable<Invoice> GetInvoiceData()
        {
            var invoices = new List<Invoice>()
            {
                new Invoice { ID = 1001, AccountID = 555, InvoiceDate = new DateTime(2020, 1, 15), Amount = 100.00m, IsPaid = true },
                new Invoice { ID = 1002, AccountID = 556, InvoiceDate = new DateTime(2020, 3, 15), Amount = 243.00m, IsPaid = false },
                new Invoice { ID = 1003, AccountID = 655, InvoiceDate = new DateTime(2020, 4, 1), Amount = 442.67m, IsPaid = true },
                new Invoice { ID = 1004, AccountID = 755, InvoiceDate = new DateTime(2020, 4, 10), Amount = 234.56m, IsPaid = false }
            };

            return invoices.AsQueryable();
        }

        private static IQueryable<Payment> GetPaymentData()
        {
            var payments = new List<Payment>()
            {
                new Payment { ID = 456, PaymentDate = new DateTime(2020, 1, 24), Amount = 100.00m , PaymentMethodID = 1, InvoiceID = 1001 },
                new Payment { ID = 654, PaymentDate = new DateTime(2020, 4, 7), Amount = 442.67m , PaymentMethodID = 1, InvoiceID = 1003 }
            };

            return payments.AsQueryable();
        }

        private static IQueryable<PaymentMethod> GetPaymentMethodData()
        {
            var paymentMethods = new List<PaymentMethod>()
            {
                new PaymentMethod { ID = 1, Name = "Credit Card Test" },
                new PaymentMethod { ID = 2, Name = "Check Test" }
            };

            return paymentMethods.AsQueryable();
        }
    }
}
