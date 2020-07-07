using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EligoCustomerPortal.Data.Services
{
    /// <inheritdoc/>
    public class AddressService : IAddressService
    {
        private EligoDataContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context"><see cref="EligoDataContext"/> instance to use with the service.</param>
        public AddressService(EligoDataContext context)
        {
            _context = context;
        }

        public bool AddOrUpdate(Address entity)
        {
            _context.Entry(entity).State = (entity.ID == 0) ? EntityState.Added : EntityState.Modified;
            var result = _context.SaveChanges();

            return result == 1;
        }

        public bool Delete(Address entity)
        {
            _context.Remove(entity);
            var result = _context.SaveChanges();

            return result == 1;
        }

        public IEnumerable<Address> GetAll()
        {
            var result = _context.Addresses.AsEnumerable();

            return result;
        }

        public Address GetByID(int ID)
        {
            var result = _context.Addresses.Find(ID);

            return result;
        }
    }
}
