using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoomTypeRepository
{
    Task<IEnumerable<RoomType>> GetAllRoomTypesAsync(bool trackChanges);
    Task<RoomType?> GetRoomTypeAsync(Guid id, bool trackChanges);
    void CreateRoomType(RoomType roomType);
    void DeleteRoomType(RoomType roomType);
}