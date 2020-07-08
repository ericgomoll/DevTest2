using EligoCustomerPortal.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EligoCustomerPortal.Web.Controllers
{
    /// <summary>
    /// Contorller for Payment-based functions/pages.
    /// </summary>
    /// <remarks>Not yet implemented.</remarks>
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
