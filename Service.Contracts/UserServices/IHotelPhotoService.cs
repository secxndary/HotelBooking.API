using Shared.DataTransferObjects;
namespace Service.Contracts.UserServices;

public interface IHotelPhotoService
{
    IEnumerable<HotelPhotoDto> GetHotelPhotos(Guid hotelId, bool trackChanges);
    HotelPhotoDto GetHotelPhoto(Guid hotelId, Guid id, bool trackChanges);
}