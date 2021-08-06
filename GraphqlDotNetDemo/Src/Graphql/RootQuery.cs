using GraphQL.Types;

using GraphqlDotNetDemo.Src.Services;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public partial class RootQuery : ObjectGraphType
    {
        public RootQuery(
            IOwnerService ownerService,
            IAccountService accountService
        )
        {
            Name = "Query";
            SetOwnerQueries(ownerService);
            SetAccountQueries(accountService);
        }
    }
}
