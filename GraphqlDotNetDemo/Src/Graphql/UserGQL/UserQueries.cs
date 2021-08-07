using GraphQL.Types;

using GraphqlDotNetDemo.Src.Graphql.UserGQL;
using GraphqlDotNetDemo.Src.Services;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public partial class RootQuery
    {
        protected void SetUserQueries(IUserService userService)
        {
            FieldAsync<ListGraphType<UserType>>(
               "users",
               resolve: async context =>
               {
                   return await userService.GetAllAsync();
               }
            );
        }
    }
}
