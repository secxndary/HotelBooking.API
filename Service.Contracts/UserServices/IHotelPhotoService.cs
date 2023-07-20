using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IHotelPhotoService
{
    IEnumerable<HotelPhotoDto> GetHotelPhotos(Guid hotelId, bool trackChanges);
    IEnumerable<HotelPhotoDto> GetByIds(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges);
    HotelPhotoDto GetHotelPhoto(Guid hotelId, Guid id, bool trackChanges);
    HotelPhotoDto CreateHotelPhoto(Guid hotelId, HotelPhotoForCreationDto hotelPhoto, bool trackChanges);
    (IEnumerable<HotelPhotoDto> hotelPhotos, string ids) CreateHotelPhotoCollection
        (Guid hotelId, IEnumerable<HotelPhotoForCreationDto> hotelPhotosCollection);
    void UpdateHotelPhoto(Guid hotelId, Guid id, HotelPhotoForUpdateDto hotelPhoto,
        bool hotelTrackChanges, bool photoTrackChanges);
    (HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity) GetHotelPhotoForPatch
       (Guid hotelId, Guid id, bool hotelTrackChanges, bool photoTrackChanges);
    void SaveChangesForPatch(HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity);
    void DeleteHotelPhoto(Guid hotelId, Guid id, bool trackChanges);
}