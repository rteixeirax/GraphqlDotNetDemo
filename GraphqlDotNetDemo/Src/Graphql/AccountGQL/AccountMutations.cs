using GraphQL;
using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Models;
using GraphqlDotNetDemo.Src.Graphql.AccountGQL;
using GraphqlDotNetDemo.Src.Services;

using System;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public partial class RootMutation
    {
        protected void SetAccountMutations(IAccountService accountService)
        {
            FieldAsync<AccountType>(
                "accountCreate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AccountInputType>> { Name = "data" }),
                resolve: async context =>
                {
                    var data = context.GetArgument<Account>("data");
                    return await accountService.CreateAccountAsync(data);
                }
            );

            FieldAsync<AccountType>(
                "accountUpdate",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AccountInputType>> { Name = "data" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "accountId" }),
                resolve: async context =>
                {
                    var account = context.GetArgument<Account>("data");
                    var accountId = context.GetArgument<Guid>("accountId");
                    return await accountService.UpdateAccountAsync(accountId, account);
                }
            );

            FieldAsync<StringGraphType>(
                "accountDelete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "accountId" }),
                resolve: async context =>
                {
                    var accountId = context.GetArgument<Guid>("accountId");
                    return await accountService.DeleteAccountAsync(accountId);
                }
            );
        }
    }
}
