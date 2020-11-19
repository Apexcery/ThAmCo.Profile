using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models;

namespace ThAmCo.Profile.Services
{
    public class OrdersService : IOrdersService
    {
        public async Task<List<Order>> GetOrderHistory(Guid profileId)
        {
            throw new NotImplementedException();
        }
    }
}
