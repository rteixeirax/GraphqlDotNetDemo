using GraphqlDotNetDemo.Src.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace GraphqlDotNetDemo.Src.Data.Seeds
{
    class RoleSeed : IEntityTypeConfiguration<Role>
    {
        private readonly Guid adminRoleId;

        public RoleSeed(Guid adminRoleId)
        {
            this.adminRoleId = adminRoleId;
        }

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = this.adminRoleId,
                    Name = RoleCodeEnum.Admin.ToString(),
                    Code = RoleCodeEnum.Admin.ToString().ToLower(),
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = RoleCodeEnum.User.ToString(),
                    Code = RoleCodeEnum.User.ToString().ToLower(),
                }
            );
        }
    }
}
