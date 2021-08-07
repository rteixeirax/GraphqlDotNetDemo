using GraphQLDotNet.Src.Data.Repositories;

using GraphqlDotNetDemo.Src.Data.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<User> CreateAsync(User user)
        {
            await this.repo.Users.AddAsync(user);
            await this.repo.SaveChangesAsync();
            return user;
        }

        public async Task<string> DeleteAsync(Guid userId)
        {
            var dataModel = await this.repo.Users.GetByIdAsync(userId);
            this.repo.Users.Remove(dataModel);
            await this.repo.SaveChangesAsync();
            return $"The user with the id: '{ userId}' has been successfully deleted from db.";
        }

        public async Task<bool> DeleteAsync(Guid[] userIds)
        {
            for (int i = 0; i < userIds.Length; i++)
            {
                await DeleteAsync(userIds[i]);
            }

            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var dataModels = await this.repo.Users.GetAllAsync();
            return dataModels;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var dataModel = await this.repo.Users.FindOneAsync(x => x.Email == email);
            return dataModel;
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            var dataModel = await this.repo.Users.GetByIdAsync(userId);
            return dataModel;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var dataModel = await this.repo.Users.GetByIdAsync(user.Id);
            dataModel.Name = user.Name;
            dataModel.RoleId = user.RoleId;
            dataModel.Status = user.Status;
            dataModel.Password = user.Password;
            await this.repo.SaveChangesAsync();
            return dataModel;
        }
    }
}
