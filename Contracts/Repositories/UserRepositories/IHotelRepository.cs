using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IHotelRepository
{
    IEnumerable<Hotel> GetAllHotels(bool trackChanges);
    IEnumerable<Hotel> GetByIds(IEnumerable<Guid> ids,  bool trackChanges);
    Hotel? GetHotel(Guid id, bool trackChanges);
    void CreateHotel(Hotel hotel);
    void DeleteHotel(Hotel hotel);
}