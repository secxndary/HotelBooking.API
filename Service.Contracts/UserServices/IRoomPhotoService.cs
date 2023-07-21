using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoomPhotoService
{
    Task<IEnumerable<RoomPhotoDto>> GetRoomPhotosAsync(Guid roomId, bool trackChanges);
    Task<IEnumerable<RoomPhotoDto>> GetByIdsAsync(Guid roomId, IEnumerable<Guid> ids, bool trackChanges);
    Task<RoomPhotoDto> GetRoomPhotoAsync(Guid roomId, Guid id, bool trackChanges);
    Task<RoomPhotoDto> CreateRoomPhotoAsync(Guid roomId, RoomPhotoForCreationDto roomPhoto, bool trackChanges);
    Task<(IEnumerable<RoomPhotoDto> roomPhotos, string ids)> CreateRoomPhotoCollectionAsync
        (Guid roomId, IEnumerable<RoomPhotoForCreationDto> roomPhotosCollection);
    Task UpdateRoomPhotoAsync(Guid roomId, Guid id, RoomPhotoForUpdateDto roomPhoto, 
        bool roomTrackChanges, bool photoTrackChanges);
    Task<(RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity)> GetRoomPhotoForPatchAsync
        (Guid roomId, Guid id, bool roomTrackChanges, bool photoTrackChanges);
    Task SaveChangesForPatchAsync(RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity);
    Task DeleteRoomPhotoAsync(Guid roomId, Guid id, bool trackChanges);
}