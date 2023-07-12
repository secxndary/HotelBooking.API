using Shared.DataTransferObjects;
namespace Service.Contracts.UserServices;

public interface IRoomPhotoService
{
    IEnumerable<RoomPhotoDto> GetRoomPhotos(Guid roomId, bool trackChanges);
    RoomPhotoDto GetRoomPhoto(Guid roomId, Guid id, bool trackChanges);
}