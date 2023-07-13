using Shared.DataTransferObjects;
namespace Service.Contracts.UserServices;

public interface IHotelService
{
    IEnumerable<HotelDto> GetAllHotels(bool trackChanges);
    IEnumerable<HotelDto> GetByIds(IEnumerable<Guid> ids,  bool trackChanges);
    HotelDto GetHotel(Guid id, bool trackChanges);
    HotelDto CreateHotel(HotelForCreationDto hotel);
}