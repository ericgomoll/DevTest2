using EligoCustomerPortal.Data.Models;
using System.Collections.Generic;

namespace EligoCustomerPortal.Web.Models
{
    /// <summary>
    /// View model for handling account information.
    /// </summary>
    public class AccountViewModel
    {
        /// <summary>
        /// News up an AccountViewModel.
        /// </summary>
        /// <param name="account">The <see cref="Account"/> instance to use in the view model.</param>
        /// <param name="invoices">The set of invoices for the account.</param>
        public AccountViewModel(Account account, IEnumerable<Invoice> invoices)
        {
            this.Account = account;
            this.Invoices = invoices;

            //Set the "convenience" properties that avoid us having to do something like
            //@Model.Account.AccountType.Name in the view.
            this.AccountType = account.AccountType;
            this.Customer = account.Customer;
            this.BillingAddress = account.BillingAddress;
            this.ServiceAddress = account.ServiceAddress;
        }

        /// <summary>
        /// Account entity for the detail view.
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Pulls out the AccountType from the Account's nav property.
        /// </summary>
        public AccountType AccountType {get; set;}

        /// <summary>
        /// Pulls out the Customer from the Account's nav property.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Pulls out the billing address from the Account's nav property.
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Pulls out the service address from the Account's nav property.
        /// </summary>
        public Address ServiceAddress { get; set; }

        /// <summary>
        /// Invoices associated with the account.
        /// </summary>
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}
