using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Models;

namespace GraphqlDotNetDemo.Src.Graphql.AccountGQL
{
    public class AccountInputType : InputObjectGraphType<Account>
    {
        public AccountInputType()
        {
            Name = "AccountInput";
            Field(x => x.Type, type: typeof(NonNullGraphType<AccountTypeEnumType>));
            Field(x => x.Description, type: typeof(StringGraphType)).Description("Description property from the account object.");
            Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
        }
    }
}
