using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EligoCustomerPortal.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EligoCustomerPortal.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;

        public IActionResult MakePayment()
        {
            return View();
        }
    }
}
