using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphQLDotNet.Src.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add a new entity
        /// </summary>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Count how many entities exists
        /// </summary>
        Task<int> CountAsync();

        /// <summary>
        /// Find all entities that satisfy the given lambda expression
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Find one entity that satisfy the given lambda expression
        /// </summary>
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Find the first
        /// </summary>
        Task<TEntity> FindOneAsync();

        /// <summary>
        /// Get all entities
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Get entity by Id
        /// </summary>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Remove one entity
        /// </summary>
        void Remove(TEntity entity);
    }
}
