using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IHotelPhotoRepository
{
    IEnumerable<HotelPhoto> GetHotelPhotos(Guid hotelId, bool trackChanges);
    HotelPhoto? GetHotelPhoto(Guid hotelId, Guid id, bool trackChanges);
    void CreateHotelPhoto(Guid hotelId, HotelPhoto hotelPhoto);
    void DeleteHotelPhoto(HotelPhoto photo);
}