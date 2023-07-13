using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IHotelRepository
{
    IEnumerable<Hotel> GetAllHotels(bool trackChanges);
    Hotel GetHotel(Guid id, bool trackChanges);
    void CreateHotel(Hotel hotel);
}