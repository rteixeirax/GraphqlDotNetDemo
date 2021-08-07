using GraphQL.Types;

using GraphqlDotNetDemo.Src.Data.Models;

namespace GraphqlDotNetDemo.Src.Graphql.OwnerGQL
{
    public class OwnerInputType : InputObjectGraphType<Owner>
    {
        public OwnerInputType()
        {
            Name = "OwnerInput";
            Field(x => x.Name, type: typeof(NonNullGraphType<StringGraphType>)).Description("Name property from the owner object.");
            Field(x => x.Address, type: typeof(StringGraphType)).Description("Address property from the owner object.");
        }
    }
}
