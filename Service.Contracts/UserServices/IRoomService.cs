using System.Dynamic;
using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.Contracts.UserServices;

public interface IRoomService
{
    Task<(IEnumerable<ExpandoObject> rooms, MetaData metaData)> GetRoomsAsync(Guid hotelId, RoomParameters roomParameters);
    Task<IEnumerable<RoomDto>> GetByIdsForHotelAsync(Guid hotelId, IEnumerable<Guid> ids);
    Task<RoomDto> GetRoomAsync(Guid hotelId, Guid id);
    Task<RoomDto> CreateRoomForHotelAsync(Guid hotelId, RoomForCreationDto room);
    Task<(IEnumerable<RoomDto> rooms, string ids)> CreateRoomCollectionAsync
        (Guid hotelId, IEnumerable<RoomForCreationDto> roomsCollection);
    Task<RoomDto> UpdateRoomForHotelAsync(Guid hotelId, Guid id, RoomForUpdateDto roomForUpdate);
    Task<(RoomForUpdateDto roomToPatch, Room roomEntity)> GetRoomForPatchAsync(Guid hotelId, Guid id);
    Task<RoomDto> SaveChangesForPatchAsync(RoomForUpdateDto roomToPatch, Room roomEntity);
    Task DeleteRoomForHotelAsync(Guid hotelId, Guid id);
}