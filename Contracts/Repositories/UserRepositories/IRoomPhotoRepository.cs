using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomPhotoRepository
{
    Task<IEnumerable<RoomPhoto>> GetRoomPhotosAsync(Guid roomId, bool trackChanges);
    Task<IEnumerable<RoomPhoto>> GetByIdsAsync(Guid roomId, IEnumerable<Guid> ids, bool trackChanges);
    Task<RoomPhoto?> GetRoomPhotoAsync(Guid roomId, Guid id, bool trackChanges);
    void CreateRoomPhoto(Guid roomId, RoomPhoto roomPhoto);
    void DeleteRoomPhoto(RoomPhoto photo);
}