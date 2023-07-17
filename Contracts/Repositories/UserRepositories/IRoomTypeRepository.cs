using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomTypeRepository
{
    IEnumerable<RoomType> GetAllRoomTypes(bool trackChanges);
    RoomType? GetRoomType(Guid id, bool trackChanges);
    void CreateRoomType(RoomType roomType);
    void DeleteRoomType(RoomType roomType);
}