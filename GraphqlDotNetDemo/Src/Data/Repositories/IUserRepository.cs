using GraphqlDotNetDemo.Src.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphQLDotNet.Src.Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Find all users with role included that satisfy the given lambda expression
        /// </summary>
        Task<IEnumerable<User>> FindAllWithRoleAsync(Expression<Func<User, bool>> expression);

        /// <summary>
        /// Find all users with role included without lamba expression
        /// </summary>
        Task<IEnumerable<User>> FindAllWithRoleAsync();

        /// <summary>
        /// Get user by id with role included
        /// </summary>
        Task<User> FindByIdWithRoleAsync(Guid id);

        /// <summary>
        /// Find one user with role included that satisfy the given lambda expression
        /// </summary>
        Task<User> FindOneWithRoleAsync(Expression<Func<User, bool>> expression);
    }
}
