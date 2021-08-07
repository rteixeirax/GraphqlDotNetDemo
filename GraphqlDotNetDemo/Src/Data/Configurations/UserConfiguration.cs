using GraphqlDotNetDemo.Src.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphqlDotNetDemo.Src.Data.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
               .HasKey(x => x.Id);

            builder
                .Property(x => x.Status)
                .HasDefaultValue(UserStatusEnum.Active);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .IsRequired();

            builder
               .Property(x => x.RoleId)
               .IsRequired();

            // Contraints
            builder
                .HasIndex(x => x.Email)
                .IsUnique()
                .HasDatabaseName("UniqueUserEmail");

            builder
                .HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
