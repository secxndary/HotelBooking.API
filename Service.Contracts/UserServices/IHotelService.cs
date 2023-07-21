using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IHotelService
{
    Task<IEnumerable<HotelDto>> GetAllHotelsAsync(bool trackChanges);
    Task<IEnumerable<HotelDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<HotelDto> GetHotelAsync(Guid id, bool trackChanges);
    Task<HotelDto> CreateHotelAsync(HotelForCreationDto hotel);
    Task<(IEnumerable<HotelDto> hotels, string ids)> CreateHotelCollectionAsync 
        (IEnumerable<HotelForCreationDto> hotelCollection);
    Task UpdateHotelAsync(Guid id, HotelForUpdateDto hotel, bool trackChanges);
    Task<(HotelForUpdateDto hotelToPatch, Hotel hotelEntity)> GetHotelForPatchAsync(Guid id, bool trackChanges);
    Task SaveChangesForPatchAsync(HotelForUpdateDto hotelToPatch, Hotel hotelEntity);
    Task DeleteHotelAsync(Guid id, bool trackChanges);
}