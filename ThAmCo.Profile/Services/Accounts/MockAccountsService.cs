using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models;

namespace ThAmCo.Profile.Services.Accounts
{
    public class MockAccountsService : IAccountsService
    {
        private static readonly List<Account> Accounts = new List<Account>
        {
            new Account
            {
                Id = "04494c6c-db6b-47dc-8630-fc641dca4da2",
                Username = "Username1",
                Email = "Username1@example.com",
                Forename = "Bob",
                Surname = "Smith",
                Roles = new[] { "Customer" }
            },
            new Account
            {
                Id = "84ac4c25-34e6-41f7-885f-a1bcc911aa62",
                Username = "Username2",
                Email = "Username2@example.com",
                Forename = "Sally",
                Surname = "Jenkins",
                Roles = new[] { "Customer", "Staff" }
            },
            new Account
            {
                Id = "4880754c-85ec-4ed8-85a6-b7db1d54cfc5",
                Username = "Username3",
                Email = "Username3@example.com",
                Forename = "Billy",
                Surname = "Williams",
                Roles = new[] { "Customer", "Staff", "Admin" }
            }
        };

        public async Task<string> GetCurrentAccountId(string accessToken)
        {
            return Accounts[0].Id;
        }

        public async Task<Account> GetAccountDetails(Guid profileId)
        {
            var accountDetails = Accounts.FirstOrDefault(x => x.Id.Equals(profileId.ToString(), StringComparison.CurrentCultureIgnoreCase));

            return accountDetails;
        }

        public async Task<IEnumerable<Account>> GetMultipleAccounts(int? limit)
        {
            if (limit == null || limit <= 0)
                return Accounts.Take(10).ToList();

            return Accounts.Take((int)limit).ToList();
        }
    }
}
