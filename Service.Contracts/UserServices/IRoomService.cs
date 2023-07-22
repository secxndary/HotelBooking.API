using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoomService
{
    Task<IEnumerable<RoomDto>> GetRoomsAsync(Guid hotelId);
    Task<IEnumerable<RoomDto>> GetByIdsForHotelAsync(Guid hotelId, IEnumerable<Guid> ids);
    Task<RoomDto> GetRoomAsync(Guid hotelId, Guid id);
    Task<RoomDto> GetRoomAsync(Guid id);
    Task<RoomDto> CreateRoomForHotelAsync(Guid hotelId, RoomForCreationDto room);
    Task<(IEnumerable<RoomDto> rooms, string ids)> CreateRoomCollectionAsync
        (Guid hotelId, IEnumerable<RoomForCreationDto> roomsCollection);
    Task UpdateRoomForHotelAsync(Guid hotelId, Guid id, RoomForUpdateDto roomForUpdate);
    Task<(RoomForUpdateDto roomToPatch, Room roomEntity)> GetRoomForPatchAsync(Guid hotelId, Guid id);
    Task SaveChangesForPatchAsync(RoomForUpdateDto roomToPatch, Room roomEntity);
    Task DeleteRoomForHotelAsync(Guid hotelId, Guid id);
}