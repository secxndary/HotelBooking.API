using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomRepository
{
    IEnumerable<Room> GetRooms(Guid hotelId, bool trackChanges);
    Room GetRoom(Guid hotelId, Guid id, bool trackChanges);
    Room GetRoom(Guid id, bool trackChanges);
    void CreateRoomForHotel(Guid hotelId, Room room);
}