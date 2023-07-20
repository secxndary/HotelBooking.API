using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IHotelService
{
    IEnumerable<HotelDto> GetAllHotels(bool trackChanges);
    IEnumerable<HotelDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    HotelDto GetHotel(Guid id, bool trackChanges);
    HotelDto CreateHotel(HotelForCreationDto hotel);
    (IEnumerable<HotelDto> hotels, string ids) CreateHotelCollection 
        (IEnumerable<HotelForCreationDto> hotelCollection);
    void UpdateHotel(Guid id, HotelForUpdateDto hotel, bool trackChanges);
    (HotelForUpdateDto hotelToPatch, Hotel hotelEntity) GetHotelForPatch(Guid id, bool trackChanges);
    void SaveChangesForPatch(HotelForUpdateDto hotelToPatch, Hotel hotelEntity);
    void DeleteHotel(Guid id, bool trackChanges);
}