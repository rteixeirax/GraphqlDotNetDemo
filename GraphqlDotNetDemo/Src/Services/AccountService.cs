using GraphQLDotNet.Src.Data.Repositories;

using GraphqlDotNetDemo.Src.Data.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository repo;

        public AccountService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            await this.repo.Accounts.AddAsync(account);
            await this.repo.SaveChangesAsync();
            return account;
        }

        public async Task<string> DeleteAccountAsync(Guid accountId)
        {
            var dbAccount = await this.repo.Accounts.GetByIdAsync(accountId);
            this.repo.Accounts.Remove(dbAccount);
            await this.repo.SaveChangesAsync();
            return $"The account with the id: {accountId} has been successfully deleted from db.";
        }

        public async Task<Account> GetAccountAsync(Guid accountId)
        {
            var account = await this.repo.Accounts.GetByIdAsync(accountId);
            return account;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            var accounts = await this.repo.Accounts.GetAllAsync();
            return accounts;
        }

        public async Task<Account> UpdateAccountAsync(Guid accountId, Account account)
        {
            var dbAccount = await this.repo.Accounts.GetByIdAsync(accountId);
            dbAccount.Description = account.Description;
            dbAccount.Type = account.Type;
            dbAccount.OwnerId = account.OwnerId;
            await this.repo.SaveChangesAsync();
            return dbAccount;
        }
    }
}
