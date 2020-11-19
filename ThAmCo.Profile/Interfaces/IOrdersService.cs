using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThAmCo.Profile.Models;

namespace ThAmCo.Profile.Interfaces
{
    public interface IOrdersService
    {
        public Task<List<Order>> GetOrderHistory(Guid profileId);
    }
}
