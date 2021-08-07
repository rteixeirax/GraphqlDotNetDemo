using GraphqlDotNetDemo.Src.Data.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(Account account);

        Task<string> DeleteAccountAsync(Guid accountId);

        Task<Account> GetAccountAsync(Guid accountId);

        Task<IEnumerable<Account>> GetAccountsAsync();

        Task<Account> UpdateAccountAsync(Guid accountId, Account account);
    }
}
