﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models;

namespace ThAmCo.Profile.Services.Accounts
{
    public class AccountsService : IAccountsService
    {
        private readonly HttpClient _client;

        public AccountsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetCurrentAccountId(string accessToken)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, _client.BaseAddress + "me");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Account> GetAccountDetails(Guid profileId)
        {
            var response = await _client.GetAsync($"id/{profileId}");
            if (!response.IsSuccessStatusCode)
                return null;

            var account = await response.Content.ReadAsAsync<Account>();
            return account;
        }

        public async Task<IEnumerable<Account>> GetMultipleAccounts(int? limit)
        {
            var response = await _client.GetAsync($"accounts{(limit != null ? $"/{limit}" : "")}");
            if (!response.IsSuccessStatusCode)
                return null;

            var accounts = await response.Content.ReadAsAsync<List<Account>>();
            return accounts;
        }
    }
}