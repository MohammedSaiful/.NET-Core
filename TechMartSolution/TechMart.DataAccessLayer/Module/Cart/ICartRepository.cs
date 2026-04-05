using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMart.Domain.Entities;

namespace TechMart.DataAccessLayer.Module.Cart
{
    public interface ICartRepository
    {
        Task<List<CartItem>> GetCartItemsAsync(string sessionId);
        Task AddOrUpdateCartItemAsync(CartItem item);
        Task RemoveItemAsync(int id);
        Task ClearCartAsync(string sessionId);
    }
}
