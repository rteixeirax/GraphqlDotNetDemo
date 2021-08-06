using GraphqlDotNetDemo.Src.Data.Entities;

using System;
using System.Threading.Tasks;

namespace GraphQLDotNet.Src.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly StorageContext db;

        public RoleRepository(StorageContext context) : base(context)
        {
            this.db = context;
        }

        public override async Task AddAsync(Role role)
        {
            role.Id = Guid.NewGuid();
            await this.db.Roles.AddAsync(role);
        }
    }
}
