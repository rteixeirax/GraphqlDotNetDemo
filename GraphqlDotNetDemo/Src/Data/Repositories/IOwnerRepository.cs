using GraphqlDotNetDemo.Src.Data.Models;

namespace GraphQLDotNet.Src.Data.Repositories
{
    public interface IOwnerRepository : IBaseRepository<Owner>
    {
        // We only need a method that already exists in the BaseRepository
    }
}
