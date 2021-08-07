using GraphQLDotNet.Src.Data.Repositories;

using GraphqlDotNetDemo.Src.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public class DataLoaderService : IDataLoaderService
    {
        private readonly IRepository repo;

        public DataLoaderService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<ILookup<Guid, Account>> AccountsByOwnerIdAsync(IEnumerable<Guid> ownerIds)
        {
            var dataModels = await this.repo.Accounts.FindAllAsync(account => ownerIds.Contains(account.OwnerId));
            return dataModels.ToLookup(account => account.OwnerId);
        }

        public async Task<IDictionary<Guid, Owner>> OwnerByIdAsync(IEnumerable<Guid> ownerIds)
        {
            var dataModels = await this.repo.Owners.FindAllAsync(owner => ownerIds.Contains(owner.Id));
            return dataModels.ToDictionary(owner => owner.Id);
        }

        public async Task<IDictionary<Guid, Role>> RoleByIdAsync(IEnumerable<Guid> roleIds)
        {
            var dataModels = await this.repo.Roles.FindAllAsync(role => roleIds.Contains(role.Id));
            return dataModels.ToDictionary(role => role.Id);
        }

        public async Task<ILookup<Guid, User>> UsersByRoleIdAsync(IEnumerable<Guid> roleIds)
        {
            var dataModels = await this.repo.Users.FindAllAsync(user => roleIds.Contains(user.RoleId));
            return dataModels.ToLookup(user => user.RoleId);
        }
    }
}
