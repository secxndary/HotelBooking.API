using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetAllHotelsAsync(bool trackChanges);
    Task<IEnumerable<Hotel>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<Hotel?> GetHotelAsync(Guid id, bool trackChanges);
    void CreateHotel(Hotel hotel);
    void DeleteHotel(Hotel hotel);
}