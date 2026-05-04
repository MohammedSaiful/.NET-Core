using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class OrdersController : Controller
{
    private readonly IOrderRepository _orderRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public OrdersController(
        IOrderRepository orderRepository,
        UserManager<ApplicationUser> userManager)
    {
        _orderRepository = orderRepository;
        _userManager = userManager;
    }

    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> MyOrders()
    {
        var user = await _userManager.GetUserAsync(User);

        var orders = await _orderRepository
            .GetOrdersByUserIdAsync(user.Id);

        return View(orders);
    }

    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order == null)
            return NotFound();

        var user = await _userManager.GetUserAsync(User);

        if (User.IsInRole("Customer") &&
            order.ApplicationUserId != user.Id)
        {
            return Forbid();
        }

        return View(order);
    }

    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpPost]
    public async Task<IActionResult> MarkDelivered(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order == null)
            return NotFound();

        order.Status = "Delivered";

        await _orderRepository.UpdateAsync(order);

        TempData["Success"] = "Order marked as delivered.";

        return RedirectToAction("Details", new { id });
    }
}