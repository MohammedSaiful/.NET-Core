using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMart.Domain.Entities;

namespace TechMart.Business.Modules.CheckoutServices
{
    public interface ICheckoutService
    {
        Task<float> CalculateTotalAsync(string sessionId, float taxRate, float shippingFee);
        Task<Order> PlaceOrderAsync(string sessionId, string shippingAddress);
    }
}
