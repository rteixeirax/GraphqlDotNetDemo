using GraphQL.Types;

using GraphqlDotNetDemo.Src.Graphql.RoleGQL;
using GraphqlDotNetDemo.Src.Services;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public partial class RootQuery
    {
        protected void SetRoleQueries(IRoleService roleServices)
        {
            FieldAsync<ListGraphType<RoleType>>(
              "roles",
              resolve: async context =>
              {
                  return await roleServices.GetAllAsync();
              }
            );
        }
    }
}
