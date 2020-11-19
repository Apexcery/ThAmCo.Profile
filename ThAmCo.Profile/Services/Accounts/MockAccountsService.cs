using System;
using System.Threading.Tasks;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models;

namespace ThAmCo.Profile.Services.Accounts
{
    public class MockAccountsService : IAccountsService
    {
        public async Task<Account> GetAccountDetails(Guid profileId)
        {
            var accountDetails = new Account
            {
                AccountId = Guid.NewGuid()
            };

            return accountDetails;
        }
    }
}
