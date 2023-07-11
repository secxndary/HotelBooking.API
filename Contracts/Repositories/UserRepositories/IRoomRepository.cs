using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomRepository
{
    IEnumerable<Room> GetRooms(Guid hotelId, bool trackChanges);
}