using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IHotelPhotoRepository
{
    Task<IEnumerable<HotelPhoto>> GetHotelPhotosAsync(Guid hotelId, bool trackChanges);
    Task<IEnumerable<HotelPhoto>> GetByIdsAsync(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges);
    Task<HotelPhoto?> GetHotelPhotoAsync(Guid hotelId, Guid id, bool trackChanges);
    void CreateHotelPhoto(Guid hotelId, HotelPhoto hotelPhoto);
    void DeleteHotelPhoto(HotelPhoto photo);
}