using GraphQLDotNet.Src.Data.Repositories;

using GraphqlDotNetDemo.Src.Data.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository repo;

        public OwnerService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Owner> CreateOwnerAsync(Owner owner)
        {
            await this.repo.Owners.AddAsync(owner);
            await this.repo.SaveChangesAsync();
            return owner;
        }

        public async Task<string> DeleteOwnerAsync(Guid ownerId)
        {
            var dbOwner = await this.repo.Owners.GetByIdAsync(ownerId);
            this.repo.Owners.Remove(dbOwner);
            await this.repo.SaveChangesAsync();
            return $"The owner with the id: {ownerId} has been successfully deleted from db.";
        }

        public async Task<Owner> GetOwnerAsync(Guid ownerId)
        {
            var owner = await this.repo.Owners.GetByIdAsync(ownerId);
            return owner;
        }

        public async Task<IEnumerable<Owner>> GetOwnersAsync()
        {
            var owners = await this.repo.Owners.GetAllAsync();
            return owners;
        }

        public async Task<Owner> UpdateOwnerAsync(Guid ownerId, Owner owner)
        {
            var dbOwner = await this.repo.Owners.GetByIdAsync(ownerId);
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            await this.repo.SaveChangesAsync();
            return dbOwner;
        }
    }
}
