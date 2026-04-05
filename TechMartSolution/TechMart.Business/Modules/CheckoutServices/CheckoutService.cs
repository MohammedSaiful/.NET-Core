using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMart.DataAccessLayer.Module.Cart;
using TechMart.DataAccessLayer.Module.Orderss;
using TechMart.DataAccessLayer.Module.Productss;
using TechMart.Domain.Entities;

namespace TechMart.Business.Modules.CheckoutServices
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;

        public CheckoutService(ICartRepository cartRepo, IOrderRepository orderRepo, IProductRepository productRepo)
        {
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        public async Task<float> CalculateTotalAsync(string sessionId, float taxRate, float shippingFee)
        {
            var items = await _cartRepo.GetCartItemsAsync(sessionId);
            float subtotal = items.Sum(i => i.Quantity * i.Product.Price);
            return subtotal + (subtotal * taxRate) + shippingFee;
        }

        public async Task<Order> PlaceOrderAsync(string sessionId, string shippingAddress)
        {
            var cartItems = await _cartRepo.GetCartItemsAsync(sessionId);
            if (!cartItems.Any()) throw new InvalidOperationException("Cart is empty.");

            float total = cartItems.Sum(i => i.Quantity * i.Product.Price);

            var order = new Order
            {
                OrderDate = DateTime.Now,
                ShippingAddress = shippingAddress,
                Status = "Confirmed",
                TotalAmount = total,
                OrderItems = cartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.Product.Price
                }).ToList()
            };

            // Note: Ensure your OrderRepository implementation handles the persistence logic
            await _orderRepo.CreateOrder(order);

            // Clear the cart after successful order placement
            await _cartRepo.ClearCartAsync(sessionId);

            return order;
        }
    }
}
