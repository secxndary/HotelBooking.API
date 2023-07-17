using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
namespace Service.Contracts.UserServices;

public interface IRoomPhotoService
{
    IEnumerable<RoomPhotoDto> GetRoomPhotos(Guid roomId, bool trackChanges);
    IEnumerable<RoomPhotoDto> GetByIds(Guid roomId, IEnumerable<Guid> ids, bool trackChanges);
    RoomPhotoDto GetRoomPhoto(Guid roomId, Guid id, bool trackChanges);
    RoomPhotoDto CreateRoomPhoto(Guid roomId, RoomPhotoForCreationDto roomPhoto, bool trackChanges);
    (IEnumerable<RoomPhotoDto> roomPhotos, string ids) CreateRoomPhotoCollection 
        (Guid roomId, IEnumerable<RoomPhotoForCreationDto> roomPhotosCollection);
    void DeleteRoomPhoto(Guid roomId, Guid id, bool trackChanges);
}