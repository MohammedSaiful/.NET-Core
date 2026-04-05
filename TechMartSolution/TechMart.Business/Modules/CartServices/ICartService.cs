using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMart.Domain.Entities;

namespace TechMart.Business.Modules.CartServices
{
    public interface ICartService
    {
        Task<List<CartItem>> GetCartItemsAsync(string sessionId);
        Task AddToCartAsync(string sessionId, int productId, int quantity);
        Task RemoveFromCartAsync(int id);
        Task ClearCartAsync(string sessionId);
        Task<float> GetCartSubtotalAsync(string sessionId);
    }
}
