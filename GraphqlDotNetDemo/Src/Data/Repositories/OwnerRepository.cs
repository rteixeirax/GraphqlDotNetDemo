using GraphqlDotNetDemo.Src.Data.Models;

using System;
using System.Threading.Tasks;

namespace GraphQLDotNet.Src.Data.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        private readonly StorageContext db;

        public OwnerRepository(StorageContext context) : base(context)
        {
            this.db = context;
        }

        public override async Task AddAsync(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            await this.db.Owners.AddAsync(owner);
        }
    }
}
