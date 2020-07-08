using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services.Interfaces;
using EligoCustomerPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace EligoCustomerPortal.Web.Controllers
{
    /// <summary>
    /// Controller for Account-based functions/pages.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IInvoiceService _invoiceService;

        /// <summary>
        /// Constructor for the account controller.
        /// </summary>
        /// <param name="logger">Injection of an <see cref="ILogger"/></param>
        /// <param name="accountService">Injection of an <see cref="IAccountService"/></param>
        /// <param name="invoiceService">Injection of an <see cref="IInvoiceService"/> for grabbing invoices by account.</param>
        public AccountController(ILogger<AccountController> logger, IAccountService accountService, IInvoiceService invoiceService)
        {
            _logger = logger;
            _accountService = accountService;
            _invoiceService = invoiceService;
        }

        /// <summary>
        /// Retrieves a single <see cref="Account"/> entity by primary key.
        /// </summary>
        /// <param name="id">ID of the account to return.</param>
        public IActionResult Details(int id)
        {
            try
            {
                var account = _accountService.GetByID(id);

                if (account == default(Account))
                {
                    return StatusCode(404);
                }

                //Grab invoices for the account via the invoice service to add to the view model.
                var invoices = _invoiceService.GetByAccountID(id);

                var model = new AccountViewModel(account, invoices);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading Account record for Account ID: {id}", ex);

                return View("Error", new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
