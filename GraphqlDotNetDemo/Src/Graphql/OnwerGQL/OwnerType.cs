using GraphQL.DataLoader;
using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Entities;
using GraphqlDotNetDemo.Src.Graphql.AccountGQL;
using GraphqlDotNetDemo.Src.Services;

using System;

namespace GraphqlDotNetDemo.Src.Graphql.OwnerGQL
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(
            IOwnerService ownerService,
            IDataLoaderService dataLoaderService,
            IDataLoaderContextAccessor dataLoader
        )
        {
            Name = nameof(Owner);
            Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property from the owner object.");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("Name property from the owner object.");
            Field(x => x.Address, type: typeof(StringGraphType)).Description("Address property from the owner object.");
            Field<ListGraphType<AccountType>>("accounts", resolve: context =>
            {
                var loader = dataLoader.Context
                    .GetOrAddCollectionBatchLoader<Guid, Account>(nameof(dataLoaderService.AccountsByOwnerIdsAsync), dataLoaderService.AccountsByOwnerIdsAsync);

                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}
