using GraphqlDotNetDemo.Src.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphqlDotNetDemo.Src.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Type)
                .IsRequired();

            builder
               .Property(x => x.OwnerId)
               .IsRequired();

            // Constraints
            builder
                .HasOne(x => x.Owner)
                .WithMany(x => x.Accounts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
