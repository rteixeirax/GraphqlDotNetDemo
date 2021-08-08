using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Entities;

namespace GraphqlDotNetDemo.Src.Graphql.AccountGQL
{
    public class AccountTypeEnumType : EnumerationGraphType<AccountTypeEnum>
    {
        public AccountTypeEnumType()
        {
            Name = nameof(AccountTypeEnum);
            Description = "Enumeration for the account type object.";
        }
    }
}
