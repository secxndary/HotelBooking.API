﻿using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
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


    public async Task<IEnumerable<RoomTypeDto>> GetAllRoomTypesAsync()
    {
        var roomTypes = await _repository.RoomType.GetAllRoomTypesAsync(trackChanges: false);
        var roomTypesDto = _mapper.Map<IEnumerable<RoomTypeDto>>(roomTypes);
        return roomTypesDto;
    }

    public async Task<RoomTypeDto> GetRoomTypeAsync(Guid id)
    {
        var roomType = await _repository.RoomType.GetRoomTypeAsync(id, trackChanges: false);
        if (roomType is null)
            throw new RoomTypeNotFoundException(id);

        var roomTypeDto = _mapper.Map<RoomTypeDto>(roomType);
        return roomTypeDto;
    }

    public async Task<RoomTypeDto> CreateRoomTypeAsync(RoomTypeForCreationDto roomType)
    {
        var roomTypeEntity = _mapper.Map<RoomType>(roomType);

        _repository.RoomType.CreateRoomType(roomTypeEntity);
        await _repository.SaveAsync();

        var roomTypeToReturn = _mapper.Map<RoomTypeDto>(roomTypeEntity); 
        return roomTypeToReturn;
    }

    public async Task UpdateRoomTypeAsync(Guid id, RoomTypeForUpdateDto roomTypeForUpdate)
    {
        var roomTypeEntity = await _repository.RoomType.GetRoomTypeAsync(id, trackChanges: true);
        if (roomTypeEntity is null)
            throw new RoomTypeNotFoundException(id);

        _mapper.Map(roomTypeForUpdate, roomTypeEntity);
        await _repository.SaveAsync();
    }

    public async Task<(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity)> GetRoomTypeForPatchAsync
        (Guid id)
    {
        var roomTypeEntity = await _repository.RoomType.GetRoomTypeAsync(id, trackChanges: true);
        if (roomTypeEntity is null)
            throw new RoomTypeNotFoundException(id);

        var roomTypeToPatch = _mapper.Map<RoomTypeForUpdateDto>(roomTypeEntity);
        return (roomTypeToPatch, roomTypeEntity);
    }

    public async Task SaveChangesForPatchAsync(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity)
    {
        _mapper.Map(roomTypeToPatch, roomTypeEntity);
        await _repository.SaveAsync();
    }

    public async Task DeleteRoomTypeAsync(Guid id)
    {
        var roomType = await _repository.RoomType.GetRoomTypeAsync(id, trackChanges: false);
        if (roomType is null)
            throw new RoomTypeNotFoundException(id);

        _repository.RoomType.DeleteRoomType(roomType);
        await _repository.SaveAsync();
    }
}