using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMart.DataAccessLayer.Data;
using TechMart.Domain.Entities;

namespace TechMart.DataAccessLayer.Module.Cart
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context) => _context = context;

        public async Task<List<CartItem>> GetCartItemsAsync(string sessionId) =>
            await _context.CartItems.Include(c => c.Product).Where(c => c.CartSessionId == sessionId).ToListAsync();

        public async Task AddOrUpdateCartItemAsync(CartItem item)
        {
            var existing = await _context.CartItems.FirstOrDefaultAsync(c => c.CartSessionId == item.CartSessionId && c.ProductId == item.ProductId);
            if (existing != null)
            {
                existing.Quantity += item.Quantity;
            }
            else
            {
                _context.CartItems.Add(item);
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(int id)
        {
            var item = await _context.CartItems.FindAsync(id);
            if (item != null) { _context.CartItems.Remove(item); await _context.SaveChangesAsync(); }
        }

        public async Task ClearCartAsync(string sessionId)
        {
            var items = _context.CartItems.Where(c => c.CartSessionId == sessionId);
            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
