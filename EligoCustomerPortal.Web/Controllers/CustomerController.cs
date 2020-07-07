using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Services.Interfaces;
using EligoCustomerPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace EligoCustomerPortal.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

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
