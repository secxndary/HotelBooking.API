using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
namespace Service.UserServicesImpl;

public sealed class RoomTypeService : IRoomTypeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RoomTypeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public IEnumerable<RoomTypeDto> GetAllRoomTypes(bool trackChanges)
    {
        var roomTypes = _repository.RoomType.GetAllRoomTypes(trackChanges);
        var roomTypesDto = _mapper.Map<IEnumerable<RoomTypeDto>>(roomTypes);
        return roomTypesDto;
    }

    public RoomTypeDto GetRoomType(Guid id, bool trackChanges)
    {
        var roomType = _repository.RoomType.GetRoomType(id, trackChanges);
        if (roomType is null)
            throw new RoomTypeNotFoundException(id);

        var roomTypeDto = _mapper.Map<RoomTypeDto>(roomType);
        return roomTypeDto;
    }

    public RoomTypeDto CreateRoomType(RoomTypeForCreationDto roomType)
    {
        var roomTypeEntity = _mapper.Map<RoomType>(roomType);

        _repository.RoomType.CreateRoomType(roomTypeEntity);
        _repository.Save();

        var roomTypeToReturn = _mapper.Map<RoomTypeDto>(roomTypeEntity); 
        return roomTypeToReturn;
    }

    public void DeleteRoomType(Guid id, bool trackChanges)
    {
        var roomType = _repository.RoomType.GetRoomType(id, trackChanges);
        if (roomType is null)
            throw new RoomTypeNotFoundException(id);

        _repository.RoomType.DeleteRoomType(roomType);
        _repository.Save();
    }
}