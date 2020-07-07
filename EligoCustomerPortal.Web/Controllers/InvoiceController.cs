using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services.Interfaces;
using EligoCustomerPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace EligoCustomerPortal.Web.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

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
