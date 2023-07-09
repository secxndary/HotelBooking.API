using Contracts.Repositories;
using Entities.Models;

namespace Repository.RepositoryUser;

public class RoomPhotoRepository : RepositoryBase<RoomPhoto>, IRoomPhotoRepository
{
    public RoomPhotoRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}