using Contracts.Repositories;
using Entities.Models;
namespace Repository.Implementations;

public class RoomRepository : RepositoryBase<Room>, IRoomRepository
{
    public RoomRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}