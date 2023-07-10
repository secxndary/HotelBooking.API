using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}