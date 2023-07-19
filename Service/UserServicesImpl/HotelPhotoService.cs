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


    public IEnumerable<HotelPhotoDto> GetHotelPhotos(Guid hotelId, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhotos = _repository.HotelPhoto.GetHotelPhotos(hotelId, trackChanges);
        var hotelPhotosDto = _mapper.Map<IEnumerable<HotelPhotoDto>>(hotelPhotos);
        return hotelPhotosDto;
    }

    public IEnumerable<HotelPhotoDto> GetByIds(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhotos = _repository.HotelPhoto.GetByIds(hotelId, ids, trackChanges);
        if (hotelPhotos.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var hotelPhotosDto = _mapper.Map<IEnumerable<HotelPhotoDto>>(hotelPhotos);
        return hotelPhotosDto;
    }

    public HotelPhotoDto GetHotelPhoto(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhoto = _repository.HotelPhoto.GetHotelPhoto(hotelId, id, trackChanges);
        if (hotelPhoto is null)
            throw new HotelPhotoNotFoundException(id);

        var hotelPhotoDto = _mapper.Map<HotelPhotoDto>(hotelPhoto);
        return hotelPhotoDto;
    }

    public HotelPhotoDto CreateHotelPhoto(Guid hotelId, HotelPhotoForCreationDto hotelPhoto, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhotoEntity = _mapper.Map<HotelPhoto>(hotelPhoto);
        _repository.HotelPhoto.CreateHotelPhoto(hotelId, hotelPhotoEntity);
        _repository.Save();

        var hotelPhotoToReturn = _mapper.Map<HotelPhotoDto>(hotelPhotoEntity);
        return hotelPhotoToReturn;
    }

    public (IEnumerable<HotelPhotoDto> hotelPhotos, string ids) CreateHotelPhotoCollection
    (Guid hotelId, IEnumerable<HotelPhotoForCreationDto> hotelPhotosCollection)
    {
        if (hotelPhotosCollection is null)
            throw new HotelPhotoCollectionBadRequest();

        var hotelPhotosEntities = _mapper.Map<IEnumerable<HotelPhoto>>(hotelPhotosCollection);
        foreach (var hotelPhoto in hotelPhotosEntities)
            _repository.HotelPhoto.CreateHotelPhoto(hotelId, hotelPhoto);
        _repository.Save();

        var hotelPhotosCollectionToReturn = _mapper.Map<IEnumerable<HotelPhotoDto>>(hotelPhotosEntities);
        var ids = string.Join(",", hotelPhotosCollectionToReturn.Select(p => p.Id));
        return (hotelPhotos: hotelPhotosCollectionToReturn, ids);
    }

    public void UpdateHotelPhoto(Guid hotelId, Guid id, HotelPhotoForUpdateDto hotelPhotoForUpdate,
        bool hotelTrackChanges, bool photoTrackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, hotelTrackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhotoEntity = _repository.HotelPhoto.GetHotelPhoto(hotelId, id, photoTrackChanges);
        if (hotelPhotoEntity is null)
            throw new HotelPhotoNotFoundException(id);

        _mapper.Map(hotelPhotoForUpdate, hotelPhotoEntity);
        _repository.Save();
    }

    public void DeleteHotelPhoto(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var hotelPhoto = _repository.HotelPhoto.GetHotelPhoto(hotelId, id, trackChanges);
        if (hotelPhoto is null)
            throw new HotelPhotoNotFoundException(id);

        _repository.HotelPhoto.DeleteHotelPhoto(hotelPhoto);
        _repository.Save();
    }
}