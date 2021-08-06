using GraphQL;
using GraphQL.Types;

using GraphqlDotNetDemo.Src.Graphql.AccountGQL;
using GraphqlDotNetDemo.Src.Services;

using System;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public partial class RootQuery
    {
        protected void SetAccountQueries(IAccountService accountService)
        {
            FieldAsync<ListGraphType<AccountType>>(
               "accounts",
               resolve: async context =>
               {
                   return await accountService.GetAccountsAsync();
               }
            );

            FieldAsync<AccountType>(
                "account",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "accountId" }),
                resolve: async context =>
                {
                    Guid accountId;

                    if (!Guid.TryParse(context.GetArgument<string>(nameof(accountId)), out accountId))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for guid"));
                        return null;
                    }

                    return await accountService.GetAccountAsync(accountId);
                }
            );
        }
    }
}
