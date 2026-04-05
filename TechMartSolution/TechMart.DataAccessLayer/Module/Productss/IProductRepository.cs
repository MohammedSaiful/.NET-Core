using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMart.Domain.Entities;


namespace TechMart.DataAccessLayer.Module.Productss
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task UpdateStockAsync(int productId, int quantity);
    }
}
