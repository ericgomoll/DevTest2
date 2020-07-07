using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services.Interfaces;
using EligoCustomerPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace EligoCustomerPortal.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IInvoiceService _invoiceService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService, IInvoiceService invoiceService)
        {
            _logger = logger;
            _accountService = accountService;
            _invoiceService = invoiceService;
        }

        public IActionResult Details(int id)
        {
            try
            {
                var account = _accountService.GetByID(id);

                if (account == default(Account))
                {
                    return StatusCode(404);
                }

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
