using GraphqlDotNetDemo.Src.Data.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphqlDotNetDemo.Src.Services
{
    public interface IRoleService
    {
        // <summary>
        /// Create new user async
        /// </summary>
        Task<Role> CreateAsync(Role role);

        /// <summary>
        /// Delete multiple roles
        /// </summary>
        Task<bool> DeleteAsync(Guid[] roleIds);

        /// <summary>
        /// Delete one role
        /// </summary>
        Task<string> DeleteAsync(Guid roleId);

        /// <summary>
        /// Get all roles
        /// </summary>
        Task<IEnumerable<Role>> GetAllAsync();

        /// <summary>
        /// Get role by id
        /// </summary>
        Task<Role> GetByIdAsync(Guid roleId);

        /// <summary>
        /// Update role
        /// </summary>
        Task<Role> UpdateAsync(Role role);
    }
}
