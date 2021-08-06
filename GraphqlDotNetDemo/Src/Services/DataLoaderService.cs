using GraphQLDotNet.Src.Data.Repositories;

using GraphqlDotNetDemo.Src.Data.Entities;

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

        public async Task<ILookup<Guid, Account>> AccountsByOwnerIdsAsync(IEnumerable<Guid> ownerIds)
        {
            var dataModels = await this.repo.Accounts.FindAllAsync(x => ownerIds.Contains(x.OwnerId));
            return dataModels.ToLookup(x => x.OwnerId);
        }

        public async Task<IDictionary<Guid, Owner>> OwnersByIdAsync(IEnumerable<Guid> ownerIds)
        {
            var dataModels = await this.repo.Owners.FindAllAsync(x => ownerIds.Contains(x.Id));
            return dataModels.ToDictionary(x => x.Id);
        }
    }
}
