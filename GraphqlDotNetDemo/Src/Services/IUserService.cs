using GraphqlDotNetDemo.Src.Data.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public interface IUserService
    {
        // <summary>
        /// Create new user async
        /// </summary>
        Task<User> CreateAsync(User user);

        /// <summary>
        /// Delete multiple users
        /// </summary>
        Task<bool> DeleteAsync(Guid[] userIds);

        /// <summary>
        /// Delete one user
        /// </summary>
        Task<string> DeleteAsync(Guid userId);

        /// <summary>
        /// Get all users
        /// </summary>
        Task<IEnumerable<User>> GetAllAsync();

        /// <summary>
        /// Get user by email
        /// </summary>
        Task<User> GetByEmailAsync(string email);

        /// <summary>
        /// Get user by id
        /// </summary>
        Task<User> GetByIdAsync(Guid userId);

        /// <summary>
        /// Update user
        /// </summary>
        Task<User> UpdateAsync(User user);
    }
}
