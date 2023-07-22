﻿using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Exceptions.BadRequest;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
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


    public async Task<IEnumerable<HotelDto>> GetAllHotelsAsync()
    {
        var hotels = await _repository.Hotel.GetAllHotelsAsync(trackChanges: false);
        var hotelsDto = _mapper.Map<IEnumerable<HotelDto>>(hotels);
        return hotelsDto;
    }

    public async Task<IEnumerable<HotelDto>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var hotels = await _repository.Hotel.GetByIdsAsync(ids, trackChanges: false);
        if (hotels.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var hotelsDto = _mapper.Map<IEnumerable<HotelDto>>(hotels);
        return hotelsDto;
    }

    public async Task<HotelDto> GetHotelAsync(Guid id)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(id, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(id);

        var hotelDto = _mapper.Map<HotelDto>(hotel);
        return hotelDto;
    }

    public async Task<HotelDto> CreateHotelAsync(HotelForCreationDto hotel)
    {
        var hotelEntity = _mapper.Map<Hotel>(hotel);

        _repository.Hotel.CreateHotel(hotelEntity);
        await _repository.SaveAsync();

        var hotelToReturn = _mapper.Map<HotelDto>(hotelEntity);
        return hotelToReturn;
    }

    public async Task<(IEnumerable<HotelDto> hotels, string ids)> CreateHotelCollectionAsync
        (IEnumerable<HotelForCreationDto> hotelCollection)
    {
        if (hotelCollection is null)
            throw new HotelCollectionBadRequest();

        var hotelEntities = _mapper.Map<IEnumerable<Hotel>>(hotelCollection);
        foreach (var hotel in hotelEntities)
            _repository.Hotel.CreateHotel(hotel);
        await _repository.SaveAsync();

        var hotelCollectionToReturn = _mapper.Map<IEnumerable<HotelDto>>(hotelEntities);
        var ids = string.Join(",", hotelCollectionToReturn.Select(h => h.Id));
        return (hotels: hotelCollectionToReturn, ids);
    }

    public async Task UpdateHotelAsync(Guid id, HotelForUpdateDto hotelForUpdate)
    {
        var hotelEntity = await _repository.Hotel.GetHotelAsync(id, trackChanges: true);
        if (hotelEntity is null)
            throw new HotelNotFoundException(id);

        _mapper.Map(hotelForUpdate, hotelEntity);
        await _repository.SaveAsync();
    }

    public async Task<(HotelForUpdateDto hotelToPatch, Hotel hotelEntity)> GetHotelForPatchAsync(Guid id)
    {
        var hotelEntity = await _repository.Hotel.GetHotelAsync(id, trackChanges: true);
        if (hotelEntity is null)
            throw new HotelNotFoundException(id);

        var hotelToPatch = _mapper.Map<HotelForUpdateDto>(hotelEntity);
        return (hotelToPatch, hotelEntity);
    }

    public async Task SaveChangesForPatchAsync(HotelForUpdateDto hotelToPatch, Hotel hotelEntity)
    {
        _mapper.Map(hotelToPatch, hotelEntity);
        await _repository.SaveAsync();
    }

    public async Task DeleteHotelAsync(Guid id)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(id, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(id);
        
        _repository.Hotel.DeleteHotel(hotel);
        await _repository.SaveAsync();
    }
}