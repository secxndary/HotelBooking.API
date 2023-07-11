using Shared.DataTransferObjects;
namespace Service.Contracts.UserServices;

public interface IRoomService
{
    IEnumerable<RoomDto> GetRooms(Guid hotelId, bool trackChanges);
}