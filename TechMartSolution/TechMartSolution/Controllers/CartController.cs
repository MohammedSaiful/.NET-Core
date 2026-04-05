using Microsoft.AspNetCore.Mvc;
using TechMart.Business.Modules.CartServices;
using TechMart.DataAccessLayer.Module.Productss;

namespace TechMart.Web.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartService _cartService;
        private readonly IProductRepository _productRepo; // To show product list

        public CartController(ICartService cartService, IProductRepository productRepo)
        {
            _cartService = cartService;
            _productRepo = productRepo;
        }

        // Helper to get or create a unique Cart ID for the session
        private string GetCartSessionId()
        {
            var sId = HttpContext.Session.GetString("CartSessionId");
            if (string.IsNullOrEmpty(sId))
            {
                sId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("CartSessionId", sId);
            }
            return sId;
        }

        // 1. Product Listing (Home)
        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAllAsync();
            return View(products);
        }

        // 2. View Cart
        public async Task<IActionResult> ViewCart()
        {
            var items = await _cartService.GetCartItemsAsync(GetCartSessionId());
            ViewBag.Total = await _cartService.GetCartSubtotalAsync(GetCartSessionId());
            return View(items);
        }

        // 3. Add to Cart
        public async Task<IActionResult> Add(int id)
        {
            await _cartService.AddToCartAsync(GetCartSessionId(), id, 1);
            return RedirectToAction("ViewCart");
        }

        // 4. Remove Item
        public async Task<IActionResult> Remove(int id)
        {
            await _cartService.RemoveFromCartAsync(id);
            return RedirectToAction("ViewCart");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            await _cartService.UpdateQuantityAsync(id, quantity);
            return RedirectToAction("ViewCart");
        }

        public async Task<IActionResult> Clear()
        {
            await _cartService.ClearCartAsync(GetCartSessionId());
            return RedirectToAction("ViewCart");
        }
    }
}
