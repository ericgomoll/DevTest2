using EligoCustomerPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EligoCustomerPortal.Data.Services.Interfaces
{
    /// <summary>
    /// Methods for interacting with Invoice entities.
    /// </summary>
    public interface IInvoiceService : IEligoService<Invoice>
    {
        /// <summary>
        /// Retrieves all invoices for a specific account.
        /// </summary>
        /// <param name="accountID">ID of account to retrieve invoices for.</param>
        /// <param name="includePaidInvoices">If set to true, paid invoices will also be returned. The default is to only return open invoices.</param>
        /// <returns>List of invoices sorted by newest to oldest.</returns>
        IEnumerable<Invoice> GetByAccountID(int accountID, bool includePaidInvoices = false);

        /// <summary>
        /// Determines if this payment, along with any existing, pays the total amount of the invoice and marks the invoice as paid.
        /// </summary>
        /// <param name="payment"><see cref="Payment"/> to apply.</param>
        /// <param name="invoice"><see cref="Invoice"/> to apply payment to.</param>
        /// <returns>True if the payment "applies" correctly.</returns>
        bool ApplyPayment(Payment payment, Invoice invoice);
    }
}
