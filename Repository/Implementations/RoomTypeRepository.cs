using Contracts.Repositories;
using Entities.Models;

namespace Repository.RepositoryUser;

public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}