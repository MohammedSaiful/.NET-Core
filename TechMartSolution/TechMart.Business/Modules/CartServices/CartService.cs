using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMart.DataAccessLayer.Module.Cart;
using TechMart.DataAccessLayer.Module.Productss;
using TechMart.Domain.Entities;

namespace TechMart.Business.Modules.CartServices
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IProductRepository _productRepo;

        public byte TaxRate => 10; // 10% tax example

        public CartService(ICartRepository cartRepo, IProductRepository productRepo)
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
        }

        public async Task<List<CartItem>> GetCartItemsAsync(string sessionId)
        {
            return await _cartRepo.GetCartItemsAsync(sessionId);
        }

        public async Task AddToCartAsync(string sessionId, int productId, int quantity)
        {
            var product = await _productRepo.GetByIdAsync(productId);
            if (product == null || product.StockQuantity < quantity)
                throw new InvalidOperationException("Product is out of stock or does not exist.");

            var item = new CartItem
            {
                CartSessionId = sessionId,
                ProductId = productId,
                Quantity = quantity
            };

            await _cartRepo.AddOrUpdateCartItemAsync(item);
        }

        public async Task RemoveFromCartAsync(int id) => await _cartRepo.RemoveItemAsync(id);

        public async Task ClearCartAsync(string sessionId) => await _cartRepo.ClearCartAsync(sessionId);

        public async Task<float> GetCartSubtotalAsync(string sessionId)
        {
            var items = await _cartRepo.GetCartItemsAsync(sessionId);
            return items.Sum(i => i.Quantity * i.Product.Price);
        }
    }
}
