using GraphqlDotNetDemo.Src.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace GraphqlDotNetDemo.Src.Data.Seeds
{
    public class OwnerSeed : IEntityTypeConfiguration<Owner>
    {
        private readonly Guid[] ids;

        public OwnerSeed(Guid[] ids)
        {
            this.ids = ids;
        }

        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasData(
                new Owner
                {
                    Id = this.ids[0],
                    Name = "John Doe",
                    Address = "John Doe's address"
                },
                new Owner
                {
                    Id = this.ids[1],
                    Name = "Jane Doe",
                    Address = "Jane Doe's address"
                }
            );
        }
    }
}
