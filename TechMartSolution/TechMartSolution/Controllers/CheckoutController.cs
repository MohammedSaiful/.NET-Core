using Microsoft.AspNetCore.Mvc;
using TechMart.Business.Modules.CheckoutServices;

namespace TechMart.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;
        public CheckoutController(ICheckoutService checkoutService) => _checkoutService = checkoutService;

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Confirm(string shippingAddress)
        {
            var sessionId = HttpContext.Session.GetString("CartSessionId");
            var order = await _checkoutService.PlaceOrderAsync(sessionId, shippingAddress);
            return View("OrderSuccess", order);
        }
    }
}
