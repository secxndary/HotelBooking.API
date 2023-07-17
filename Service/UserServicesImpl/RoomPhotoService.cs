using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.BadRequest;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
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

    public IEnumerable<RoomPhotoDto> GetByIds(Guid roomId, IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhotos = _repository.RoomPhoto.GetByIds(roomId, ids, trackChanges);
        if (roomPhotos.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

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

    public RoomPhotoDto CreateRoomPhoto(Guid roomId, RoomPhotoForCreationDto roomPhoto, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhotoEntity = _mapper.Map<RoomPhoto>(roomPhoto);
        _repository.RoomPhoto.CreateRoomPhoto(roomId, roomPhotoEntity);
        _repository.Save();

        var roomPhotoToReturn = _mapper.Map<RoomPhotoDto>(roomPhotoEntity);
        return roomPhotoToReturn;
    }

    public (IEnumerable<RoomPhotoDto> roomPhotos, string ids) CreateRoomPhotoCollection
        (Guid roomId, IEnumerable<RoomPhotoForCreationDto> roomPhotosCollection)
    {
        if (roomPhotosCollection is null)
            throw new RoomPhotoCollectionBadRequest();

        var roomPhotosEntities = _mapper.Map<IEnumerable<RoomPhoto>>(roomPhotosCollection);
        foreach (var roomPhoto in roomPhotosEntities)
            _repository.RoomPhoto.CreateRoomPhoto(roomId, roomPhoto);
        _repository.Save();

        var roomPhotosCollectionToReturn = _mapper.Map<IEnumerable<RoomPhotoDto>>(roomPhotosEntities);
        var ids = string.Join(",", roomPhotosCollectionToReturn.Select(p => p.Id));
        return (roomPhotos: roomPhotosCollectionToReturn, ids);
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