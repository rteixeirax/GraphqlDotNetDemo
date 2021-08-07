using GraphqlDotNetDemo.Src.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace GraphqlDotNetDemo.Src.Data.Seeds
{
    class AccountSeed : IEntityTypeConfiguration<Account>
    {
        private readonly Guid[] ids;

        public AccountSeed(Guid[] ids)
        {
            this.ids = ids;
        }

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = AccountTypeEnum.Cash,
                    Description = "Cash account for our users",
                    OwnerId = this.ids[0]
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = AccountTypeEnum.Savings,
                    Description = "Savings account for our users",
                    OwnerId = this.ids[1]
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = AccountTypeEnum.Income,
                    Description = "Income account for our users",
                    OwnerId = this.ids[1]
                }
           );
        }
    }
}
