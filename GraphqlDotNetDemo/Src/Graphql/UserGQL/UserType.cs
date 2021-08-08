using GraphQL.DataLoader;
using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Entities;
using GraphqlDotNetDemo.Src.Graphql.RoleGQL;
using GraphqlDotNetDemo.Src.Services;

using System;

namespace GraphqlDotNetDemo.Src.Graphql.UserGQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(
            IDataLoaderService dataLoaderService,
            IDataLoaderContextAccessor dataLoader
        )
        {
            Name = nameof(User);
            Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("User ID");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("User Name");
            Field(x => x.Email, type: typeof(StringGraphType)).Description("User Name");
            Field(x => x.Status, type: typeof(UserStatusEnumType)).Description("User Status");
            Field(x => x.RoleId, type: typeof(IdGraphType)).Description("User Role ID");
            Field<RoleType>("role", resolve: context =>
            {
                var loader = dataLoader.Context.GetOrAddBatchLoader<Guid, Role>(
                    nameof(dataLoaderService.RoleByIdAsync), dataLoaderService.RoleByIdAsync);

                return loader.LoadAsync(context.Source.RoleId);
            });
        }
    }
}
