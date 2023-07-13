using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.UserRepositoriesImpl;

public class RoomPhotoRepository : RepositoryBase<RoomPhoto>, IRoomPhotoRepository
{
    public RoomPhotoRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<RoomPhoto> GetRoomPhotos(Guid roomId, bool trackChanges) =>
        FindByCondition(p => p.RoomId.Equals(roomId), trackChanges)
        .OrderBy(p => p.Path)
        .ToList();

    public RoomPhoto GetRoomPhoto(Guid roomId, Guid id, bool trackChanges) =>
        FindByCondition(p =>
            p.RoomId.Equals(roomId) &&
            p.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}