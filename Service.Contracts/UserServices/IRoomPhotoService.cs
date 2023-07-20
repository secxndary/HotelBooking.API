using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoomPhotoService
{
    IEnumerable<RoomPhotoDto> GetRoomPhotos(Guid roomId, bool trackChanges);
    IEnumerable<RoomPhotoDto> GetByIds(Guid roomId, IEnumerable<Guid> ids, bool trackChanges);
    RoomPhotoDto GetRoomPhoto(Guid roomId, Guid id, bool trackChanges);
    RoomPhotoDto CreateRoomPhoto(Guid roomId, RoomPhotoForCreationDto roomPhoto, bool trackChanges);
    (IEnumerable<RoomPhotoDto> roomPhotos, string ids) CreateRoomPhotoCollection 
        (Guid roomId, IEnumerable<RoomPhotoForCreationDto> roomPhotosCollection);
    void UpdateRoomPhoto(Guid roomId, Guid id, RoomPhotoForUpdateDto roomPhoto, 
        bool roomTrackChanges, bool photoTrackChanges);
    (RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity) GetRoomPhotoForPatch
        (Guid roomId, Guid id, bool roomTrackChanges, bool photoTrackChanges);
    void SaveChangesForPatch(RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity);
    void DeleteRoomPhoto(Guid roomId, Guid id, bool trackChanges);
}