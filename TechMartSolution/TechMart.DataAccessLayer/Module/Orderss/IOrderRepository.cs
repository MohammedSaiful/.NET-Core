using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMart.Domain.Entities;

namespace TechMart.DataAccessLayer.Module.Orderss
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> GetOrderById(int id);
    }
    
}
