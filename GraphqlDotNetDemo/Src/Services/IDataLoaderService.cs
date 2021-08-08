using GraphqlDotNetDemo.Src.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public interface IDataLoaderService
    {
        Task<ILookup<Guid, Account>> AccountsByOwnerIdAsync(IEnumerable<Guid> ownerIds);

        Task<IDictionary<Guid, Owner>> OwnerByIdAsync(IEnumerable<Guid> ownerIds);

        Task<IDictionary<Guid, Role>> RoleByIdAsync(IEnumerable<Guid> roleIds);

        Task<ILookup<Guid, User>> UsersByRoleIdAsync(IEnumerable<Guid> roleIds);
    }
}
