using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class RoomPhotoRepository : RepositoryBase<RoomPhoto>, IRoomPhotoRepository
{
    public RoomPhotoRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}