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


    public async Task<IEnumerable<RoomDto>> GetRoomsAsync(Guid hotelId, bool trackChanges)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var rooms = await _repository.Room.GetRoomsAsync(hotelId, trackChanges);
        var roomsDto = _mapper.Map<IEnumerable<RoomDto>>(rooms);
        return roomsDto;
    }

    public async Task<IEnumerable<RoomDto>> GetByIdsForHotelAsync(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var rooms = await _repository.Room.GetByIdsForHotelAsync(hotelId, ids, trackChanges);
        if (rooms.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var roomsDto = _mapper.Map<IEnumerable<RoomDto>>(rooms);
        return roomsDto;
    }

    public async Task<RoomDto> GetRoomAsync(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);
        
        var room = await _repository.Room.GetRoomAsync(hotelId, id, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(id);
        
        var roomDto = _mapper.Map<RoomDto>(room);
        return roomDto;
    }

    public async Task<RoomDto> GetRoomAsync(Guid id, bool trackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(id, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(id);

        var roomDto = _mapper.Map<RoomDto>(room);
        return roomDto;
    }

    public async Task<RoomDto> CreateRoomForHotelAsync(Guid hotelId, RoomForCreationDto room, bool trackChanges)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var roomEntity = _mapper.Map<Room>(room);
        _repository.Room.CreateRoomForHotel(hotelId, roomEntity);
        await _repository.SaveAsync();

        var roomToReturn = _mapper.Map<RoomDto>(roomEntity);
        return roomToReturn;
    }

    public async Task<(IEnumerable<RoomDto> rooms, string ids)> CreateRoomCollectionAsync
        (Guid hotelId, IEnumerable<RoomForCreationDto> roomsCollection)
    {
        if (roomsCollection is null)
            throw new RoomCollectionBadRequest();

        var roomsEntities = _mapper.Map<IEnumerable<Room>>(roomsCollection);
        foreach (var room in roomsEntities)
            _repository.Room.CreateRoomForHotel(hotelId, room);
        await _repository.SaveAsync();

        var roomsCollectionToReturn = _mapper.Map<IEnumerable<RoomDto>>(roomsEntities);
        var ids = string.Join(",", roomsCollectionToReturn.Select(r => r.Id));
        return (rooms: roomsCollectionToReturn, ids);
    }

    public async Task UpdateRoomForHotelAsync(Guid hotelId, Guid id, RoomForUpdateDto roomForUpdate,
        bool hotelTrackChanges, bool roomTrackChanges)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, hotelTrackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var roomType = await _repository.RoomType.GetRoomTypeAsync(roomForUpdate.RoomTypeId, false);
        if (roomType is null)
            throw new RoomTypeNotFoundException(roomForUpdate.RoomTypeId);

        var roomEntity = await _repository.Room.GetRoomAsync(hotelId, id, roomTrackChanges);
        if (roomEntity is null)
            throw new RoomNotFoundException(id);

        _mapper.Map(roomForUpdate, roomEntity);
        await _repository.SaveAsync();
    }

    public async Task<(RoomForUpdateDto roomToPatch, Room roomEntity)> GetRoomForPatchAsync
        (Guid hotelId, Guid id, bool hotelTrackChanges, bool roomTrackChanges)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, hotelTrackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var roomEntity = await _repository.Room.GetRoomAsync(hotelId, id, roomTrackChanges);
        if (roomEntity is null)
            throw new RoomNotFoundException(id);

        var roomToPatch = _mapper.Map<RoomForUpdateDto>(roomEntity);
        return (roomToPatch, roomEntity);
    }

    public async Task SaveChangesForPatchAsync(RoomForUpdateDto roomToPatch, Room roomEntity)
    {
        _mapper.Map(roomToPatch, roomEntity);
        await _repository.SaveAsync();
    }

    public async Task DeleteRoomForHotelAsync(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var room = await _repository.Room.GetRoomAsync(hotelId, id, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(id);
        
        _repository.Room.DeleteRoom(room);
        await _repository.SaveAsync();
    }
}