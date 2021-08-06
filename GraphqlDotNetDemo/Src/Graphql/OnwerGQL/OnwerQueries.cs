using GraphQL;
using GraphQL.Types;

using GraphqlDotNetDemo.Src.Graphql.OwnerGQL;
using GraphqlDotNetDemo.Src.Services;

using System;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public partial class RootQuery
    {
        protected void SetOwnerQueries(IOwnerService ownerService)
        {
            FieldAsync<ListGraphType<OwnerType>>(
                "owners",
                resolve: async context =>
                {
                    return await ownerService.GetOwnersAsync();
                }
            );

            FieldAsync<OwnerType>(
                "owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownerId" }),
                resolve: async context =>
                {
                    Guid ownerId;

                    if (!Guid.TryParse(context.GetArgument<string>(nameof(ownerId)), out ownerId))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for guid"));
                        return null;
                    }

                    return await ownerService.GetOwnerAsync(ownerId);
                }
            );
        }
    }
}
