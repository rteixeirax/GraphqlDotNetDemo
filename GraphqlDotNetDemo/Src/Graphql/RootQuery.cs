using GraphQL.Types;

using GraphqlDotNetDemo.Src.Services;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public partial class RootQuery : ObjectGraphType
    {
        public RootQuery(
            IOwnerService ownerService,
            IAccountService accountService,
            IRoleService roleService,
            IUserService userService
        )
        {
            Name = "Query";
            SetOwnerQueries(ownerService);
            SetAccountQueries(accountService);
            SetRoleQueries(roleService);
            SetUserQueries(userService);
        }
    }
}
