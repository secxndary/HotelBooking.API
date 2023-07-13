using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Exceptions.BadRequest;
using Entities.Models;
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

    public IEnumerable<HotelDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var hotels = _repository.Hotel.GetByIds(ids, trackChanges);
        if (hotels.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

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

    public HotelDto CreateHotel(HotelForCreationDto hotel)
    {
        var hotelEntity = _mapper.Map<Hotel>(hotel);

        _repository.Hotel.CreateHotel(hotelEntity);
        _repository.Save();

        var hotelToReturn = _mapper.Map<HotelDto>(hotelEntity);
        return hotelToReturn;
    }

    public (IEnumerable<HotelDto> hotels, string ids) CreateHotelCollection
        (IEnumerable<HotelForCreationDto> hotelCollection)
    {
        if (hotelCollection is null)
            throw new HotelCollectionBadRequest();

        var hotelEntities = _mapper.Map<IEnumerable<Hotel>>(hotelCollection);
        foreach (var hotel in hotelEntities)
            _repository.Hotel.CreateHotel(hotel);
        _repository.Save();

        var hotelCollectionToReturn = _mapper.Map<IEnumerable<HotelDto>>(hotelEntities);
        var ids = string.Join(",", hotelCollectionToReturn.Select(h => h.Id));
        return (hotels: hotelCollectionToReturn, ids);
    }

    public void DeleteHotel(Guid id, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(id, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(id);
        
        _repository.Hotel.DeleteHotel(hotel);
        _repository.Save();
    }
}