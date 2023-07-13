using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects;
namespace Service.UserServicesImpl;

public sealed class RoomPhotoService : IRoomPhotoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RoomPhotoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public IEnumerable<RoomPhotoDto> GetRoomPhotos(Guid roomId, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);
        var roomPhotos = _repository.RoomPhoto.GetRoomPhotos(roomId, trackChanges);
        var roomPhotosDto = _mapper.Map<IEnumerable<RoomPhotoDto>>(roomPhotos);
        return roomPhotosDto;
    }

    public RoomPhotoDto GetRoomPhoto(Guid roomId, Guid id, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhoto = _repository.RoomPhoto.GetRoomPhoto(roomId, id, trackChanges);
        if (roomPhoto is null)
            throw new RoomPhotoNotFoundException(id);

        var roomPhotoDto = _mapper.Map<RoomPhotoDto>(roomPhoto);
        return roomPhotoDto;
    }

    public void DeleteRoomPhoto(Guid roomId, Guid id, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhoto = _repository.RoomPhoto.GetRoomPhoto(roomId, id, trackChanges);
        if (roomPhoto is null)
            throw new RoomPhotoNotFoundException(id);

        _repository.RoomPhoto.DeleteRoomPhoto(roomPhoto);
        _repository.Save();
    }
}