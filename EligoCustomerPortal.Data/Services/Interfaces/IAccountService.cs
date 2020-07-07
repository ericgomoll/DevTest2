using EligoCustomerPortal.Data.Models;
using System.Collections.Generic;

namespace EligoCustomerPortal.Data.Services.Interfaces
{
    /// <summary>
    /// Methods for interacting with Account entities.
    /// </summary>
    public interface IAccountService : IEligoService<Account>
    {
        /// <summary>
        /// Retrieves all accounts associated with a specific customer.
        /// </summary>
        /// <param name="customerID">ID of customer.</param>
        IEnumerable<Account> GetCustomerAccounts(int customerID);
    }
}
