using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.OutputDtos;
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