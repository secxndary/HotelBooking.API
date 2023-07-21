using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoomService
{
    Task<IEnumerable<RoomDto>> GetRoomsAsync(Guid hotelId, bool trackChanges);
    Task<IEnumerable<RoomDto>> GetByIdsForHotelAsync(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges);
    Task<RoomDto> GetRoomAsync(Guid hotelId, Guid id, bool trackChanges);
    Task<RoomDto> GetRoomAsync(Guid id, bool trackChanges);
    Task<RoomDto> CreateRoomForHotelAsync(Guid hotelId, RoomForCreationDto room, bool trackChanges);
    Task<(IEnumerable<RoomDto> rooms, string ids)> CreateRoomCollectionAsync
        (Guid hotelId, IEnumerable<RoomForCreationDto> roomsCollection);
    Task UpdateRoomForHotelAsync(Guid hotelId, Guid id, RoomForUpdateDto roomForUpdate, 
        bool hotelTrackChanges, bool roomTrackChanges);
    Task<(RoomForUpdateDto roomToPatch, Room roomEntity)> GetRoomForPatchAsync
        (Guid hotelId, Guid id, bool hotelTrackChanges, bool roomTrackChanges);
    Task SaveChangesForPatchAsync(RoomForUpdateDto roomToPatch, Room roomEntity);
    Task DeleteRoomForHotelAsync(Guid hotelId, Guid id, bool trackChanges);
}