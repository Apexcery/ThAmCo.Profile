using System;
using System.Threading.Tasks;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models;

namespace ThAmCo.Profile.Services.Accounts
{
    public class AccountsService : IAccountsService
    {
        public async Task<Account> GetAccountDetails(Guid profileId)
        {
            throw new NotImplementedException();
        }
    }
}
