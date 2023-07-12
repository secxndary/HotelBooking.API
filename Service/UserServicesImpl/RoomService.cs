using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects;
namespace Service.UserServicesImpl;

public sealed class RoomService : IRoomService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RoomService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public IEnumerable<RoomDto> GetRooms(Guid hotelId, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);
        var rooms = _repository.Room.GetRooms(hotelId, trackChanges);
        var roomsDto = _mapper.Map<IEnumerable<RoomDto>>(rooms);
        return roomsDto;
    }

    public RoomDto GetRoom(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);
        
        var room = _repository.Room.GetRoom(hotelId, id, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(id);
        
        var roomDto = _mapper.Map<RoomDto>(room);
        return roomDto;
    }
}