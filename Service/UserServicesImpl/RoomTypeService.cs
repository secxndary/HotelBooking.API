﻿using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects;
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
}