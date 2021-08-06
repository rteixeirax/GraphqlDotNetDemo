using GraphQL.Types;
using GraphQL.Utilities;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace GraphqlDotNetDemo.Src.Graphql
{
    public class GraphqlSchema : Schema
    {
        public GraphqlSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<RootQuery>();
            Mutation = provider.GetRequiredService<RootMutation>();
        }
    }
}
