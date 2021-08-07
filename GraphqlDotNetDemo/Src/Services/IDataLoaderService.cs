using GraphqlDotNetDemo.Src.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public interface IDataLoaderService
    {
        Task<ILookup<Guid, Account>> AccountsByOwnerIdsAsync(IEnumerable<Guid> ownerIds);

        Task<IDictionary<Guid, Owner>> OwnersByIdAsync(IEnumerable<Guid> ownerIds);
    }
}
