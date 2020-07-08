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
    /// Controller for Invoice-based functions.
    /// </summary>
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceService _invoiceService;

        /// <summary>
        /// Constructor for the invoice controller.
        /// </summary>
        /// <param name="logger">Injection of an <see cref="ILogger"/></param>
        /// <param name="invoiceService">Injection of an <see cref="IInvoiceService"/></param>
        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        /// <summary>
        /// Retrieves a single <see cref="Invoice"/> entity by primary key.
        /// </summary>
        /// <param name="id">ID of the invoice to return.</param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            try
            {
                var invoice = _invoiceService.GetByID(id);

                if (invoice == default(Invoice))
                {
                    return StatusCode(404);
                }

                return View(invoice);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading invoice record for ID: {id}", ex);

                return View("Error", new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
