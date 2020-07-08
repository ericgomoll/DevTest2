using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EligoCustomerPortal.Data.Services
{
    /// <inheritdoc/>
    public class InvoiceService : IInvoiceService
    {
        private EligoDataContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context"><see cref="EligoDataContext"/> instance to use with the service.</param>
        public InvoiceService(EligoDataContext context)
        {
            _context = context;
        }

        public bool AddOrUpdate(Invoice entity)
        {
            //TODO: Streamline these add/delete methods where there are no changes to a "base" repository for these type of things.
            _context.Entry(entity).State = (entity.ID == 0) ? EntityState.Added : EntityState.Modified;
            var result = _context.SaveChanges();

            return result == 1;
        }

        public bool ApplyPayment(Payment payment, Invoice invoice)
        {
            var result = 1;
            //find all payments for this invoice to determine sum of amounts.
            var existingPaymentSum = _context.Payments.Where(p => p.InvoiceID == payment.InvoiceID).Sum(p => p.Amount);
            var totalPayments = existingPaymentSum + payment.Amount;

            //if the total payments applied to the invoice cover the total invoice amount, mark invoice as paid.
            if (totalPayments >= invoice.Amount)
            {
                invoice.IsPaid = true;
                _context.Entry(invoice).State = EntityState.Modified;
                result = _context.SaveChanges();
            }

            return result == 1;
        }

        public bool Delete(Invoice entity)
        {
            _context.Remove(entity);
            var result = _context.SaveChanges();

            return result == 1;
        }

        public IEnumerable<Invoice> GetAll()
        {
            var results = _context.Invoices.AsEnumerable();

            return results;
        }

        public IEnumerable<Invoice> GetByAccountID(int accountID, bool includePaidInvoices)
        {
            var results = _context.Invoices.Where(i => i.AccountID == accountID);

            if (!includePaidInvoices)
            {
                results = results.Where(i => i.IsPaid == false);
            }

            return results.OrderByDescending(i => i.InvoiceDate).AsEnumerable();
        }

        public Invoice GetByID(int ID)
        {
            //TODO: Review general query to see about improvements.
            //This is the right way to do this with the multiple includes. It will only include one JOIN on Account in theory per: https://docs.microsoft.com/en-us/ef/core/querying/related-data#including-multiple-levels
            var result = _context.Invoices
                                 .Include(i => i.Account).ThenInclude(a => a.BillingAddress) 
                                 .Include(i => i.Account).ThenInclude(a => a.ServiceAddress)
                                 .Include(i => i.Account).ThenInclude(a => a.Customer) 
                                 .Include(i => i.Account).ThenInclude(a => a.AccountType)
                                 .Include(i => i.Payments)
                                 .SingleOrDefault(i => i.ID == ID);

            return result;
        }
    }
}
