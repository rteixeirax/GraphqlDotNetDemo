using GraphQL.DataLoader;
using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Models;
using GraphqlDotNetDemo.Src.Graphql.UserGQL;
using GraphqlDotNetDemo.Src.Services;

using System;

namespace GraphqlDotNetDemo.Src.Graphql.RoleGQL
{
    public class RoleType : ObjectGraphType<Role>
    {
        public RoleType(
            IDataLoaderService dataLoaderService,
            IDataLoaderContextAccessor dataLoader
         )
        {
            Name = nameof(Role);
            Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Role ID");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("Role Name");
            Field(x => x.Code, type: typeof(StringGraphType)).Description("Role Code");
            Field<ListGraphType<UserType>>("users", resolve: context =>
            {
                var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, User>(
                    nameof(dataLoaderService.UsersByRoleIdAsync), dataLoaderService.UsersByRoleIdAsync);

                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}
