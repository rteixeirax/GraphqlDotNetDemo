using GraphQL;
using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Entities;
using GraphqlDotNetDemo.Src.Graphql.OwnerGQL;
using GraphqlDotNetDemo.Src.Services;

using System;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public partial class RootMutation
    {
        protected void SetOwnerMutations(IOwnerService ownerService)
        {
            FieldAsync<OwnerType>(
                "ownerCreate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "data" }),
                resolve: async context =>
                {
                    var data = context.GetArgument<Owner>("data");
                    return await ownerService.CreateOwnerAsync(data);
                }
            );

            FieldAsync<OwnerType>(
                "ownerUpdate",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "data" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownerId" }),
                resolve: async context =>
                {
                    var data = context.GetArgument<Owner>("data");
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    return await ownerService.UpdateOwnerAsync(ownerId, data);
                }
            );

            FieldAsync<StringGraphType>(
                "ownerDelete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: async context =>
                {
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    return await ownerService.DeleteOwnerAsync(ownerId);
                }
            );
        }
    }
}
