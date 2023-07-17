using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomPhotoRepository
{
    IEnumerable<RoomPhoto> GetRoomPhotos(Guid roomId, bool trackChanges);
    RoomPhoto? GetRoomPhoto(Guid roomId, Guid id, bool trackChanges);
    void CreateRoomPhoto(Guid roomId, RoomPhoto roomPhoto);
    void DeleteRoomPhoto(RoomPhoto photo);
}