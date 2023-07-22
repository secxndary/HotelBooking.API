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

public sealed class HotelPhotoService : IHotelPhotoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public HotelPhotoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<IEnumerable<HotelPhotoDto>> GetHotelPhotosAsync(Guid hotelId)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhotos = await _repository.HotelPhoto.GetHotelPhotosAsync(hotelId, trackChanges: false);
        var hotelPhotosDto = _mapper.Map<IEnumerable<HotelPhotoDto>>(hotelPhotos);
        return hotelPhotosDto;
    }

    public async Task<IEnumerable<HotelPhotoDto>> GetByIdsAsync(Guid hotelId, IEnumerable<Guid> ids)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhotos = await _repository.HotelPhoto.GetByIdsAsync(hotelId, ids, trackChanges: false);
        if (hotelPhotos.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var hotelPhotosDto = _mapper.Map<IEnumerable<HotelPhotoDto>>(hotelPhotos);
        return hotelPhotosDto;
    }

    public async Task<HotelPhotoDto> GetHotelPhotoAsync(Guid hotelId, Guid id)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhoto = await _repository.HotelPhoto.GetHotelPhotoAsync(hotelId, id, trackChanges: false);
        if (hotelPhoto is null)
            throw new HotelPhotoNotFoundException(id);

        var hotelPhotoDto = _mapper.Map<HotelPhotoDto>(hotelPhoto);
        return hotelPhotoDto;
    }

    public async Task<HotelPhotoDto> CreateHotelPhotoAsync(Guid hotelId, HotelPhotoForCreationDto hotelPhoto)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhotoEntity = _mapper.Map<HotelPhoto>(hotelPhoto);
        _repository.HotelPhoto.CreateHotelPhoto(hotelId, hotelPhotoEntity);
        await _repository.SaveAsync();

        var hotelPhotoToReturn = _mapper.Map<HotelPhotoDto>(hotelPhotoEntity);
        return hotelPhotoToReturn;
    }

    public async Task<(IEnumerable<HotelPhotoDto> hotelPhotos, string ids)> CreateHotelPhotoCollectionAsync
        (Guid hotelId, IEnumerable<HotelPhotoForCreationDto> hotelPhotosCollection)
    {
        if (hotelPhotosCollection is null)
            throw new HotelPhotoCollectionBadRequest();

        var hotelPhotosEntities = _mapper.Map<IEnumerable<HotelPhoto>>(hotelPhotosCollection);
        foreach (var hotelPhoto in hotelPhotosEntities)
            _repository.HotelPhoto.CreateHotelPhoto(hotelId, hotelPhoto);
        await _repository.SaveAsync();

        var hotelPhotosCollectionToReturn = _mapper.Map<IEnumerable<HotelPhotoDto>>(hotelPhotosEntities);
        var ids = string.Join(",", hotelPhotosCollectionToReturn.Select(p => p.Id));
        return (hotelPhotos: hotelPhotosCollectionToReturn, ids);
    }

    public async Task UpdateHotelPhotoAsync(Guid hotelId, Guid id, HotelPhotoForUpdateDto hotelPhotoForUpdate)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhotoEntity = await _repository.HotelPhoto.GetHotelPhotoAsync(hotelId, id, trackChanges: true);
        if (hotelPhotoEntity is null)
            throw new HotelPhotoNotFoundException(id);

        _mapper.Map(hotelPhotoForUpdate, hotelPhotoEntity);
        await _repository.SaveAsync();
    }

    public async Task<(HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity)> GetHotelPhotoForPatchAsync
        (Guid hotelId, Guid id)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhotoEntity = await _repository.HotelPhoto.GetHotelPhotoAsync(hotelId, id, trackChanges: true);
        if (hotelPhotoEntity is null)
            throw new HotelPhotoNotFoundException(id);

        var photoToPatch = _mapper.Map<HotelPhotoForUpdateDto>(hotelPhotoEntity);
        return (photoToPatch, hotelPhotoEntity);
    }

    public async Task SaveChangesForPatchAsync(HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity)
    {
        _mapper.Map(hotelPhotoToPatch, hotelPhotoEntity);
        await _repository.SaveAsync();
    }

    public async Task DeleteHotelPhotoAsync(Guid hotelId, Guid id)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhoto = await _repository.HotelPhoto.GetHotelPhotoAsync(hotelId, id, trackChanges: false);
        if (hotelPhoto is null)
            throw new HotelPhotoNotFoundException(id);

        _repository.HotelPhoto.DeleteHotelPhoto(hotelPhoto);
        await _repository.SaveAsync();
    }
}