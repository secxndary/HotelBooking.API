using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetRoomsAsync(Guid hotelId, bool trackChanges);
    Task<IEnumerable<Room>> GetByIdsForHotelAsync(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges);
    Task<Room?> GetRoomAsync(Guid hotelId, Guid id, bool trackChanges);
    Task<Room?> GetRoomAsync(Guid id, bool trackChanges);
    void CreateRoomForHotel(Guid hotelId, Room room);
    void DeleteRoom(Room room);
}