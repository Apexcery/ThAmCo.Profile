using System;
using System.Threading.Tasks;
using ThAmCo.Profile.Models;

namespace ThAmCo.Profile.Interfaces
{
    public interface IAccountsService
    {
        public Task<Account> GetAccountDetails(Guid profileId);
    }
}
