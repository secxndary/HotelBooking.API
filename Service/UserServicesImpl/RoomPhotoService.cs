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


    public async Task<IEnumerable<RoomPhotoDto>> GetRoomPhotosAsync(Guid roomId, bool trackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);
        var roomPhotos = await _repository.RoomPhoto.GetRoomPhotosAsync(roomId, trackChanges);
        var roomPhotosDto = _mapper.Map<IEnumerable<RoomPhotoDto>>(roomPhotos);
        return roomPhotosDto;
    }

    public async Task<IEnumerable<RoomPhotoDto>> GetByIdsAsync(Guid roomId, IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhotos = await _repository.RoomPhoto.GetByIdsAsync(roomId, ids, trackChanges);
        if (roomPhotos.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var roomPhotosDto = _mapper.Map<IEnumerable<RoomPhotoDto>>(roomPhotos);
        return roomPhotosDto;
    }

    public async Task<RoomPhotoDto> GetRoomPhotoAsync(Guid roomId, Guid id, bool trackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhoto = await _repository.RoomPhoto.GetRoomPhotoAsync(roomId, id, trackChanges);
        if (roomPhoto is null)
            throw new RoomPhotoNotFoundException(id);

        var roomPhotoDto = _mapper.Map<RoomPhotoDto>(roomPhoto);
        return roomPhotoDto;
    }

    public async Task<RoomPhotoDto> CreateRoomPhotoAsync(Guid roomId, RoomPhotoForCreationDto roomPhoto, bool trackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhotoEntity = _mapper.Map<RoomPhoto>(roomPhoto);
        _repository.RoomPhoto.CreateRoomPhoto(roomId, roomPhotoEntity);
        await _repository.SaveAsync();

        var roomPhotoToReturn = _mapper.Map<RoomPhotoDto>(roomPhotoEntity);
        return roomPhotoToReturn;
    }

    public async Task<(IEnumerable<RoomPhotoDto> roomPhotos, string ids)> CreateRoomPhotoCollectionAsync
        (Guid roomId, IEnumerable<RoomPhotoForCreationDto> roomPhotosCollection)
    {
        if (roomPhotosCollection is null)
            throw new RoomPhotoCollectionBadRequest();

        var roomPhotosEntities = _mapper.Map<IEnumerable<RoomPhoto>>(roomPhotosCollection);
        foreach (var roomPhoto in roomPhotosEntities)
            _repository.RoomPhoto.CreateRoomPhoto(roomId, roomPhoto);
        await _repository.SaveAsync();

        var roomPhotosCollectionToReturn = _mapper.Map<IEnumerable<RoomPhotoDto>>(roomPhotosEntities);
        var ids = string.Join(",", roomPhotosCollectionToReturn.Select(p => p.Id));
        return (roomPhotos: roomPhotosCollectionToReturn, ids);
    }

    public async Task UpdateRoomPhotoAsync(Guid roomId, Guid id, RoomPhotoForUpdateDto roomPhotoForUpdate,
        bool roomTrackChanges, bool photoTrackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, roomTrackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhotoEntity = await _repository.RoomPhoto.GetRoomPhotoAsync(roomId, id, photoTrackChanges);
        if (roomPhotoEntity is null)
            throw new RoomPhotoNotFoundException(id);

        _mapper.Map(roomPhotoForUpdate, roomPhotoEntity);
        await _repository.SaveAsync();
    }

    public async Task<(RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity)> GetRoomPhotoForPatchAsync
        (Guid roomId, Guid id, bool roomTrackChanges, bool photoTrackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, roomTrackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhotoEntity = await _repository.RoomPhoto.GetRoomPhotoAsync(roomId, id, photoTrackChanges);
        if (roomPhotoEntity is null)
            throw new RoomPhotoNotFoundException(id);

        var photoToPatch = _mapper.Map<RoomPhotoForUpdateDto>(roomPhotoEntity);
        return (photoToPatch, roomPhotoEntity);
    }

    public async Task SaveChangesForPatchAsync(RoomPhotoForUpdateDto roomPhotoToPatch, RoomPhoto roomPhotoEntity)
    {
        _mapper.Map(roomPhotoToPatch, roomPhotoEntity);
        await _repository.SaveAsync();
    }

    public async Task DeleteRoomPhotoAsync(Guid roomId, Guid id, bool trackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var roomPhoto = await _repository.RoomPhoto.GetRoomPhotoAsync(roomId, id, trackChanges);
        if (roomPhoto is null)
            throw new RoomPhotoNotFoundException(id);

        _repository.RoomPhoto.DeleteRoomPhoto(roomPhoto);
        await _repository.SaveAsync();
    }
}