using GraphQLDotNet.Src.Data.Repositories;

using GraphqlDotNetDemo.Src.Data.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository repo;

        public RoleService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            await this.repo.Roles.AddAsync(role);
            await this.repo.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteAsync(Guid[] roleIds)
        {
            for (int i = 0; i < roleIds.Length; i++)
            {
                await DeleteAsync(roleIds[i]);
            }

            return true;
        }

        public async Task<string> DeleteAsync(Guid roleId)
        {
            var dataModel = await this.repo.Roles.GetByIdAsync(roleId);
            this.repo.Roles.Remove(dataModel);
            await this.repo.SaveChangesAsync();
            return $"The role with the id: '{roleId}' has been successfully deleted from db.";
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var dataModels = await this.repo.Roles.GetAllAsync();
            return dataModels;
        }

        public async Task<Role> GetByIdAsync(Guid roleId)
        {
            var dataModel = await this.repo.Roles.GetByIdAsync(roleId);
            return dataModel;
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            var dataModel = await this.repo.Roles.GetByIdAsync(role.Id);
            dataModel.Name = role.Name;
            dataModel.Code = role.Code;
            await this.repo.SaveChangesAsync();
            return dataModel;
        }
    }
}
