using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoomService
{
    IEnumerable<RoomDto> GetRooms(Guid hotelId, bool trackChanges);
    IEnumerable<RoomDto> GetByIdsForHotel(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges);
    RoomDto GetRoom(Guid hotelId, Guid id, bool trackChanges);
    RoomDto GetRoom(Guid id, bool trackChanges);
    RoomDto CreateRoomForHotel(Guid hotelId, RoomForCreationDto room, bool trackChanges);
    (IEnumerable<RoomDto> rooms, string ids) CreateRoomCollection
        (Guid hotelId, IEnumerable<RoomForCreationDto> roomsCollection);
    void UpdateRoomForHotel(Guid hotelId, Guid id, RoomForUpdateDto roomForUpdate, 
        bool hotelTrackChanges, bool roomTrackChanges);
    void DeleteRoomForHotel(Guid hotelId, Guid id, bool trackChanges);
}