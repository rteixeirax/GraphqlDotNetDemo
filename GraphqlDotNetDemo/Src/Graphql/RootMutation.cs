using GraphQL.Types;

using GraphqlDotNetDemo.Src.Services;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public partial class RootMutation : ObjectGraphType
    {
        public RootMutation(
            IOwnerService ownerService,
            IAccountService accountService
         )
        {
            Name = "Mutation";
            SetOwnerMutations(ownerService);
            SetAccountMutations(accountService);
        }
    }
}
