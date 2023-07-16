using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
namespace Service.Contracts.UserServices;

public interface IHotelService
{
    IEnumerable<HotelDto> GetAllHotels(bool trackChanges);
    IEnumerable<HotelDto> GetByIds(IEnumerable<Guid> ids,  bool trackChanges);
    HotelDto GetHotel(Guid id, bool trackChanges);
    HotelDto CreateHotel(HotelForCreationDto hotel);
    (IEnumerable<HotelDto> hotels, string ids) CreateHotelCollection 
        (IEnumerable<HotelForCreationDto> hotelCollection);
    void DeleteHotel(Guid id, bool trackChanges);
}