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
    /// Controller for Customer-based functions/pages.
    /// </summary>
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Constructor for the customer controller.
        /// </summary>
        /// <param name="logger">Injection of an <see cref="ILogger"/></param>
        /// <param name="customerService">Injection of an <see cref="ICustomerService"/></param>
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        /// <summary>
        /// Retrieves a single <see cref="Customer"/> entity by primary key.
        /// </summary>
        /// <param name="id">ID of the customer to return.</param>
        public IActionResult Details(int id)
        {
            try
            {
                var customer = _customerService.GetByID(id);

                if (customer == default(Customer))
                {
                    return StatusCode(404);
                }

                return View(customer);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading Customer record for Customer ID: {id}", ex);

                return View("Error", new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
