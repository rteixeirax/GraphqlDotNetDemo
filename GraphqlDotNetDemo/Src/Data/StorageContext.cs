using GraphqlDotNetDemo.Src.Data.Configurations;
using GraphqlDotNetDemo.Src.Data.Entities;
using GraphqlDotNetDemo.Src.Data.Seeds;

using Microsoft.EntityFrameworkCore;

using System;

namespace GraphQLDotNet.Src.Data
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };
            var adminRoleId = Guid.NewGuid();

            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // Seed
            modelBuilder.ApplyConfiguration(new AccountSeed(ids));
            modelBuilder.ApplyConfiguration(new OwnerSeed(ids));
            modelBuilder.ApplyConfiguration(new RoleSeed(adminRoleId));
            modelBuilder.ApplyConfiguration(new UserSeed(adminRoleId));
        }
    }
}
