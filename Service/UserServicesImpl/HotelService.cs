using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects;
namespace Service.UserServicesImpl;

public sealed class HotelService : IHotelService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public HotelService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public IEnumerable<HotelDto> GetAllHotels(bool trackChanges)
    {
        var hotels = _repository.Hotel.GetAllHotels(trackChanges);
        var hotelsDto = _mapper.Map<IEnumerable<HotelDto>>(hotels);
        return hotelsDto;
    }

    public HotelDto GetHotel(Guid id, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(id, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(id);
        var hotelDto = _mapper.Map<HotelDto>(hotel);
        return hotelDto;
    }
}