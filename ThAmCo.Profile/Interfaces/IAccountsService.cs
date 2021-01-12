using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThAmCo.Profile.Models;

namespace ThAmCo.Profile.Interfaces
{
    public interface IAccountsService
    {
        public Task<Account> GetAccountDetails(Guid profileId);
        public Task<IEnumerable<Account>> GetMultipleAccounts(int? limit);
    }
}
