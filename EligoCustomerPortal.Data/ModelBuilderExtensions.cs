using EligoCustomerPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EligoCustomerPortal.Data
{
    /// <summary>
    /// Extension methods for EF's ModelBuilder functionality.
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Adds seed data for the purpose of the demo app.
        /// </summary>
        /// <param name="builder">Current instance of the ModelBuilder</param>
        public static void AddInitialSeedData(this ModelBuilder builder)
        {
            var customers = new List<Customer>()
            {
                new Customer {ID = 1, FirstName = "Eric", LastName = "Gomoll", EmailAddress = "ericgomoll@gmail.com", PhoneNumber = "(847) 722-9149"},
                new Customer {ID = 2, FirstName = "David", LastName = "Solderna", EmailAddress = "dsoderna@eligoenergy.com"}
            };
            builder.Entity<Customer>().HasData(customers);

            var accountTypes = new List<AccountType>()
            {
                new AccountType {ID = 1, Name = "Residential" },
                new AccountType {ID = 2, Name = "Commercial" }
            };
            builder.Entity<AccountType>().HasData(accountTypes);

            var addresses = new List<Address>()
            {
                new Address {ID = 1, StreetAddress = "201 West Lake Street", City = "Chicago", State = "IL", PostalCode = "60606"},
                new Address {ID = 2, StreetAddress = "333 West Wacker Drive", City = "Chicago", State = "IL", PostalCode = "60606"},
                new Address {ID = 3, StreetAddress = "233 South Wacker Drive", City = "Chicago", State = "IL", PostalCode = "60606"}
            };
            builder.Entity<Address>().HasData(addresses);

            var paymentMethods = new List<PaymentMethod>()
            {
                new PaymentMethod {ID = 1, Name = "Credit Card" },
                new PaymentMethod {ID = 2, Name = "Check" },
                new PaymentMethod {ID = 3, Name = "Cash" }
            };
            builder.Entity<PaymentMethod>().HasData(paymentMethods);

            var accounts = new List<Account>()
            {
                new Account {ID = 101, CustomerID = 1, BillingAddressID = 2, ServiceAddressID = 2, AccountTypeID = 1 },
                new Account {ID = 102, CustomerID = 2, BillingAddressID = 1, ServiceAddressID = 1, AccountTypeID = 1 },
                new Account {ID = 103, CustomerID = 2, BillingAddressID = 1, ServiceAddressID = 3, AccountTypeID = 2 }
            };
            builder.Entity<Account>().HasData(accounts);

            var invoices = new List<Invoice>()
            {
                //EG Account 101
                new Invoice {ID = 5544, AccountID = 101, InvoiceDate = new DateTime(2020, 4, 10), Amount = 124.54m, IsPaid = true },
                new Invoice {ID = 6062, AccountID = 101, InvoiceDate = new DateTime(2020, 5, 10), Amount = 117.01m, IsPaid = true },
                new Invoice {ID = 6098, AccountID = 101, InvoiceDate = new DateTime(2020, 6, 10), Amount = 135.04m, IsPaid = false },

                //DS Account 102
                new Invoice {ID = 5334, AccountID = 102, InvoiceDate = new DateTime(2020, 4, 04), Amount = 79.76m, IsPaid = true },
                new Invoice {ID = 6097, AccountID = 102, InvoiceDate = new DateTime(2020, 5, 04), Amount = 114.54m, IsPaid = true },
                new Invoice {ID = 6114, AccountID = 102, InvoiceDate = new DateTime(2020, 6, 04), Amount = 122.00m, IsPaid = false },

                //DS Account 103
                new Invoice {ID = 5495, AccountID = 103, InvoiceDate = new DateTime(2020, 4, 23), Amount = 145.43m, IsPaid = true },
                new Invoice {ID = 6113, AccountID = 103, InvoiceDate = new DateTime(2020, 5, 23), Amount = 176.04m, IsPaid = true },
                new Invoice {ID = 6122, AccountID = 103, InvoiceDate = new DateTime(2020, 6, 23), Amount = 191.01m, IsPaid = true }
            };
            builder.Entity<Invoice>().HasData(invoices);

            var payments = new List<Payment>()
            {
                //EG Account 101
                new Payment { ID = 4432, InvoiceID = 5544, PaymentMethodID = 1, PaymentDate = new DateTime(2020, 4, 25), Amount = 124.54m },
                new Payment { ID = 4954, InvoiceID = 6062, PaymentMethodID = 1, PaymentDate = new DateTime(2020, 5, 30), Amount = 117.01m },

                //DS Account 102
                new Payment { ID = 4345, InvoiceID = 5334, PaymentMethodID = 1, PaymentDate = new DateTime(2020, 4, 19), Amount = 79.76m},
                new Payment { ID = 4957, InvoiceID = 6097, PaymentMethodID = 1, PaymentDate = new DateTime(2020, 5, 30), Amount = 114.54m },

                //DS Account 103
                new Payment { ID = 4309, InvoiceID = 5495, PaymentMethodID = 2, PaymentDate = new DateTime(2020, 5, 9), Amount = 145.43m},
                new Payment { ID = 5005, InvoiceID = 6113, PaymentMethodID = 2, PaymentDate = new DateTime(2020, 6, 1), Amount = 176.04m },
                new Payment { ID = 5109, InvoiceID = 6122, PaymentMethodID = 2, PaymentDate = new DateTime(2020, 7, 6), Amount = 191.01m }
            };
            builder.Entity<Payment>().HasData(payments);
        }
    }
}
