using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EligoCustomerPortal.Data.Services
{
    /// <inheritdoc/>
    public class AccountService : IAccountService
    {
        private EligoDataContext _context;


        public AccountService(EligoDataContext context)
        {
            _context = context;
        }

        public bool AddOrUpdate(Account entity)
        {
            //TODO: Confirm assumption that new addresses would need to be added/updated as part of the service call. If it depends
            //on the UI, then separate service calls to address/account should probably be made from the controller/calling code.

            //Check address changes in.
            if (entity.BillingAddress != null)
            {
                _context.Entry(entity.BillingAddress).State = (entity.BillingAddress.ID == 0) ? EntityState.Added : EntityState.Modified;
            }
           
            if (entity.ServiceAddress != null)
            {
                _context.Entry(entity.ServiceAddress).State = (entity.ServiceAddress.ID == 0) ? EntityState.Added : EntityState.Modified;
            }

            //Check account changes in.
            _context.Entry(entity).State = (entity.ID == 0) ? EntityState.Added : EntityState.Modified;

            var result = _context.SaveChanges();

            return result == 1;
        }

        public bool Delete(Account entity)
        {
            //TODO: Determine if addresses should be deleted as well.
            _context.Remove(entity);

            var result = _context.SaveChanges();

            return result == 1;
        }

        public IEnumerable<Account> GetAll()
        {
            var results = _context.Accounts.AsEnumerable();

            return results;
        }

        public Account GetByID(int ID)
        {
            var result = _context.Accounts
                                 .Include(a => a.AccountType)
                                 .Include(a => a.BillingAddress)
                                 .Include(a => a.ServiceAddress)
                                 .Include(a => a.Customer)
                                 .SingleOrDefault(a => a.ID == ID);

            return result;
        }

        public IEnumerable<Account> GetCustomerAccounts(int customerID)
        {
            var results = _context.Accounts.Where(a => a.CustomerID == customerID);

            return results;
        }
    }
}
