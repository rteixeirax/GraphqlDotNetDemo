using GraphQL.DataLoader;
using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Entities;
using GraphqlDotNetDemo.Src.Graphql.OwnerGQL;
using GraphqlDotNetDemo.Src.Services;

using System;

namespace GraphqlDotNetDemo.Src.Graphql.AccountGQL
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType(
            IAccountService accountService,
            IDataLoaderService dataLoaderService,
            IDataLoaderContextAccessor dataLoader
        )
        {
            Name = nameof(Account);
            Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property from the account object.");
            Field(x => x.Description, type: typeof(StringGraphType)).Description("Description property from the account object.");
            Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
            Field(x => x.Type, type: typeof(AccountTypeEnumType));
            Field<OwnerType>("owner", resolve: context =>
            {
                var loader = dataLoader.Context
                    .GetOrAddBatchLoader<Guid, Owner>(nameof(dataLoaderService.OwnersByIdAsync), dataLoaderService.OwnersByIdAsync);

                return loader.LoadAsync(context.Source.OwnerId);
            });
        }
    }
}
