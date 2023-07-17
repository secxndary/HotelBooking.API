using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomPhotoRepository
{
    IEnumerable<RoomPhoto> GetRoomPhotos(Guid roomId, bool trackChanges);
    IEnumerable<RoomPhoto> GetByIds(Guid roomId, IEnumerable<Guid> ids, bool trackChanges);
    RoomPhoto? GetRoomPhoto(Guid roomId, Guid id, bool trackChanges);
    void CreateRoomPhoto(Guid roomId, RoomPhoto roomPhoto);
    void DeleteRoomPhoto(RoomPhoto photo);
}