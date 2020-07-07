using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EligoCustomerPortal.Data.Services
{
    /// <inheritdoc/>
    public class CustomerService : ICustomerService
    {
        private EligoDataContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context"><see cref="EligoDataContext"/> instance to use with the service.</param>
        public CustomerService(EligoDataContext context)
        {
            _context = context;
        }

        public bool AddOrUpdate(Customer entity)
        {
            _context.Entry(entity).State = (entity.ID == 0) ? EntityState.Added : EntityState.Modified;
            var result = _context.SaveChanges();

            return result == 1;
        }

        public bool Delete(Customer entity)
        {
            _context.Remove(entity);
            var result = _context.SaveChanges();

            return result == 1;
        }

        public IEnumerable<Customer> GetAll()
        {
            var results = _context.Customers.AsEnumerable();

            return results;
        }

        public Customer GetByID(int ID)
        {
            var result = _context.Customers
                                 .Include(c => c.Accounts)
                                    .ThenInclude(a => a.AccountType)
                                 .SingleOrDefault(c => c.ID == ID);

            return result;
        }
    }
}
