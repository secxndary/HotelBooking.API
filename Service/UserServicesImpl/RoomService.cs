using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.BadRequest;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
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

    public IEnumerable<RoomDto> GetByIdsForHotel(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var rooms = _repository.Room.GetByIdsForHotel(hotelId, ids, trackChanges);
        if (rooms.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

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

    public RoomDto GetRoom(Guid id, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(id, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(id);

        var roomDto = _mapper.Map<RoomDto>(room);
        return roomDto;
    }

    public RoomDto CreateRoomForHotel(Guid hotelId, RoomForCreationDto room, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var roomEntity = _mapper.Map<Room>(room);
        _repository.Room.CreateRoomForHotel(hotelId, roomEntity);
        _repository.Save();

        var roomToReturn = _mapper.Map<RoomDto>(roomEntity);
        return roomToReturn;
    }

    public (IEnumerable<RoomDto> rooms, string ids) CreateRoomCollection
        (Guid hotelId, IEnumerable<RoomForCreationDto> roomsCollection)
    {
        if (roomsCollection is null)
            throw new RoomCollectionBadRequest();

        var roomsEntities = _mapper.Map<IEnumerable<Room>>(roomsCollection);
        foreach (var room in roomsEntities)
            _repository.Room.CreateRoomForHotel(hotelId, room);
        _repository.Save();

        var roomsCollectionToReturn = _mapper.Map<IEnumerable<RoomDto>>(roomsEntities);
        var ids = string.Join(",", roomsCollectionToReturn.Select(r => r.Id));
        return (rooms: roomsCollectionToReturn, ids);
    }

    public void UpdateRoomForHotel(Guid hotelId, Guid id, RoomForUpdateDto roomForUpdate,
        bool hotelTrackChanges, bool roomTrackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, hotelTrackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var roomType = _repository.RoomType.GetRoomType(roomForUpdate.RoomTypeId, false);
        if (roomType is null)
            throw new RoomTypeNotFoundException(roomForUpdate.RoomTypeId);

        var roomEntity = _repository.Room.GetRoom(hotelId, id, roomTrackChanges);
        if (roomEntity is null)
            throw new RoomNotFoundException(id);

        _mapper.Map(roomForUpdate, roomEntity);
        _repository.Save();
    }

    public void DeleteRoomForHotel(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var room = _repository.Room.GetRoom(hotelId, id, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(id);
        
        _repository.Room.DeleteRoom(room);
        _repository.Save();
    }
}