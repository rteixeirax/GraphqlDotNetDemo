using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphQLDotNet.Src.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly StorageContext context;

        public BaseRepository(StorageContext context)
        {
            this.context = context;
        }

        // Set this as a virtual method to allow us to override this implementation when we need it!
        public virtual async Task AddAsync(TEntity entity)
        {
            await this.context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<int> CountAsync()
        {
            return await this.context.Set<TEntity>().CountAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this.context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this.context.Set<TEntity>().SingleOrDefaultAsync(expression);
        }

        public async Task<TEntity> FindOneAsync()
        {
            return await this.context.Set<TEntity>().SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await this.context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }
    }
}
