using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Entities;

namespace GraphqlDotNetDemo.Src.Graphql.UserGQL
{
    public class UserStatusEnumType : EnumerationGraphType<UserStatusEnum>
    {
        public UserStatusEnumType()
        {
            Name = nameof(UserStatusEnum);
            Description = "Enumeration for the user status.";
        }
    }
}
