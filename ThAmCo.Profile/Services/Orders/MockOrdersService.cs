using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models;

namespace ThAmCo.Profile.Services.Orders
{
    public class MockOrdersService : IOrdersService
    {
        public async Task<List<Order>> GetOrderHistory(Guid profileId)
        {
            var orderHistory = new List<Order>
            {
                new Order
                {
                    OrderId = Guid.NewGuid()
                },
                new Order
                {
                    OrderId = Guid.NewGuid()
                },
                new Order
                {
                    OrderId = Guid.NewGuid()
                }
            };

            return orderHistory;
        }
    }
}
