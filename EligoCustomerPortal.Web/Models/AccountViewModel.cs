using EligoCustomerPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EligoCustomerPortal.Web.Models
{
    public class AccountViewModel
    {
        public AccountViewModel(Account account, IEnumerable<Invoice> invoices)
        {
            this.Account = account;
            this.AccountType = account.AccountType;
            this.Customer = account.Customer;
            this.BillingAddress = account.BillingAddress;
            this.ServiceAddress = account.ServiceAddress;
            this.Invoices = invoices;
        }

        public Account Account { get; set; }

        public AccountType AccountType {get; set;}

        public Customer Customer { get; set; }

        public Address BillingAddress { get; set; }

        public Address ServiceAddress { get; set; }

        public IEnumerable<Invoice> Invoices { get; set; }
    }
}
