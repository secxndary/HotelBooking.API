using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IHotelPhotoService
{
    Task<IEnumerable<HotelPhotoDto>> GetHotelPhotosAsync(Guid hotelId, bool trackChanges);
    Task<IEnumerable<HotelPhotoDto>> GetByIdsAsync(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges);
    Task<HotelPhotoDto> GetHotelPhotoAsync(Guid hotelId, Guid id, bool trackChanges);
    Task<HotelPhotoDto> CreateHotelPhotoAsync(Guid hotelId, HotelPhotoForCreationDto hotelPhoto, bool trackChanges);
    Task<(IEnumerable<HotelPhotoDto> hotelPhotos, string ids)> CreateHotelPhotoCollectionAsync
        (Guid hotelId, IEnumerable<HotelPhotoForCreationDto> hotelPhotosCollection);
    Task UpdateHotelPhotoAsync(Guid hotelId, Guid id, HotelPhotoForUpdateDto hotelPhoto,
        bool hotelTrackChanges, bool photoTrackChanges);
    Task<(HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity)> GetHotelPhotoForPatchAsync
       (Guid hotelId, Guid id, bool hotelTrackChanges, bool photoTrackChanges);
    Task SaveChangesForPatchAsync(HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity);
    Task DeleteHotelPhotoAsync(Guid hotelId, Guid id, bool trackChanges);
}