using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
namespace Service.Contracts.UserServices;

public interface IHotelPhotoService
{
    IEnumerable<HotelPhotoDto> GetHotelPhotos(Guid hotelId, bool trackChanges);
    IEnumerable<HotelPhotoDto> GetByIds(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges);
    HotelPhotoDto GetHotelPhoto(Guid hotelId, Guid id, bool trackChanges);
    HotelPhotoDto CreateHotelPhoto(Guid hotelId, HotelPhotoForCreationDto hotelPhoto, bool trackChanges);
    (IEnumerable<HotelPhotoDto> hotelPhotos, string ids) CreateHotelPhotoCollection
        (Guid hotelId, IEnumerable<HotelPhotoForCreationDto> hotelPhotosCollection);
    void DeleteHotelPhoto(Guid hotelId, Guid id, bool trackChanges);
}