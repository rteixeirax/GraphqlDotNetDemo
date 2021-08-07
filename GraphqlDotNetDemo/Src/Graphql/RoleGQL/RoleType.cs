using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Models;
using GraphqlDotNetDemo.Src.Graphql.UserGQL;

namespace GraphqlDotNetDemo.Src.Graphql.RoleGQL
{
    public class RoleType : ObjectGraphType<Role>
    {
        public RoleType()
        {
            Name = nameof(Role);
            Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Role ID");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("Role Name");
            Field(x => x.Code, type: typeof(StringGraphType)).Description("Role Code");
            Field<ListGraphType<UserType>>("users", resolve: context => null); // TODO. Add DataLoader
        }
    }
}
