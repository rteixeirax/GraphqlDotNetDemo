using GraphqlDotNetDemo.Src.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphQLDotNet.Src.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly StorageContext db;

        public UserRepository(StorageContext context) : base(context)
        {
            this.db = context;
        }

        public override async Task AddAsync(User user)
        {
            user.Id = Guid.NewGuid();
            await this.db.Users.AddAsync(user);
        }

        public async Task<IEnumerable<User>> FindAllWithRoleAsync(Expression<Func<User, bool>> expression)
        {
            return await this.db.Users.Include(x => x.Role).Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<User>> FindAllWithRoleAsync()
        {
            return await this.db.Users.Include(x => x.Role).ToListAsync();
        }

        public async Task<User> FindByIdWithRoleAsync(Guid id)
        {
            return await this.db.Users
                .Include(user => user.Role)
                .Where(user => user.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> FindOneWithRoleAsync(Expression<Func<User, bool>> expression)
        {
            return await this.db.Users.Include(x => x.Role).SingleOrDefaultAsync(expression);
        }
    }
}
